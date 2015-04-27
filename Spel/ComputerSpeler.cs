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

        public ComputerSpeler(): base(new SolidColorBrush(Colors.Green))
        {
            
        }
        public void Beweeg(Canvas spelCanvas, int index)
        {
            Positie = new Point(Canvas.GetLeft(spelCanvas.Children[index]),Canvas.GetTop(spelCanvas.Children[index]));

            if (Positie.X > spelCanvas.Width - 40 || Positie.X < 0)
            {
                Snelheid = Snelheid * (-1);
            }
            Canvas.SetLeft(spelCanvas.Children[index], Positie.X + Snelheid);
        }

        public void Maakvrij(Canvas spelCanvas,int index)
        {
            spelCanvas.Children.Remove(spelCanvas.Children[index]);
        }
    }
}
