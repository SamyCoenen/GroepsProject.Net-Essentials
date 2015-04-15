using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace leren
{
    class MensSpeler
    {
        //Aanmaak van een blokje dat de gebruiker kan besturen
        //Date: 16/04/2014 23:03
        //Author: Samy Coenen

        private int snelheid=1;
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
