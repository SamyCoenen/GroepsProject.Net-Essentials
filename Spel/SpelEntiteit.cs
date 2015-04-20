using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace leren
{
    //De superclasse voor alle bewegenden objecten van het spel
    //Date: 16/04/2014 20:48
    //Author: Samy Coenen
    abstract class SpelEntiteit
    {
        private int snelheid = 1;
        private Rectangle cs;
        public SpelEntiteit()
        {
            
            cs = new Rectangle();
            cs.Height = 25;
            cs.Width = 25;
        }

        
        public void Teken(Canvas spelCanvas)
        {
            spelCanvas.Children.Add(cs);
        }
        public int Snelheid
        {
            get
            {
                return snelheid;
            }
            set
            {
                snelheid = value;
            }
        }
        public bool Geraakt { get; set; }
        public Point Positie { get; set; }
        
    }
}
