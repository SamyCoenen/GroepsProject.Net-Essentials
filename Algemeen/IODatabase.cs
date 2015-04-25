using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            writeout.WriteLine(resultaat);
            writeout.Close();
        }

    }
}
