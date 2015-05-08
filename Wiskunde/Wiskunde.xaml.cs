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
    /// <summary>
    /// Interaction logic for Wiskunde.xaml
    /// </summary>
    public partial class Wiskunde : Window
    {
        private int graad;
        private List<KeuzeVraag> keuzevragen = new List<KeuzeVraag>();
        private List<int> vragenGeschiedenis = new List<int>();
        private List<KeuzeAntwoord> keuzeAntwoorden = new List<KeuzeAntwoord>();
        private int index;
        public Wiskunde()
        {
            InitializeComponent();
            Loaded += Wiskunde_Loaded;

        }
        private void Wiskunde_Loaded(object sender, RoutedEventArgs e)
        {
            if (graad == 0)
            {
                Makkelijk();
            }
            else
            {
                IODatabase database = new IODatabase("wiskunde");
                keuzevragen = database.ReadKeuzeVragenByGraad(graad);
                Moeilijk();
                moeilijk.Visibility = Visibility.Visible;
                makkelijk.Visibility = Visibility.Hidden;
            }
        }
        public void Makkelijk()
        {
            int Min = 0;
            int Max = 20;

          
            int[] getal = new int[10];
            string[] symbool = new string[2]{"+", "-"};

            Random randNum = new Random();
            for (int i = 0; i < getal.Length; i++)
            {
                getal[i] = randNum.Next(Min, Max);
            }
            vraag1.Content = (getal[0] + " " + symbool[0] + " " + getal[1]);
            vraag2.Content = (getal[2] + " " + symbool[1] + " " + getal[3]);
            vraag3.Content = (getal[4] + " " + symbool[0] + " " + getal[5]);
            vraag4.Content = (getal[6] + " " + symbool[1] + " " + getal[7]);
            vraag5.Content = (getal[8] + " " + symbool[0] + " " + getal[9]);

        }
        public void Moeilijk()
        {
            index = 0;
            Random rnd = new Random();
            do
            {
                index = rnd.Next(0, keuzevragen.Count - 1);
            } while (vragenGeschiedenis.Contains(index));
            vragenGeschiedenis.Add(index);

            KeuzeVraag keuzevraag = keuzevragen[index];
            lblVraag.Content = keuzevraag.Vraag;

            radioBtnGrid.Children.Clear();
            radioBtnGrid.RowDefinitions.Clear();

            for (int i = 0; i < keuzevraag.Keuzes.Count; i++)
            {
                RadioButton antwoordbtn = new RadioButton();
                antwoordbtn.Tag = i;
                antwoordbtn.Content = keuzevraag.Keuzes[i];
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(45);
                radioBtnGrid.RowDefinitions.Add(row);
                Grid.SetRow(antwoordbtn, i);
                radioBtnGrid.Children.Add(antwoordbtn);
            }
        }
        private int getAntwoord()
        {
            foreach (RadioButton button in radioBtnGrid.Children)
            {
                if (button.IsChecked == true)
                {
                    return (int)button.Tag;
                }
            }

            return -1;
        }

        // Naar volgende vraag of naar het resultaat te gaan
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KeuzeAntwoord antwoord = new KeuzeAntwoord();
            int gekozenAntwoord = getAntwoord();
            if (gekozenAntwoord == -1)
            {
                string messageBoxText = "Je heb geen antwoord aangeduid! Duid een antwoord aan om naar de volgende vraag te gaan!";
                string caption = "Geen antwoord";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                antwoord.Antwoord = gekozenAntwoord;
                antwoord.Index = index;
                keuzeAntwoorden.Add(antwoord);
                if (vragenGeschiedenis.Count >= 5)
                {
                    Resultaat resultaatWindow = new Resultaat("Wiskunde");
                    resultaatWindow.Vragen = keuzevragen;
                    resultaatWindow.Antwoorden = keuzeAntwoorden;
                    resultaatWindow.Show();
                    IODatabase resultaatKennis = new IODatabase("Wiskunde");
                }
                else if (vragenGeschiedenis.Count == 4)
                {
                    volgendeBtn.Content = "Resultaat";
                    Moeilijk();
                }
                else
                {
                    Moeilijk();
                }
            }
        }
        public int Graad
        {
            get { return graad; }
            set { graad = value; }
        }
    }

}
