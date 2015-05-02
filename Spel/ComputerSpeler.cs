using leren.Spel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace leren
{
    class ComputerSpeler: SpelEntiteit, IBeweegbaar
    {
        //Aanmaak van een blokje dat de gebruiker kan besturen
        //Date: 15/04/2014 23:08
        //Author: Samy Coenen

        public ComputerSpeler()
        {
            VeranderKleur(new SolidColorBrush(Colors.Green));
        }

        public void Beweeg(Canvas spelCanvas)
        {
            bool geraakt = Geraakt(spelCanvas);
            Point positie = new Point(Positie().X + XVerplaatsing, Positie().Y +YVerplaatsing);
            if (positie.X > spelCanvas.Width - Grootte || positie.X < 0||geraakt == true)
            {
                XVerplaatsing = -XVerplaatsing;
            }
            if (positie.Y > spelCanvas.Height - Grootte|| positie.Y< 0 || geraakt == true)
            {
                YVerplaatsing = -YVerplaatsing;
            }         
            se.Margin = new Thickness(positie.X, positie.Y, 0, 0);
        }

        public void Maakvrij(Canvas spelCanvas,int index)
        {
            spelCanvas.Children.Remove(se);
            //this.Draw.Dispose();
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}
