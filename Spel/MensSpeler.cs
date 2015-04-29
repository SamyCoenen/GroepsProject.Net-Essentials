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

        public void Beweeg(Canvas spelCanvas, int indexOfChild)
        {
            //if ((Positie.X <= 0) || (Positie.X >= (spelCanvas.Width - 40)))
            //{
            //    Snelheid = Snelheid*(-1);
            //}
            //if ((Positie.Y <= 0) || (Positie.Y >= spelCanvas.Height - 40))
            //{
               
            //    yChange = -yChange;
            //}
            //x = x + xChange;
            //y = y + yChange;
        }

        public void Beweeg(Canvas spelCanvas, int indexOfChild,Key ingedrukteKnop){
            Positie = new Point(Canvas.GetLeft(spelCanvas.Children[indexOfChild]), Canvas.GetTop(spelCanvas.Children[indexOfChild]));
            switch (ingedrukteKnop)
            {
                case Key.Left:
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
        }
        public void Maakvrij(Canvas spelCanvas, int index)
        {
            spelCanvas.Children.Remove(spelCanvas.Children[index]);
        }
    }
}
