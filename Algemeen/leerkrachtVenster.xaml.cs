﻿using System;
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
        private bool selectionChanged;
        public leerkrachtVenster()
        {
            InitializeComponent();
            GebruikersLijst lijst = new GebruikersLijst("student");
            leerlingCombobox.ItemsSource = lijst.Naam;
            vakkenComboBox.Items.Add("Talen - Makkelijk");
            vakkenComboBox.Items.Add("Talen - Moeilijk");
            vakkenComboBox.Items.Add("Kennis - Makkelijk");
            vakkenComboBox.Items.Add("Kennis - Moeilijk");
            vakkenComboBox.Items.Add("Wiskunde - Moeilijk");
        }





        // Vakken Listbox + declareren oefeninglistbox
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void vakkenComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (vakkenComboBox.SelectedIndex)
            {
                case 0:
                    selectionChanged = false;
                    oefeningComboBox.Items.Clear();
                    selectionChanged = true;
                    fileName = "taalvragen_0.txt";
                    ToonOefeningen();
                    break;
                case 1:
                    selectionChanged = false;
                    oefeningComboBox.Items.Clear();
                    selectionChanged = true;
                    fileName = "taalvragen_1.txt";
                    ToonOefeningen();
                    break;
                case 2:
                    selectionChanged = false;
                    oefeningComboBox.Items.Clear();
                    selectionChanged = true;
                    fileName = "kennisvragen_0.txt";
                    ToonOefeningen();
                    break;
                case 3:
                    selectionChanged = false;
                    oefeningComboBox.Items.Clear();
                    selectionChanged = true;
                    fileName = "kennisvragen_1.txt";
                    ToonOefeningen();
                    break;
                case 4:
                    selectionChanged = false;
                    oefeningComboBox.Items.Clear();
                    selectionChanged = true;
                    fileName = "wiskundevragen_1.txt";
                    ToonOefeningen();
                    break;
            }
            DisableElements();
        }

        // oefeninglistbox
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void oefeningComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Zorgt ervoor dat selectionchanged niet wordt opgeroepen wanneer niet nodig
            // Author: Timothy Vanderaerden - Date: 07/05/15 
            if (selectionChanged == false)
            {
                ComboBox combo = (ComboBox)sender;
                combo.SelectedItem = e.RemovedItems[0];
                ClearElements();
            }
            else
            {
                ToonVakOefening();
                DisableElements();
            }
        }

        // methoden om oefeninglistbox te vullen
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void ToonOefeningen()
        {
            string[] lines = File.ReadAllLines("../../Data/" + fileName);
            foreach (string line in lines)
            {
                int deelEinde = line.IndexOf("-");
                string oefening = line.Substring(0, deelEinde);
                oefeningComboBox.Items.Add(oefening.ToString());
            }

        }

        // Toonvakoefening gegevens methode
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void ToonVakOefening()
        {
            string[] lines;
            lines = File.ReadAllLines("../../Data/" + fileName);
            int deelEinde = lines[oefeningComboBox.SelectedIndex].IndexOf("-");
            string vraag = lines[oefeningComboBox.SelectedIndex].Substring(0, deelEinde);
            vraagTextBox.Text = Convert.ToString(vraag);
            int deelBegin = deelEinde + 1;
            while ((deelEinde = lines[oefeningComboBox.SelectedIndex].IndexOf("$", deelBegin)) != -1)
            {
                antwoordenListBox.Items.Add(lines[oefeningComboBox.SelectedIndex].Substring(deelBegin, (deelEinde - deelBegin)));
                deelBegin = deelEinde + 1;
            }
            int juist = Int32.Parse(lines[oefeningComboBox.SelectedIndex].Substring(deelBegin, lines[oefeningComboBox.SelectedIndex].Length - deelBegin));
            juisteTextBox.Text = juist.ToString();
        }

        // Verwijder alle value (als deze er is)
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void nieuwButton_Click(object sender, RoutedEventArgs e)
        {
            if (vakkenComboBox.SelectedIndex < 0)
            {
                string messageBoxText = "U hebt geen vak aangeduid, gelieve een vak aan te duiden!";
                string caption = "Geen vak geselecteerd";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                ClearElements();
                EnableElements();
            }
        }

        // Edit button - Enable elements wanneer er een oefening is aangeduid
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (oefeningComboBox.SelectedIndex < 0)
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

        // Antwoord toevoegen
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void antwoordToevoegenButton_Click(object sender, RoutedEventArgs e)
        {
            antwoordenListBox.Items.Add(antwoordTextBox.Text.ToString());
            antwoordTextBox.Clear();
        }


        // Antwoord verwijderen
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void verwijderAntwoordButton_Click(object sender, RoutedEventArgs e)
        {
            antwoordenListBox.Items.RemoveAt(antwoordenListBox.SelectedIndex);
        }

        // Verwijder alle gegevens van een oefening
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (vraagTextBox.Text.Count() > 0 && antwoordenListBox.Items.IsEmpty != true && juisteTextBox.Text.Count() > 0)
            {
                MessageBoxResult result = MessageBox.Show("Bent u zeker dat u deze gegevens wilt verwijderen! De oefening zal dan verwijdert worden. Dit kan niet ongedaan gemaakt worden!", "Deze oefening verwijderen?", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    IODatabase database = new IODatabase("");
                    database.VerwijderOefening(oefeningComboBox.SelectedIndex, fileName);
                    ClearElements();
                }
            }
        }

        // Een oefening toevoegen
        // Author: Timothy Vanderaerden - Date: 07/05/15 
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
                ClearElements();
            }
            else
            {
                string messageBoxText = "U hebt niet alles ingevuld. Gelieve alles in te vullen";
                string caption = "Lege velden";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

        }

        // Methode om elements inteschakelen
        // Author: Timothy Vanderaerden - Date: 07/05/15 
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

        // Methode om elements uitteschakelen
        // Author: Timothy Vanderaerden - Date: 07/05/15 
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

        // Methoden om alle elementen hun gegevens te wissen
        // Author: Timothy Vanderaerden - Date: 07/05/15 
        private void ClearElements()
        {
            vraagTextBox.Clear();
            antwoordenListBox.Items.Clear();
            antwoordTextBox.Clear();
            juisteTextBox.Clear();
        }


        //Een leerkracht toevoegen
        //Author: Samy Coenen
        //Date: 08/05/2015 14:54
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StudentToevoegen leerkrachtToevoegen = new StudentToevoegen("leerkracht");
            leerkrachtToevoegen.Show();
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (vakkenComboBox.SelectedIndex)
            {
                case 0:
                    selectionChanged = false;
                    oefeningComboBox.Items.Clear();
                    selectionChanged = true;
                    fileName = "kennisresultaat.txt";
                    ToonResultaten();
                    break;
                case 1:
                    break;
                case 2:
                    selectionChanged = false;
                    oefeningComboBox.Items.Clear();
                    selectionChanged = true;
                    fileName = "taalresultaat.txt";
                    ToonResultaten();
                    break;
                case 3:
                    break;
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            string line;


            //Enable elements wanneer er een oefening is aangeduid / kennisresultaat schrijven
            //Marnic Broux
            if (leerlingCombobox.SelectedIndex < 0)
            {
                string messageBoxText = "U hebt geen leerling aangeduid, gelieve een leerling aan te duiden!";
                string caption = "Geen leerling geselecteerd";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("../../Data/kennisresultaat.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(0, leerlingCombobox.SelectedItem.ToString().Length).Contains(leerlingCombobox.SelectedItem.ToString()))
                    {
                        leerlingListBox.Items.Add(line);
                    }

                }
                //Enable elements wanneer er een oefening is aangeduid / taalresultaat schrijven
                //Marnic Broux
            }
            if (leerlingCombobox.SelectedIndex < 0)
            {
                string messageBoxText = "U hebt geen leerling aangeduid, gelieve een leerling aan te duiden!";
                string caption = "Geen leerling geselecteerd";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("../../Data/taalresultaat.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(0, leerlingCombobox.SelectedItem.ToString().Length).Contains(leerlingCombobox.SelectedItem.ToString()))
                    {
                        leerlingListBox.Items.Add(line);
                    }

                }
                //Enable elements wanneer er een oefening is aangeduid / wiskunderesultaat schrijven
                //Marnic Broux
            }
            if (leerlingCombobox.SelectedIndex < 0)
            {
                string messageBoxText = "U hebt geen leerling aangeduid, gelieve een leerling aan te duiden!";
                string caption = "Geen leerling geselecteerd";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("../../Data/wiskunderesultaat.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(0, leerlingCombobox.SelectedItem.ToString().Length).Contains(leerlingCombobox.SelectedItem.ToString()))
                    {
                        leerlingListBox.Items.Add(line);
                    }

                }
                //Enable elements wanneer er een oefening is aangeduid / aardrijkskundeesultaat schrijven
                //Marnic Broux
            }
            if (leerlingCombobox.SelectedIndex < 0)
            {
                string messageBoxText = "U hebt geen leerling aangeduid, gelieve een leerling aan te duiden!";
                string caption = "Geen leerling geselecteerd";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("../../Data/aardrijkskunderesultaat.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(0, leerlingCombobox.SelectedItem.ToString().Length).Contains(leerlingCombobox.SelectedItem.ToString()))
                    {
                        leerlingListBox.Items.Add(line);
                    }

                }
            }


        }
        //resultaten weergeven in listbox
        //Marnic Broux
        private void leerlingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
            private void ShowResultaten()
        {
            string[] lines = File.ReadAllLines("../../Data/" + fileName);
            foreach (string line in lines)
            {
                int deelEinde = line.IndexOf("-");
                string oefening = line.Substring(0, deelEinde);
                oefeningComboBox.Items.Add(oefening.ToString());
            }

        
        }


        private void ToonResultaten()
        {
            string[] lines = File.ReadAllLines("../../Data/" + fileName);
            foreach (string line in lines)
            {
                int deelEinde = line.IndexOf(":");
                string oefening = line.Substring(0, deelEinde);
                oefeningComboBox.Items.Add(oefening.ToString());
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
            // leerling verwijderen uit document
            // Marnic Broux
             public void VerwijderLeerling(int index, string file)
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
        }
        }
        

      
    
