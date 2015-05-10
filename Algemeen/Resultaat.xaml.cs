using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace leren
{
    // Resultaat Window
    // Date: 06/04/15 - Last edit: 29/04/15
    // Author: Timothy Vanderaerden

    public partial class Resultaat : Window
    {
        private List<KeuzeVraag> vragen = new List<KeuzeVraag>();
        private List<KeuzeAntwoord> antwoorden = new List<KeuzeAntwoord>();
        private List<string> antwoordenAarderijkskunde = new List<string>();
        private List<string> oplossingenAarderijkskunde = new List<string>();
        private int graad;
        private int punten;
        private string vak;

        public Resultaat(string v)
        {
            InitializeComponent();
            Loaded+=Resultaat_Loaded;
            vak = v;
        }

        // printResultaat oproepen bij het laden van de form
        private void Resultaat_Loaded(object sender, RoutedEventArgs e)
        {
            if (vak.Equals("Kennis") || vak.Equals("Taal") || vak.Equals("Wiskunde"))
            {
                printResultaat();
            }
            else
            {
                printResultaatAardrijkskunde(antwoordenAarderijkskunde, oplossingenAarderijkskunde, graad);
            }
        }

        // Methode om het resultaat te printen
        private void printResultaat()
        {
            resultatenGrid.Children.Clear();
            resultatenGrid.RowDefinitions.Clear();
            for (int i = 0; antwoorden.Count > i; i++)
            {
                KeuzeAntwoord antwoord = antwoorden[i];
                if (antwoord.Antwoord == vragen[antwoord.Index].JuistIndex)
                {
                    Label vraaglbl = new Label();
                    vraaglbl.FontSize = 15;
                    vraaglbl.Content = vragen[antwoord.Index].Vraag +
                        Environment.NewLine + "Uw antwoord: " + vragen[antwoord.Index].Keuzes[antwoord.Antwoord];
                    vraaglbl.Foreground = Brushes.Green;
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(45);
                    resultatenGrid.RowDefinitions.Add(row);
                    Grid.SetRow(vraaglbl, i);
                    resultatenGrid.Children.Add(vraaglbl);
                    punten++;
                }
                else
                {
                    Label vraaglbl = new Label();
                    vraaglbl.FontSize = 15;
                    vraaglbl.Content = vragen[antwoord.Index].Vraag +
                        Environment.NewLine + "Uw antwoord: " + vragen[antwoord.Index].Keuzes[antwoord.Antwoord] +
                        Environment.NewLine + "Het juiste antwoord: " + vragen[antwoord.Index].getAntwoord();
                    vraaglbl.Foreground = Brushes.Red;
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(65);
                    resultatenGrid.RowDefinitions.Add(row);
                    Grid.SetRow(vraaglbl, i);
                    resultatenGrid.Children.Add(vraaglbl);
                }
                resultaatlbl.Content = "Uw score is: " + punten + "/" + antwoorden.Count;
            }
        }

        // Methode om het resultaat van aardrijksunde te tonen
        private void printResultaatAardrijkskunde(List<string> antwoorden, List<string> oplossingen, int graad) 
        {
            resultatenGrid.Children.Clear();
            resultatenGrid.RowDefinitions.Clear();
            for (int i = 0; antwoorden.Count > i; i++)
            {
                if (antwoorden[i] == oplossingen[i])
                {
                    Label vraaglbl = new Label();
                    vraaglbl.FontSize = 15;
                    vraaglbl.Content = "Oplossing " + oplossingen[i] +
                        Environment.NewLine + "Uw antwoord: " + antwoorden[i];
                    vraaglbl.Foreground = Brushes.Green;
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(45);
                    resultatenGrid.RowDefinitions.Add(row);
                    Grid.SetRow(vraaglbl, i);
                    resultatenGrid.Children.Add(vraaglbl);
                    punten++;
                }
                else
                {
                    Label vraaglbl = new Label();
                    vraaglbl.FontSize = 15;
                    vraaglbl.Content = "Oplossing " + oplossingen[i] +
                        Environment.NewLine + "Uw antwoord: " + antwoorden[i];
                    vraaglbl.Foreground = Brushes.Red;
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(45);
                    resultatenGrid.RowDefinitions.Add(row);
                    Grid.SetRow(vraaglbl, i);
                    resultatenGrid.Children.Add(vraaglbl);
                }
                if (graad == 0)
                {
                    resultaatlbl.Content = "Uw score is: " + punten + "/" + oplossingen.Count.ToString();
                }
                else
                {
                    resultaatlbl.Content = "Uw score is: " + punten + "/" + oplossingen.Count.ToString();
                }
            }
        }


        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper close = new WindowHelper();
            close.CloseWindows();
        }

        public List<string> OplossingenAarderijkskunde
        {
            get { return oplossingenAarderijkskunde; }
            set { oplossingenAarderijkskunde = value; }
        }

        public List<string> AntwoordenAarderijkskunde
        {
            get { return antwoordenAarderijkskunde; }
            set { antwoordenAarderijkskunde = value; }
        }

        public int Graad
        {
            get { return graad; }
            set { graad = value; }
        }

        internal List<KeuzeVraag> Vragen
        {
            get { return vragen; }
            set { vragen = value; }
        }

        internal List<KeuzeAntwoord> Antwoorden
        {
            get { return antwoorden; }
            set { antwoorden = value; }
        }

    }
}
