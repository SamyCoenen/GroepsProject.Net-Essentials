using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;

namespace leren
{
    class IODatabase
    {
        // Input en output methoden
        // Date: 01/04/15 - Last edit: 24/04/15
        // Author: Timothy Vanderaerden

        //Constructor en filename aangepast om deze classe te kunnen gebruiken bij meerdere vakken
        //Author: Samy Coenen
        //Date: 11/04/2015 14:54
        private string dataVak;
        
        public IODatabase(String vak)
        {
            dataVak = vak;
        }

        public List<KeuzeVraag> ReadKeuzeVragenByGraad(int graad)
        {
            string filename = "../../Data/" + dataVak+"vragen_" + graad + ".txt";
            return ReadKeuzevragen(filename);
        }

        public List<KeuzeVraag> ReadKeuzevragen(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            List<KeuzeVraag> vragenlijst = new List<KeuzeVraag>();
            foreach (string line in lines)
            {
                int deelEinde = line.IndexOf("-");
                string vraag = line.Substring(0, deelEinde - 1);
                List<string> antwoorden = new List<string>();
                int deelBegin = deelEinde + 1;
                while ((deelEinde = line.IndexOf("$", deelBegin)) != -1)
                {
                    antwoorden.Add(line.Substring(deelBegin, (deelEinde - deelBegin)));
                    deelBegin = deelEinde + 1;
                }
                int juistIndex = Int32.Parse(line.Substring(deelBegin, line.Length - deelBegin));
                KeuzeVraag keuzevraag = new KeuzeVraag(vraag, antwoorden, juistIndex);
                vragenlijst.Add(keuzevraag);
            }
            return vragenlijst;
        }

        public void SchrijfResultaatKennis(List<KeuzeVraag> keuzeVragen, List<KeuzeAntwoord> keuzeAntwoorden, string naam, int graad)
        {
            StringBuilder resultaat = new StringBuilder();
            resultaat.Append(naam + ":" + graad.ToString() + "(");

            foreach(KeuzeAntwoord antwoord in keuzeAntwoorden) {
                KeuzeVraag keuzeVraag = keuzeVragen[antwoord.Index];
                int juist = 0;
                if (antwoord.Antwoord == keuzeVraag.JuistIndex)
                {
                    juist = 1;
                }
                resultaat.Append(keuzeVraag.Vraag + ":" + keuzeVraag.Keuzes[keuzeVraag.JuistIndex] + ":" + juist + "$");
            }
            resultaat.Append(")$");

            StreamWriter writeout = new StreamWriter("../../Data/kennisresultaat.txt", true);

            try
            {
                writeout.WriteLine(resultaat);
            }
            catch (System.IO.IOException)
            {
                string messageBoxText = "Error: System.IO.IOException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            catch (System.ObjectDisposedException)
            {
                string messageBoxText = "Error: System.ObjectDisposedException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            finally
            {
                writeout.Close();
            }
        }

        public void SchrijfResultaatAarderijkskunde(List<string> antwoorden, List<string> oplossingen, string naam, int graad)
        {
            StringBuilder resultaat = new StringBuilder();
            resultaat.Append(naam + ":" + graad.ToString() + "(");

            for (int i = 0; i < oplossingen.Count; i++)
            {
                int juist = 0;
                if (antwoorden[i].ToString() == oplossingen[i].ToString())
                {
                    juist = 1;
                }
                resultaat.Append(oplossingen[i].ToString() + ":" + antwoorden[i].ToString() + ":" + juist + "$");
            }
            resultaat.Append(")$");

            StreamWriter writeout = new StreamWriter("../../Data/aardrijkskunderesultaat.txt", true);

            try
            {
                writeout.WriteLine(resultaat);
            }
            catch (System.IO.IOException)
            {
                string messageBoxText = "Error: System.IO.IOException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            catch (System.ObjectDisposedException)
            {
                string messageBoxText = "Error: System.ObjectDisposedException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            finally
            {
                writeout.Close();
            }
        }

        public void SchrijfResultaatTaal(List<KeuzeVraag> keuzeVragen, List<KeuzeAntwoord> keuzeAntwoorden, string naam, int graad)
        {
            StringBuilder resultaat = new StringBuilder();
            resultaat.Append(naam + ":" + graad.ToString() + "(");

            foreach (KeuzeAntwoord antwoord in keuzeAntwoorden)
            {
                KeuzeVraag keuzeVraag = keuzeVragen[antwoord.Index];
                int juist = 0;
                if (antwoord.Antwoord == keuzeVraag.JuistIndex)
                {
                    juist = 1;
                }
                resultaat.Append(keuzeVraag.Vraag + ":" + keuzeVraag.Keuzes[keuzeVraag.JuistIndex] + ":" + juist + "$");
            }
            resultaat.Append(")$");

            StreamWriter writeout = new StreamWriter("../../Data/taalresultaat.txt", true);

            try
            {
                writeout.WriteLine(resultaat);
            }
            catch (System.IO.IOException)
            {
                string messageBoxText = "Error: System.IO.IOException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            catch (System.ObjectDisposedException)
            {
                string messageBoxText = "Error: System.ObjectDisposedException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            finally
            {
                writeout.Close();
            }
        }

        public void VerwijderOefening(int index, string file)
        {
            string[] lines = File.ReadAllLines("../../Data/" + file);
            string[] newLines = new string[lines.Length -1];
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != lines[index])
                {
                    newLines[i] = lines[i].ToString();
                }
            }
            File.WriteAllLines("../../Data/" + file, newLines);
        }

        public void schrijfOefening(string vraag, string[] antwoorden, int juist, string file)
        {
            StringBuilder oefening = new StringBuilder();
            oefening.Append(vraag + "-");

            for (int i = 0; i < antwoorden.Length; i++)
            {
                oefening.Append(antwoorden[i].ToString() + "$");
            }
            oefening.Append(juist);

            StreamWriter writeout = new StreamWriter("../../Data/" + file, true);

            try
            {
                writeout.WriteLine(Environment.NewLine + oefening);
                string messageBoxText = "Uw vraag is succesvol opgeslaan!";
                string caption = "Gelukt";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            catch (System.IO.IOException)
            {
                string messageBoxText = "Error: System.IO.IOException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            catch (System.ObjectDisposedException)
            {
                string messageBoxText = "Error: System.ObjectDisposedException";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            finally
            {
                writeout.Close();
            }
        }

    }
}
