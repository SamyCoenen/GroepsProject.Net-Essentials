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
    class ComputerSpeler
    {
        //Aanmaak van een blokje dat de gebruiker kan besturen
        //Date: 16/04/2014 23:08
        //Author: Samy Coenen
        private int snelheid=1;
        public ComputerSpeler(Canvas spelCanvas)
        {
        Rectangle cs = new Rectangle();
        cs.Height = 25;
        cs.Width = 25;
        cs.Fill=new SolidColorBrush(Colors.Red);
        spelCanvas.Children.Add(cs);
        }
    }
}
