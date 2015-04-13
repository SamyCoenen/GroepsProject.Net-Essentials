using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leren
{
    // Get and set Keuzevragen
    // Date: 06/04/15 - Last edit: 06/04/15
    // Author: Timothy Vanderaerden

    class KeuzeAntwoord
    {
        private int niveau;
        private int index;
        private int antwoord;

        public int Niveau
        {
            get { return niveau; }
            set { niveau = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public int Antwoord
        {
            get { return antwoord; }
            set { antwoord = value; }
        }
    }
}
