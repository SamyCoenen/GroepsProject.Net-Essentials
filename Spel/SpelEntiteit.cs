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
        private double snelheid = 1.0;
        private double xChange = 5;
        private double yChange = 5;
        protected Rectangle se;
        private int grootte = 40;
        
        public SpelEntiteit()
        {
            se = new Rectangle();
            se.Height = grootte;
            se.Width = grootte;
        }

        public void Teken(Canvas spelCanvas, double x, double y)
        {
            Canvas.SetLeft(se, x);
            Canvas.SetTop(se, y);
            spelCanvas.Children.Add(se);
        }

        public void Teken(Canvas spelCanvas)
        {
            Random r1 = new Random();
            se.Margin = new Thickness(r1.Next(0, Convert.ToInt32(spelCanvas.Width-grootte)),r1.Next(0,Convert.ToInt32(spelCanvas.Height-grootte)),0,0);
            spelCanvas.Children.Add(se);
        }

        public void veranderKleur(SolidColorBrush kleur)
        {
            se.Fill = kleur;
        }

        public string Kleur()
        {
            return Convert.ToString(se.Fill);
        }

        public double Snelheid
        {
            get { return snelheid; }
            set { snelheid = value; }
        }

        public bool Geraakt(Canvas spelCanvas)
        {
            for (int i=1;i<=spelCanvas.Children.Count-2;i++){

            }
            return true;
        }

        public Point Positie()
        {
            return new Point(se.Margin.Left, se.Margin.Top);
            
        }

        public int Grootte
        {
            get { return grootte; }
            set { grootte = value; }
        }

        public double XVerplaatsing
        {
            get { return xChange; }
            set { xChange = value; }
        }        

        public double YVerplaatsing
        {
            get { return yChange; }
            set { yChange = value; }
        }
    }
}
