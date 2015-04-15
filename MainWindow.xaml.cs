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
using leren.Algemeen;
namespace leren
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Dit is het inlogscherm
        //Date: 27/03/2014 20:03
        //Author: Samy Coenen
        public MainWindow()
        {
            InitializeComponent();
            naamTextBox.Focus();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string gebruiker;
            
            if (studentRadioButton.IsChecked==true)
            {
                gebruiker = "student";
            }
            else
            {
                gebruiker = "leerkracht";
            }
            GebruikersLijst gebruikers = new GebruikersLijst(gebruiker);
            //Controleren of de velden "naam" en "wachtwoord" ingevuld zijn.
            if (naamTextBox.Text.Length == 0||wachtwoordPasswordBox.Password.Length==0)
            {
                errorLabel.Visibility = System.Windows.Visibility.Visible;
                errorLabel.Text = "U moet een naam en wachtwoord ingeven";
            }
            //controleren of de credentials juist zijn en vervolgens juiste window tonen.
            else if(gebruikers.Controle(naamTextBox.Text,wachtwoordPasswordBox.Password))
            {
                this.Hide();
                Student leerling = new Student();
                leerling.Show();
                
            }
            else
                //Een error geven bij verkeerde credentials.
            {
                errorLabel.Visibility = System.Windows.Visibility.Visible;
                errorLabel.Text = "Verkeerde naam of wachtwoord";
            }

        }
    }
}
