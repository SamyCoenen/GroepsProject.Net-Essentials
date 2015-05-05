using System.Linq.Expressions;
using System.Windows;
using leren.Algemeen;
namespace leren
{
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
            try
            {
                gebruikers.Controle(naamTextBox.Text, wachtwoordPasswordBox.Password);
                Hide();
                if (gebruiker.Equals("student"))
                {
                    Properties.Settings.Default.userName = naamTextBox.Text;
                    Properties.Settings.Default.Save();
                    Student leerling = new Student();
                    leerling.Show();
                }
                else
                {
                    leerkrachtVenster leerkracht = new leerkrachtVenster();
                    leerkracht.Show();
                }
            }
            catch (LoginException ex)
            {
                //Een error geven bij verkeerde credentials.
                errorLabel.Visibility = System.Windows.Visibility.Visible;
                errorLabel.Text = ex.Message;
            }
        }

        private void studentRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            naamTextBox.Focus();
        }      
    }
}
