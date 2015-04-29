using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace leren
{
    /// <summary>
    /// Interaction logic for SpelWindow.xaml
    /// </summary>
    public partial class SpelWindow : Window
    {
        private List<ComputerSpeler> cs = new List<ComputerSpeler>();
        private MensSpeler ms;
        private SoundPlayer sp = new SoundPlayer("../../Kernkraft.wav");
        private DispatcherTimer spelKlok = new DispatcherTimer();
        public SpelWindow()
        {
            InitializeComponent();
            ms = new MensSpeler();
            ms.Teken(ballenSpel, 960, 350);
            ComputerSpeler cs = new ComputerSpeler();
            cs.Teken(ballenSpel, 0, 0);
            this.cs.Add(cs);

            spelKlok.Tick += spelKlok_Tick;
            spelKlok.Interval = new TimeSpan(10000000/60);
            sp.Play();
        }

        void spelKlok_Tick(object sender, EventArgs e)
        {
            cs[0].Beweeg(ballenSpel, 2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                case "Start/Stop":
                    if (spelKlok.IsEnabled == false)
                    {
                        //start the timer and starts the game
                        spelKlok.Start();
                        //set focus on the canvas
                        ballenSpel.Focus();
                    }
                    else
                    {
                        //stop the timer
                        spelKlok.Stop();
                    }   
                    break;
                case "Reset":
                    spelKlok.Stop();
                    for (int i = 2; i <= ballenSpel.Children.Count;i++ )
                    {
                        cs[i - 2].Maakvrij(ballenSpel, i);
                    }
                    break;
                case "Menu":
                     //close current window and show the mainmenu   
                                      base.Show();
                        this.Close();
                    break;
                case "Mute":
                    //stop the music playing
                     sp.Stop();
                    break;
            } 
        }


        private void OnCanvasKeyDown(object sender, KeyEventArgs e)
        {
            //move block with human input
            ms.Beweeg(ballenSpel, 1, e.Key);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //stop the music playing
            sp.Stop();
        }
    }
}
