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
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
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
            switch (vakkenListBox.SelectedIndex)
            {
                case 0:
                    fileName = "taalvragen_0.txt";
                    ToonOefeningen();
                    break;
                case 1:
                    break;
                case 2:
                    fileName = "kennisvragen_0.txt";
                    ToonOefeningen();
                    break;
                case 3:
                    break;
            }
            DisableElements();
        }

        // oefeninglistbox | Timothy Vanderaerden
        private void oefeningListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToonVakOefening();
            DisableElements();
        }

        // methoden om oefeninglistbox te vullen | Timothy Vanderaerden
        private void ToonOefeningen()
        {
            string[] lines = File.ReadAllLines("../../Data/" + fileName);
            foreach (string line in lines)
            {
                int deelEinde = line.IndexOf("-");
                string oefening = line.Substring(0, deelEinde);
                oefeningListBox.Items.Add(oefening.ToString());
            }

        }

        // Toonvakoefening gegevens methode | Timothy Vanderaerden
        private void ToonVakOefening()
        {
            string[] lines;
            lines = File.ReadAllLines("../../Data/" + fileName);
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

        // Verwijder alle value (als deze er is) | Timothy Vanderaerden
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
                EnableElements();
            }
        }

        // Edit button - Enable elements wanneer er een oefening is aangeduid | Timothy Vanderaerden
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
                EnableElements();
            }
        }

        // Methode om elements inteschakelen | Timothy Vanderaerden
        private void EnableElements()
        {
            vraagTextBox.IsEnabled = true;
            antwoordenListBox.IsEnabled = true;
            juisteTextBox.IsEnabled = true;
            antwoordToevoegenButton.IsEnabled = true;
            verwijderAntwoordButton.IsEnabled = true;
            antwoordTextBox.IsEnabled = true;
            addButton.IsEnabled = true;
            deleteButton.IsEnabled = true;
        }

        // Methode om elements uitteschakelen | Timothy Vanderaerden
        private void DisableElements()
        {
            vraagTextBox.IsEnabled = false;
            antwoordenListBox.IsEnabled = false;
            juisteTextBox.IsEnabled = false;
            antwoordToevoegenButton.IsEnabled = false;
            verwijderAntwoordButton.IsEnabled = false;
            antwoordTextBox.IsEnabled = false;
            addButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
        }

        // Antwoord toevoegen | Timothy Vanderaerden
        private void antwoordToevoegenButton_Click(object sender, RoutedEventArgs e)
        {
            antwoordenListBox.Items.Add(antwoordTextBox.Text.ToString());
            antwoordTextBox.Clear();
        }


        // Antwoord verwijderen | Timothy Vanderaerden
        private void verwijderAntwoordButton_Click(object sender, RoutedEventArgs e)
        {
            antwoordenListBox.Items.RemoveAt(antwoordenListBox.SelectedIndex);
        }

        // Verwijder alle gegevens van een oefening | Timothy Vanderaerden
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (vraagTextBox.Text.Count() > 0 && antwoordenListBox.Items.IsEmpty != true && juisteTextBox.Text.Count() > 0)
            {
                MessageBoxResult result = MessageBox.Show("Bent u zeker dat u deze gegevens wilt verwijderen! De oefening zal dan verwijdert worden. Dit kan niet ongedaan gemaakt worden!", "Deze oefening verwijderen?", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    IODatabase database = new IODatabase("");
                    database.VerwijderOefening(oefeningListBox.SelectedIndex, fileName);
                    vraagTextBox.Clear();
                    antwoordTextBox.Clear();
                    antwoordenListBox.Items.Clear();
                    juisteTextBox.Clear();
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (vraagTextBox.Text.Count() > 0 && antwoordenListBox.Items.IsEmpty != true && juisteTextBox.Text.Count() > 0)
            {
                string[] antwoorden = new string[antwoordenListBox.Items.Count];
                for (int i = 0; i < antwoordenListBox.Items.Count; i++) 
                {
                    antwoorden[i] = antwoordenListBox.Items[i].ToString();
                }
                int juist = 0;
                while (juisteTextBox.Text.ToString() != antwoordenListBox.Items[juist].ToString())
                {
                    juist++;
                }
                IODatabase database = new IODatabase("");
                database.schrijfOefening(vraagTextBox.Text.ToString(), antwoorden, juist, fileName);
                DisableElements();
                vraagTextBox.Clear();
                antwoordenListBox.Items.Clear();
                juisteTextBox.Clear();
            }
            else
            {
                string messageBoxText = "U hebt niet alles ingevuld. Gelieve alles intevullen";
                string caption = "Lege velden";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

        }
    }
}

