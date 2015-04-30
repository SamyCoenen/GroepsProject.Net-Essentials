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
            int aantalGebotst=0;
            foreach (UIElement element in spelCanvas.Children)
            {              
                    Rectangle se = element as Rectangle;
                    if ((Positie().X <= (se.Margin.Left + se.Width) && Positie().X >= se.Margin.Left) && Positie().Y <= (se.Margin.Top + se.Height) && Positie().Y >= se.Margin.Top)
                    {
                        aantalGebotst++; 
                        //Hij controleerd zichzelf altijd 1 keer maar we willen weten of een ander object op die locatie is
                        if (aantalGebotst>1){
                            return true;
                        }
                        
                    }                      
            }
            return false;
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
