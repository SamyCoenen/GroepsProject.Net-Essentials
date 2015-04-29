using leren.Spel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace leren
{
    class ComputerSpeler: SpelEntiteit, IBeweegbaar
    {
        //Aanmaak van een blokje dat de gebruiker kan besturen
        //Date: 15/04/2014 23:08
        //Author: Samy Coenen

        public ComputerSpeler()
        {
            veranderKleur(new SolidColorBrush(Colors.Green));
        }
        public void Beweeg(Canvas spelCanvas)
        {        
            if (Positie().X+ XVerplaatsing > spelCanvas.Width - Grootte || Positie().X + XVerplaatsing < 0)
            {
                XVerplaatsing = -XVerplaatsing;
            }
            if (Positie().Y + YVerplaatsing > spelCanvas.Height - Grootte || Positie().Y + YVerplaatsing < 0)
            {
                YVerplaatsing = -YVerplaatsing;
            }
            se.Margin = new Thickness(Positie().X + XVerplaatsing, Positie().Y + YVerplaatsing, 0, 0);
        }

        public void Maakvrij(Canvas spelCanvas,int index)
        {
            spelCanvas.Children.Remove(se);
        }
    }
}
