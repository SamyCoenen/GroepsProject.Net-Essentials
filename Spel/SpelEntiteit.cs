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
        private double snelheid = 10;
        private Rectangle se;

        public SpelEntiteit(SolidColorBrush kleur)
        {
            se = new Rectangle();
            se.Height = 40;
            se.Width = 40;
            se.Fill = kleur;
        }
        
        public void Teken(Canvas spelCanvas,double x,double y)
        {
            Canvas.SetLeft(se, x);
            Canvas.SetTop(se, y);
            spelCanvas.Children.Add(se);
        }
        public double Snelheid
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
    }
}
