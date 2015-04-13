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
    // Date: 06/04/15 - Last edit: 06/04/15
    // Author: Timothy Vanderaerden

    public partial class Resultaat : Window
    {
        private List<KeuzeVraag> vragen = new List<KeuzeVraag>();
        private List<KeuzeAntwoord> antwoorden = new List<KeuzeAntwoord>();
        private Kennis kennisWindow;
        private int punten;

        public Resultaat()
        {
            InitializeComponent();
            Loaded+=Resultaat_Loaded;
        }

        private void Resultaat_Loaded(object sender, RoutedEventArgs e)
        {
            printResultaat();
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

        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindows();
        }

        private void CloseWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }
    }
}
