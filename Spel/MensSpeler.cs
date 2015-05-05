using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace leren.Spel
{
    class MensSpeler: SpelEntiteit,IBeweegbaar
    {
        //Aanmaak van een blokje dat de gebruiker kan besturen
        //Date: 25/04/2014 15:03
        //Author: Samy Coenen     

        private int _score;
        public MensSpeler()
        {
            VeranderKleur(new SolidColorBrush(Colors.Blue));
            _score = 0;
        }

        private int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        //Deze methode wordt niet gebruikt maar kan gebruikt worden om de MensSpeler automatisch te laten bewegen
        public void Beweeg(Canvas spelCanvas, List<ComputerSpeler> csList, MensSpeler msSpeler)
        {
            bool geraakt = Geraakt(csList, msSpeler,spelCanvas);
            Point positie = new Point(Positie().X + XVerplaatsing, Positie().Y + YVerplaatsing);
            if (positie.X > spelCanvas.Width - Grootte || positie.X < 0 || geraakt)
            {
                XVerplaatsing = -XVerplaatsing;
            }
            if (positie.Y > spelCanvas.Height - Grootte || positie.Y < 0 || geraakt)
            {
                YVerplaatsing = -YVerplaatsing;
            }
            se.Margin = new Thickness(positie.X, positie.Y, 0, 0);
        }

        public void Beweeg(Canvas spelCanvas, Key ingedrukteKnop)
        {
            Point positie1 = Positie();
            switch (ingedrukteKnop)
            {
                case Key.Left:
                    if (positie1.X - XVerplaatsing * Snelheid >= 0) se.Margin = new Thickness(positie1.X - XVerplaatsing * Snelheid, positie1.Y, 0, 0);
                    break;
                case Key.Right:
                    if (positie1.X + XVerplaatsing * Snelheid +Grootte <= spelCanvas.Width) se.Margin = new Thickness(positie1.X + XVerplaatsing * Snelheid, positie1.Y, 0, 0);
                    break;
                case Key.Up:
                    if (positie1.Y - YVerplaatsing * Snelheid >= 0) se.Margin = new Thickness(positie1.X, positie1.Y - YVerplaatsing * Snelheid, 0, 0);
                    break;
                case Key.Down:
                    if (positie1.Y + YVerplaatsing * Snelheid+Grootte <= spelCanvas.Height) se.Margin = new Thickness(positie1.X, positie1.Y + YVerplaatsing * Snelheid, 0, 0);
                    break;
                default:
                    return;
            }
        }

        public void Maakvrij(Canvas spelCanvas)
        {
            spelCanvas.Children.Remove(se);   
        }
    }
}
