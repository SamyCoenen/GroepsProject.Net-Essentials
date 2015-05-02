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
        public MensSpeler()
        {
            VeranderKleur(new SolidColorBrush(Colors.Blue));
        }

        public void Beweeg(Canvas spelCanvas)
        {
            bool geraakt = Geraakt(spelCanvas);
            Point positie = new Point(Positie().X + XVerplaatsing, Positie().Y + YVerplaatsing);
            if (positie.X > spelCanvas.Width - Grootte || positie.X < 0 || geraakt == true)
            {
                XVerplaatsing = -XVerplaatsing;
            }
            if (positie.Y > spelCanvas.Height - Grootte || positie.Y < 0 || geraakt == true)
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
                    if (positie1.X-XVerplaatsing*3 >= 0) se.Margin = new Thickness(positie1.X-XVerplaatsing*3, positie1.Y, 0, 0);
                    break;
                case Key.Right:
                    if (positie1.X + XVerplaatsing*3 <= spelCanvas.Width) se.Margin = new Thickness(positie1.X + XVerplaatsing*3, positie1.Y, 0, 0);
                    break;
                case Key.Up:
                    if (positie1.Y - YVerplaatsing*3 >= 0) se.Margin = new Thickness(positie1.X, positie1.Y-YVerplaatsing*3, 0, 0);
                    break;
                case Key.Down:
                    if (positie1.Y + YVerplaatsing*3 <= spelCanvas.Width) se.Margin = new Thickness(positie1.X, positie1.Y+YVerplaatsing*3, 0, 0);
                    break;
                default:
                    return;
            }
        }

        public void Maakvrij(Canvas spelCanvas, int index)
        {
            spelCanvas.Children.Remove(spelCanvas.Children[index]);
        }
    }
}
