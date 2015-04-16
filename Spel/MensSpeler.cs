using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using leren.Spel;

namespace leren
{
    class MensSpeler: SpelEntiteit,IBeweegbaar
    {
        //Aanmaak van een blokje dat de gebruiker kan besturen
        //Date: 15/04/2014 23:03
        //Author: Samy Coenen
       
        public MensSpeler(Canvas spelCanvas)
        {
            Rectangle ms = new Rectangle();
            ms.Height=25;
            ms.Width = 25;            
            ms.Fill = new SolidColorBrush(Colors.Black);
            spelCanvas.Children.Add(ms);
        }
    }
}
