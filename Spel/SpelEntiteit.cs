using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace leren
{
    //De superclasse voor alle bewegenden objecten van het spel
    //Date: 16/04/2014 20:48
    //Author: Samy Coenen
    class SpelEntiteit
    {
        private int snelheid = 1;
        private bool Geraakt;
        private Point Positie;
        private string Kleur;

        public int snelheid { get; set; }
        public bool Geraakt { get; set; }
        public Point Positie { get; set; }
        public string Kleur { get; set; }
    }
}
