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
using System.Windows.Shapes;
using leren.Spel;

namespace leren
{
    // KennisQuiz window
    // Date: 03/04/15 - Last edit: 06/04/15
    // Author: Timothy Vanderaerden
    
    public partial class Kennis : Window
    {

        private int graad;
        private List<KeuzeVraag> keuzevragen = new List<KeuzeVraag>();
        private List<int> vragenGeschiedenis = new List<int>();
        private List<KeuzeAntwoord> keuzeAntwoorden = new List<KeuzeAntwoord>();
        private int index;

        public Kennis()
        {
            InitializeComponent();         
            Loaded+=Kennis_Loaded;
            
        }

        //Een parameter toegevoegd bij het aanmaken van IODatabase
        //Author: Samy Coenen
        //Date: 11/04/2015 15:04
        private void Kennis_Loaded(object sender, RoutedEventArgs e)
        {
            IODatabase database = new IODatabase("kennis");
            keuzevragen = database.ReadKeuzeVragenByGraad(graad);
            VolgendeVraag();
        }

        // Volgende vraag nemen
        private void VolgendeVraag()
        {
            index = 0;
            Random rnd = new Random();
            do
            {
                index = rnd.Next(0, keuzevragen.Count -1); 
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
                antwoordbtn.FontSize = 15;
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(45);
                radioBtnGrid.RowDefinitions.Add(row);
                Grid.SetRow(antwoordbtn, i);
                radioBtnGrid.Children.Add(antwoordbtn);
            }
        }

        // Return gegeven antwoord index
        private int getAntwoord()
        {
            foreach (RadioButton button in radioBtnGrid.Children) {
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
            if(gekozenAntwoord == -1) 
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
                    SpelGegevens infoSpel = new SpelGegevens();
                    infoSpel.VoegLevenToe();
                    infoSpel.WegSchrijven();
                    Resultaat resultaatWindow = new Resultaat("Kennis");
                    resultaatWindow.Vragen = keuzevragen;
                    resultaatWindow.Antwoorden = keuzeAntwoorden;
                    resultaatWindow.Show();
                    IODatabase resultaatKennis = new IODatabase("Kennis");
                    resultaatKennis.SchrijfResultaat(keuzevragen, keuzeAntwoorden, Properties.Settings.Default.userName, graad, "kennis");
                }
                else if (vragenGeschiedenis.Count == 4)
                {
                    volgendeBtn.Content = "Resultaat";
                    VolgendeVraag();
                }
                else
                {
                    VolgendeVraag();
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
