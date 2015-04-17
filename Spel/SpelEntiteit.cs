using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace leren
{
    //De superclasse voor alle bewegenden objecten van het spel
    //Date: 16/04/2014 20:48
    //Author: Samy Coenen
    abstract class SpelEntiteit
    {
        private int snelheid = 1;
        private Rectangle cs;
        public SpelEntiteit()
        {
            DispatcherTimer spelKlok = new DispatcherTimer();
            spelKlok.Interval = new TimeSpan(0, 0, 0, 0, snelheid * 100);
            spelKlok.Tick += spelKlok_Tick;
            spelKlok.Start();
            cs = new Rectangle();
            cs.Height = 25;
            cs.Width = 25;
        }

        void spelKlok_Tick(object sender, EventArgs e)
        {

        }
        public void Teken(Canvas spelCanvas)
        {
            spelCanvas.Children.Add(cs);
        }
        public int Snelheid
        {
            get
            {
                return snelheid;
            }
            set
            {
                snelheid = value;
            }
        }
        public bool Geraakt { get; set; }
        public Point Positie { get; set; }
        //    public string kleur
        //    {
        //        get 
        //        { 
        //            return cs.; 
        //        }
        //        set 
        //        { 

        //            cs.Fill = new SolidColorBrush(Colors.value); 
        //}
    }
}
