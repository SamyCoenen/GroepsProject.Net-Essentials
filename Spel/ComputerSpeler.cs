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
            
        }
        public void Beweeg()
        {

            Positie = Point.Add(Positie, new Vector(40, 40));    
       
        }
        public void Maakvrij()
        {
          
        }
    }
}
