using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace leren
{
    //Dit is het inlogscherm
    //Date: 27/03/2014 21:40
    //Author: Samy Coenen
    public partial class Student : Window
    {

        public Student()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Wanneer studentenscherm afgesloten word, moet ook de applicatie volledig afsluiten.
            MessageBoxResult result = MessageBox.Show("Bent u zeker dat u deze applicatie wilt sluiten?", "Sluiten van applicatie", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Image_MouseDown(object sender, RoutedEventArgs e)
        {

            switch (((Image)sender).Name)
            {
                case "talen":
                    TalenMenu talenMenuWindow = new TalenMenu();
                    talenMenuWindow.Show();
                    break;
                case "wiskunde":
                    WiskundeMenu wiskundeMenuWindow = new WiskundeMenu();
                    wiskundeMenuWindow.Show();
                    break;
                case "kennis":
                    KennisMenu kennisWindow = new KennisMenu();
                    kennisWindow.Show();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "spel":
                    SpelWindow spel = new SpelWindow();
                    spel.Show();
                    break;
                case "Resultaten":

                    break;
                case "Afsluiten":
                    this.Close();
                    break;
            }
        }



    }
}
