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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using leren.Algemeen;
namespace leren
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class leerkrachtVenster : Window
    {
        public leerkrachtVenster()
        {
            InitializeComponent();
            GebruikersLijst lijst = new GebruikersLijst("student");           
            Combobox1.ItemsSource = lijst.Naam;
            vakkenListBox.Items.Add("Talen - Makkelijk");
            vakkenListBox.Items.Add("Talen - Moeilijk");
            vakkenListBox.Items.Add("Kennis - Makkelijk");
            vakkenListBox.Items.Add("Kennis - Moeilijk");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void combobox1(object sender, RoutedEventArgs e)
        {
        //    try
        //    {
               
        //      StreamReader sr = new StreamReader ("C:\Users\11400126\Desktop");

        //        string line = sr.ReadLine();

        //        while (line != null)
        //        {
        //            Console.WriteLine(line);
        //        }
        //    }
                
               
        //        catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
            
        }

        // Vakken Listbox + declareren oefeninglistbox | Timothy Vanderaerden
        private void vakkenListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            oefeningListBox.Items.Clear();
            vraagTextBox.IsEnabled = false;
            antwoordenListBox.IsEnabled = false;
            juisteTextBox.IsEnabled = false;
            switch (vakkenListBox.SelectedIndex)
            {
                case 0:
                    string[] linesTaal1 = File.ReadAllLines("../../Data/taalvragen_0.txt");
                    foreach (string line in linesTaal1)
                    {
                        int deelEinde = line.IndexOf("-");
                        string oefening = line.Substring(0, deelEinde);
                        oefeningListBox.Items.Add(oefening.ToString());
                    }
                    break;
                case 1:
                    break;
                case 2:
                    string[] linesKennis1 = File.ReadAllLines("../../Data/kennisvragen_0.txt");
                    foreach (string line in linesKennis1)
                    {
                        int deelEinde = line.IndexOf("-");
                        string oefening = line.Substring(0, deelEinde);
                        oefeningListBox.Items.Add(oefening.ToString());
                    }
                    break;
                case 3:
                    break;
            }
        }

        // oefeninglistbox | Timothy Vanderaerden
        private void oefeningListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] lines;
            antwoordenListBox.Items.Clear();
            vraagTextBox.IsEnabled = false;
            antwoordenListBox.IsEnabled = false;
            juisteTextBox.IsEnabled = false;
            switch (vakkenListBox.SelectedIndex)
            {
                case 0:
                    lines = File.ReadAllLines("../../Data/taalvragen_0.txt");
                    ToonVakOefening(lines);
                    break;
                case 1:
                    lines = File.ReadAllLines("../../Data/taalvragen_1.txt");
                    ToonVakOefening(lines);
                    break;
                case 2:
                    lines = File.ReadAllLines("../../Data/kennisvragen_0.txt");
                    ToonVakOefening(lines);
                    break;
                case 3:
                    lines = File.ReadAllLines("../../Data/kennisvragen_1.txt");
                    ToonVakOefening(lines);
                    break;
            }
        }

        // Toonvakoefening methode | Timothy Vanderaerden
        private void ToonVakOefening(string[] lines)
        {
            int deelEinde = lines[oefeningListBox.SelectedIndex].IndexOf("-");
            string vraag = lines[oefeningListBox.SelectedIndex].Substring(0, deelEinde);
            vraagTextBox.Text = Convert.ToString(vraag);
            int deelBegin = deelEinde + 1;
            while ((deelEinde = lines[oefeningListBox.SelectedIndex].IndexOf("$", deelBegin)) != -1)
            {
                antwoordenListBox.Items.Add(lines[oefeningListBox.SelectedIndex].Substring(deelBegin, (deelEinde - deelBegin)));
                deelBegin = deelEinde + 1;
            }
            int juist = Int32.Parse(lines[oefeningListBox.SelectedIndex].Substring(deelBegin, lines[oefeningListBox.SelectedIndex].Length - deelBegin));
            juisteTextBox.Text = juist.ToString();
        }

        // Timothy Vanderaerden
        private void nieuwButton_Click(object sender, RoutedEventArgs e)
        {
            if (vakkenListBox.SelectedIndex < 0)
            {
                string messageBoxText = "U hebt geen vak aangeduid, gelieve een vak aanteduiden!";
                string caption = "Geen vak geselecteerd";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            } 
            else
            {
                vraagTextBox.Clear();
                antwoordenListBox.Items.Clear();
                juisteTextBox.Clear();
                vraagTextBox.IsEnabled = true;
                antwoordenListBox.IsEnabled = true;
                juisteTextBox.IsEnabled = true;

            }
        }

        // Timothy Vanderaerden
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (oefeningListBox.SelectedIndex < 0)
            {
                string messageBoxText = "U hebt geen oefening aangeduid, gelieve een vak aanteduiden!";
                string caption = "Geen vak geselecteerd";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                vraagTextBox.IsEnabled = true;
                antwoordenListBox.IsEnabled = true;
                juisteTextBox.IsEnabled = true;

            }
        }
    }
}

