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

    //Het spelscherm met de knoppen en het canvas voor alle bewegenden objecten
    //Date: 30/03/2014 19:03
    //Author: Samy Coenen

    public partial class SpelWindow : Window
    {
        private List<ComputerSpeler> csLijst;
        private MensSpeler ms;
        private SoundPlayer sp;
        private DispatcherTimer spelKlok;
        private DispatcherTimer nieuweSpeler;

        public SpelWindow()
        {
            InitializeComponent();
            csLijst = new List<ComputerSpeler>();
            ms = new MensSpeler();
            ms.Teken(ballenSpel, csLijst, ms);
            sp = new SoundPlayer("../../SPEL_shortversion.wav");
            spelKlok = new DispatcherTimer();
            nieuweSpeler = new DispatcherTimer();
            spelKlok.Tick += spelKlok_Tick;
            spelKlok.Interval = new TimeSpan(10000000 / 60);            
            nieuweSpeler.Tick += nieuweSpeler_Tick;
            nieuweSpeler.Interval = new TimeSpan(0,0,10);
            sp.PlayLooping();
        }

        //We willen om de 10 seconden een nieuwe ComputerSpeler aanmaken
        void nieuweSpeler_Tick(object sender, EventArgs e)
        {
            ComputerSpeler cs = new ComputerSpeler();
            cs.Teken(ballenSpel,csLijst,ms);
            csLijst.Add(cs);
            if (nieuweSpeler.Interval.Seconds > 2)
            {
                nieuweSpeler.Interval=new TimeSpan(0,0,nieuweSpeler.Interval.Seconds - 1);
            }
        }

        void spelKlok_Tick(object sender, EventArgs e)
        {          
            //Zodra de MensSpeler wit is, is het spel gedaan en moet het gereset worden
            if (ms.Kleur() == "#FFFFFFFF")
            {              
                Reset();
            }
            List<ComputerSpeler> oudeComputerSpelers = new List<ComputerSpeler>();
            oudeComputerSpelers.AddRange(csLijst);
            for (int i = 0; i < csLijst.Count(); i++)
            {
                csLijst[i].Beweeg(ballenSpel,csLijst,oudeComputerSpelers,i, ms,scoreLabel);
            }           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                //We starten het spel starten door de ComputerSpelers aan te maken per 10 seconden met een DispatcherTimer en ze dan ook te laten bewegen
                //We willen ook eerst controleren of er nog levens zijn
                case "Start/Pauze":
                    if (spelKlok.IsEnabled == false)
                    {
                        SpelGegevens spelInfo = new SpelGegevens();
                        levensLabel.Content = "levens: "+spelInfo.Levens[spelInfo.Naam.IndexOf(Properties.Settings.Default.userName)];
                        if (spelInfo.Levens[spelInfo.Naam.IndexOf(Properties.Settings.Default.userName)] > 0)
                        {
                            spelKlok.Start();
                            nieuweSpeler.Start();
                            if (csLijst.Count == 0)
                            {
                                //Om ervoor te zorgen dat er niet pas na 10 seconden maar nu direct een ComputerSpeler wordt toegevoegd voeren we de tick ook al direct eens uit
                                nieuweSpeler_Tick(sender, e);
                            }
                            //Zet focus op het Canvas zodat de menselijke speler kan bewegen met het toetsenbord
                            ballenSpel.Focus();
                            if (nieuweSpeler.Interval.Seconds < 10)
                            {
                                nieuweSpeler.Interval = new TimeSpan(0, 0, 10);
                            }
                        }
                        else
                        {
                            MessageBox.Show("U hebt 0 levens, maak een oefening om terug 1 leven te hebben");
                        }                      
                    }
                    else
                    {
                        //Stop de timers zodat de beweging stops en er geen nieuwe ComputerSpelers bijkomen
                        spelKlok.Stop();
                        nieuweSpeler.Stop();
                    }
                    break;
                case "Reset":
                    Reset();
                    break;
                case "Menu":
                    //Sluit window en toon mainmenu(Student.xaml)
                    Show();
                    Close();
                    break;
                case "Mute":
                    //Stop de muziek
                    sp.Stop();
                    break;
            }
        }

        private void OnCanvasKeyDown(object sender, KeyEventArgs e)
        {
            //Bewegen van MensSpeler na er een toets is ingedrukt
            ms.Beweeg(ballenSpel, e.Key);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Stop de muziek en de timers omdat dit andere threads zijn dan de Window waardoor ze niet automatisch stoppen
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
            SpelGegevens gegevens = new SpelGegevens();
            gegevens.UpdateHighScore(Convert.ToInt32(scoreLabel.Content));
            gegevens.Levens[gegevens.Naam.IndexOf(Properties.Settings.Default.userName)] -= 1;
            levensLabel.Content = "levens: " + gegevens.Levens[gegevens.Naam.IndexOf(Properties.Settings.Default.userName)];
            gegevens.WegSchrijven();
            spelKlok.Stop();
            nieuweSpeler.Stop();      
            for (int i = 0; i < csLijst.Count; i++)
            {
                csLijst[i].Maakvrij(ballenSpel);
            }
            csLijst.Clear();
            ms.Maakvrij(ballenSpel);
            ms = new MensSpeler();
            ms.Teken(ballenSpel,500,200); 
            MessageBox.Show("Game Over! U score was: " + scoreLabel.Content + ", uw vorige highscore: " + gegevens.HighScore[gegevens.Naam.IndexOf(Properties.Settings.Default.userName)]);
            scoreLabel.Content = 0;
        }
    }
}
