using System.Windows;
using leren.Algemeen;
namespace leren
{
    //Dit is het inlogscherm
    //Date: 27/03/2014 20:03
    //Author: Samy Coenen
    public partial class MainWindow : Window
    {

        private string _gebruiker;

        public MainWindow()
        {
            InitializeComponent();
            naamTextBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GebruikersLijst gebruikers = new GebruikersLijst(_gebruiker);
            try
            {
                gebruikers.Controle(naamTextBox.Text, wachtwoordPasswordBox.Password);
                if (_gebruiker.Equals("student"))
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
                Close();
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
            if (studentRadioButton.IsChecked == true)
            {
                _gebruiker = "student";
            }
            else
            {
                _gebruiker = "leerkracht";
            }
            naamTextBox.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_gebruiker == "student")
            {
                StudentToevoegen registreer = new StudentToevoegen(_gebruiker);
                registreer.Show();
                Close();
            }            
        }
    }
}
