﻿using System.Windows;
using leren.Spel;

namespace leren.Algemeen
{

    //Gebruikers kunnen zicht hier registreren 
    //Date: 07/05/2014 00:03
    //Author: Samy Coenen

    public partial class StudentToevoegen : Window
    {
        private string gebruiker;
        public StudentToevoegen(string gebruiker)
        {
            InitializeComponent();
            this.gebruiker=gebruiker;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GebruikersLijst l1 = new GebruikersLijst(gebruiker);
            if (l1.Naam.Contains(naamTextBox.Text) == false)
            {
                l1.Wachtwoord.Add(wachtwoordPasswordBox.Password);
                l1.Naam.Add(naamTextBox.Text);
                l1.WegSchrijven();
                SpelGegevens spelInfo = new SpelGegevens();
                spelInfo.VoegSpelerToe(naamTextBox.Text);
                spelInfo.WegSchrijven();
                MessageBox.Show("U heeft een gebruiker toegevoegd met de naam " + naamTextBox.Text);            
                MainWindow login = new MainWindow();
                login.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Deze gebruikersnaam is al in gebruik");
            }          
        }
    }
}
