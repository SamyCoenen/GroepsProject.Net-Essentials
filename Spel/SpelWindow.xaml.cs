using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using leren.Spel;

namespace leren
{
    //Het scherm met de knoppen en het canvas voor alle bewegenden objecten van het spel
    //Date: 30/03/2014 19:03
    //Author: Samy Coenen
    public partial class SpelWindow : Window
    {
        private List<ComputerSpeler> csList = new List<ComputerSpeler>();
        private MensSpeler ms;
        private SoundPlayer sp = new SoundPlayer("../../Kernkraft.wav");
        private DispatcherTimer spelKlok = new DispatcherTimer();
        private DispatcherTimer nieuweSpeler = new DispatcherTimer();
        private int totaalScore = 0;
        public SpelWindow()
        {
            InitializeComponent();
            ms = new MensSpeler();
            ms.Teken(ballenSpel, csList, ms);

            spelKlok.Tick += spelKlok_Tick;
            spelKlok.Interval = new TimeSpan(10000000 / 60);
            
            nieuweSpeler.Tick += nieuweSpeler_Tick;
            nieuweSpeler.Interval = new TimeSpan(0,0,10);
            sp.PlayLooping();
        }

        void nieuweSpeler_Tick(object sender, EventArgs e)
        {
            ComputerSpeler cs = new ComputerSpeler();
            cs.Teken(ballenSpel,csList,ms);
            csList.Add(cs);
        }

        void spelKlok_Tick(object sender, EventArgs e)
        {          
            if (ms.Kleur() == "#FFFFFFFF")
            {
                MessageBox.Show("Game Over! U score was: " + totaalScore);
                Reset();
            }
            for (int i = 0; i < csList.Count(); i++)
            {
                csList[i].Beweeg(ballenSpel, csList, ms);
            }           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                case "Start/Pauze":
                    if (spelKlok.IsEnabled == false)
                    {
                        //We starten het spel door de ComputerSpelers aan te maken per 10 seconden met een DispatcherTimer en ze dan ook te laten bewegen
                        spelKlok.Start();
                        nieuweSpeler.Start();
                        if (csList.Count == 0)
                        {
                            //Om ervoor te zorgen dat er niet pas na 10 seconden maar nu direct een ComputerSpeler wordt toegevoegd voeren we de tick ook al direct eens uit
                            //Ook willen we niet dat wanneer men de start knop meermaals indrukt dat er geen ComputerSpelers bijkomen
                            nieuweSpeler_Tick(sender, e); 
                        }
                        //zet focus op het canvas zodat de menselijke speler kan bewegen met het toetsenbord
                        ballenSpel.Focus();
                    }
                    else
                    {
                        //Stop de timer
                        spelKlok.Stop();
                        nieuweSpeler.Stop();
                    }
                    break;
                case "Reset":
                    Reset();
                    break;
                case "Menu":
                    //Sluit current window en toon mainmenu   
                    Show();
                    Close();
                    break;
                case "Mute":
                    //stop de muziek
                    sp.Stop();
                    break;
            }
        }

        private void OnCanvasKeyDown(object sender, KeyEventArgs e)
        {
            //Bewegen na toets ingedrukt
            ms.Beweeg(ballenSpel, e.Key);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Stop de muziek en de timers omdat dit andere threads zijn dan window
            sp.Stop();
            if (spelKlok.IsEnabled)
            {
                spelKlok.Stop();
            }
            if (nieuweSpeler.IsEnabled)
            {
                nieuweSpeler.Stop();
            }
        }

        private void Reset()
        {
            spelKlok.Stop();
            nieuweSpeler.Stop();
            for (int i = 0; i < csList.Count; i++)
            {
                csList[i].Maakvrij(ballenSpel);
            }
            csList.Clear();
            ms.Maakvrij(ballenSpel);
            ms = new MensSpeler();
            ms.Teken(ballenSpel, csList, ms);
        }
    }
}
