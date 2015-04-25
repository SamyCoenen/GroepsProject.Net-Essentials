using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using leren.Spel;
using System.Windows.Input;
using System.Windows;

namespace leren
{
    class MensSpeler: SpelEntiteit,IBeweegbaar
    {
        //Aanmaak van een blokje dat de gebruiker kan besturen
        //Date: 25/04/2014 15:03
        //Author: Samy Coenen           
        public MensSpeler():base(new SolidColorBrush(Colors.Blue))
        {

        }
        public void Beweeg(Canvas spelCanvas, int indexOfChild,Key ingedrukteKnop){
            switch (ingedrukteKnop)
            {
                case Key.Left:
                    Console.WriteLine(Canvas.GetLeft(spelCanvas.Children[indexOfChild]));
                    if (Canvas.GetLeft(spelCanvas.Children[indexOfChild]) >= 0) Canvas.SetLeft(spelCanvas.Children[indexOfChild], Positie.X - Snelheid);
                    break;
                case Key.Right:
                     Canvas.SetLeft(spelCanvas.Children[indexOfChild], Positie.X + Snelheid);
                    break;
                case Key.Up:
                    if (Canvas.GetTop(spelCanvas.Children[indexOfChild]) >= 0) Canvas.SetTop(spelCanvas.Children[indexOfChild], Positie.Y - Snelheid);
                    break;
                case Key.Down:
                    Canvas.SetTop(spelCanvas.Children[indexOfChild], Positie.Y + Snelheid);
                    break;
                default: 
                    return;
            }
            Positie = new Point(Canvas.GetLeft(spelCanvas.Children[indexOfChild]), Canvas.GetTop(spelCanvas.Children[indexOfChild]));
        }
        public void Maakvrij()
        {

        }
    }
}
