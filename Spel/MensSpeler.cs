using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace leren.Spel
{

    //Aanmaak van een blokje dat de gebruiker kan besturen
    //Date: 25/04/2014 15:03
    //Author: Samy Coenen    

    class MensSpeler: SpelEntiteit,IBeweegbaar
    {

        public MensSpeler()
        {
            VeranderKleur(new SolidColorBrush(Colors.Blue));
        }

        //Deze methode wordt niet gebruikt maar kan gebruikt worden om de MensSpeler automatisch te laten bewegen
        public void Beweeg(Canvas spelCanvas, List<ComputerSpeler> csList,List<ComputerSpeler> oudeComputerSpelers,int index, MensSpeler msSpeler, Label scoreLabel)
        {
            bool geraakt = Geraakt(csList,oudeComputerSpelers,index, msSpeler,spelCanvas,scoreLabel);
            Point positie = new Point(Positie().X + XVerplaatsing, Positie().Y + YVerplaatsing);
            if (positie.X > spelCanvas.Width - Grootte || positie.X < 0 || geraakt)
            {
                XVerplaatsing = -XVerplaatsing;
            }
            if (positie.Y > spelCanvas.Height - Grootte || positie.Y < 0 || geraakt)
            {
                YVerplaatsing = -YVerplaatsing;
            }
            rechthoek.Margin = new Thickness(positie.X, positie.Y, 0, 0);
        }

        public void Beweeg(Canvas spelCanvas, Key ingedrukteKnop)
        {
            Point positie1 = Positie();
            switch (ingedrukteKnop)
            {
                case Key.Left:
                    if (positie1.X - XVerplaatsing * Snelheid >= 0) rechthoek.Margin = new Thickness(positie1.X - XVerplaatsing * Snelheid, positie1.Y, 0, 0);
                    break;
                case Key.Right:
                    if (positie1.X + XVerplaatsing * Snelheid +Grootte <= spelCanvas.Width) rechthoek.Margin = new Thickness(positie1.X + XVerplaatsing * Snelheid, positie1.Y, 0, 0);
                    break;
                case Key.Up:
                    if (positie1.Y - YVerplaatsing * Snelheid >= 0) rechthoek.Margin = new Thickness(positie1.X, positie1.Y - YVerplaatsing * Snelheid, 0, 0);
                    break;
                case Key.Down:
                    if (positie1.Y + YVerplaatsing * Snelheid+Grootte <= spelCanvas.Height) rechthoek.Margin = new Thickness(positie1.X, positie1.Y + YVerplaatsing * Snelheid, 0, 0);
                    break;
                default:
                    return;
            }
        }

        public void Maakvrij(Canvas spelCanvas)
        {
            spelCanvas.Children.Remove(rechthoek);   
        }
    }
}
