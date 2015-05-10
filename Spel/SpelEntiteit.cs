using System;
using System.Collections.Generic;
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
        protected Rectangle rechthoek;
        private int _grootte = 20;
        private static readonly Random r1 = new Random();

        public SpelEntiteit()
        {
            rechthoek = new Rectangle();
            rechthoek.Height = _grootte;
            rechthoek.Width = _grootte;
        }

        public void Teken(Canvas spelCanvas, double x, double y)
        {
            rechthoek.Margin = new Thickness(x, y, 0, 0);
            spelCanvas.Children.Add(rechthoek);
        }

        public void Teken(Canvas spelCanvas, List<ComputerSpeler> csLijst, MensSpeler msSpeler)
        {
            rechthoek.Margin = new Thickness(0, r1.Next(0, Convert.ToInt32(spelCanvas.Height - _grootte)), 0, 0);
            while (Geraakt(csLijst, msSpeler))
            {
                rechthoek.Margin = new Thickness(0, r1.Next(0, Convert.ToInt32(spelCanvas.Height - _grootte)), 0, 0);  
            }
            spelCanvas.Children.Add(rechthoek);
        }

        //We controleren of een SpelEntiteit botst tegen een andere SpelEntiteit
        public bool Geraakt(List<ComputerSpeler> csLijst,List<ComputerSpeler> oudeComputerSpelers, int indexInLijst, MensSpeler msSpeler, Canvas spelCanvas, Label scoreLabel)
        {
            Point positieHuidig = Positie();
            //We maken een Rect object om de methode IntersectsWith te kunnen gebruiken
            Rect rect1 = new Rect(positieHuidig.X + _xChange, positieHuidig.Y + _yChange, _grootte, _grootte);
            for (int i = 0; i < oudeComputerSpelers.Count; i++)
            {
                Point positieComputer = oudeComputerSpelers[i].Positie();
                Rect rect2 = new Rect(positieComputer.X + oudeComputerSpelers[i].XVerplaatsing, positieComputer.Y + oudeComputerSpelers[i].YVerplaatsing, _grootte, _grootte);
                //IntersectsWith is een methode die bepaalt of de huidige SpelEntiteit ComputerSpeler botst behalve zichzelf
                if (rect1.IntersectsWith(rect2) && positieHuidig != positieComputer)
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
                    //De SpelEntiteit is tegen de MensSpeler gebotst terwijl hij groen was en daarom verandert de msSpeler van kleur waardoor het spel stopt
                    msSpeler.VeranderKleur(new SolidColorBrush(Colors.White));
                }
                else if (Kleur() == "#FF000000")
                {                
                    scoreLabel.Content = Convert.ToString(Convert.ToInt32(scoreLabel.Content) + 1);
                    spelCanvas.Children.Remove(rechthoek);
                    csLijst.RemoveAt(indexInLijst);
                }
                return true;
            }
            return false;
        }

        //Deze geraakt methode wordt gebruikt om te controleren of de plaats al bezet is wanneer er nieuwe SpelEntiteiten worden aangemaakt
        public bool Geraakt(List<ComputerSpeler> csLijst, MensSpeler msSpeler)
        {
            Point positieHuidig = Positie();
            Rect rect1 = new Rect(positieHuidig.X + _xChange, positieHuidig.Y + _yChange, _grootte, _grootte);
            for (int i = 0; i < csLijst.Count; i++)
            {
                Point positieComputer = csLijst[i].Positie();
                Rect rect2 = new Rect(positieComputer.X + csLijst[i].XVerplaatsing, positieComputer.Y + csLijst[i].YVerplaatsing, _grootte, _grootte);
                if (rect1.IntersectsWith(rect2) && positieHuidig != positieComputer)
                {
                    return true;
                }
            }
            Point positieMens = msSpeler.Positie();
            Rect rect3 = new Rect(positieMens.X, positieMens.Y, _grootte, _grootte);
            if (rect1.IntersectsWith(rect3) && positieHuidig != positieMens)
            {
                return true;
            }
            return false;
        }

        public void VeranderKleur(SolidColorBrush kleur)
        {
            rechthoek.Fill = kleur;
        }

        public string Kleur()
        {
            return Convert.ToString(rechthoek.Fill);
        }

        public Point Positie()
        {
            return new Point(rechthoek.Margin.Left, rechthoek.Margin.Top);
        }

        public double Snelheid
        {
            get { return _snelheid; }
            set { _snelheid = value; }
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
