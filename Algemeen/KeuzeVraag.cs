using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leren
{
    // Get and set Keuzevragen
    // Date: 01/04/15 - Last edit: 02/04/15
    // Author: Timothy Vanderaerden

    class KeuzeVraag
    {
        private string vraag;
        private List<string> keuzes;
        private int juistIndex;

        public KeuzeVraag(string vraag, List<string> keuzes, int juistIndex)
        {
            Vraag = vraag;
            Keuzes = keuzes;
            JuistIndex = juistIndex;
        }

        public string getAntwoord()
        {
            return keuzes[juistIndex];
        }

        public string Vraag
        {
            get { return vraag; }
            set { vraag = value; }
        }

        public List<string> Keuzes
        {
            get { return keuzes; }
            set { keuzes = value; }
        }

        public int JuistIndex
        {
            get { return juistIndex; }
            set { juistIndex = value; }
        }

    }
}
