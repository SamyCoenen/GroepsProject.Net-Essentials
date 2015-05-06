using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using leren.Spel;

namespace leren
{
    //De abstracte superklasse voor alle bewegenden objecten van het spel
    //Date: 30/03/2014 20:03
    //Author: Samy Coenen
    abstract class SpelEntiteit
    {
        private double _snelheid = 5.0;
        private double _xChange = 5;
        private double _yChange = 5;
        protected Rectangle se;
        private int _grootte = 20;
        private static readonly Random r1 = new Random();
        
        public SpelEntiteit()
        {
            se = new Rectangle();
            se.Height = _grootte;
            se.Width = _grootte;
        }

        public void Teken(Canvas spelCanvas, double x, double y)
        {
            se.Margin = new Thickness(x, y, 0, 0);
            spelCanvas.Children.Add(se);
        }

        public void Teken(Canvas spelCanvas, List<ComputerSpeler> csList, MensSpeler msSpeler,Label speLabel)
        {
            se.Margin = new Thickness(0, r1.Next(0, Convert.ToInt32(spelCanvas.Height - _grootte)), 0, 0);                      
            spelCanvas.Children.Add(se);
        }

        public void VeranderKleur(SolidColorBrush kleur)
        {
            se.Fill = kleur;
        }

        public string Kleur()
        {
            return Convert.ToString(se.Fill);
        }

        public double Snelheid
        {
            get { return _snelheid; }
            set { _snelheid = value; }
        }

        public bool Geraakt(List<ComputerSpeler> csList,int index, MensSpeler msSpeler,Canvas spelCanvas,Label scoreLabel)
        {
            Point positieHuidig = Positie();
            Rect rect1 = new Rect(positieHuidig.X + _xChange, positieHuidig.Y + _yChange, _grootte, _grootte);
            for (int i=0;i<csList.Count;i++)
            {
                Point positieComputer = csList[i].Positie();
                Rect rect2 = new Rect(positieComputer.X + csList[i].YVerplaatsing, positieComputer.Y + csList[i].YVerplaatsing, _grootte, _grootte);                 
                //Bepalen of huidige SpelEntiteit met een vierhoek ComputerSpeler botst behalve zichzelf
                   if (rect1.IntersectsWith(rect2)&&positieHuidig!=positieComputer)
                   {                   
                       if (Kleur() == "#FF008000")
                       {
                         VeranderKleur(new SolidColorBrush(Colors.Black));
                       }
                       else if (Kleur() == "#FF000000")
                       {
                           VeranderKleur(new SolidColorBrush(Colors.Green));
                       }
                           return true;                      
                    }                      
            }
            Point positieMens = msSpeler.Positie();
            Rect rect3 = new Rect(positieMens.X, positieMens.Y, _grootte, _grootte);
            if (rect1.IntersectsWith(rect3) && positieHuidig != positieMens)
            {
                if (Kleur() == "#FF008000")
                {
                    msSpeler.VeranderKleur(new SolidColorBrush(Colors.White));
                }
                else if (Kleur() == "#FF000000")
                {
                    scoreLabel.Content = Convert.ToString(Convert.ToInt32(scoreLabel.Content) + 1);
                    spelCanvas.Children.Remove(se);
                    csList.RemoveAt(index);
                }
                return true;
            }   
            return false;
        }

        public Point Positie()
        {
            return new Point(se.Margin.Left, se.Margin.Top);     
        }

        public int Grootte
        {
            get { return _grootte; }
            set { _grootte = value; }
        }

        public double XVerplaatsing
        {
            get { return _xChange; }
            set { _xChange = value; }
        }        

        public double YVerplaatsing
        {
            get { return _yChange; }
            set { _yChange = value; }
        }
    }
}
