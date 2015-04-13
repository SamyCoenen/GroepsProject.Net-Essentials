using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leren.Algemeen
{
    class GebruikersLijst
    {
        private List<string> naam;
        private List<string> wachtwoord;
        public GebruikersLijst()
        {
            string[] lines = File.ReadAllLines("../../Data/Logins.txt");
            naam = new List<string>();
            wachtwoord = new List<string>();
            foreach (string line in lines)
            {
                int scheiding = line.IndexOf("$");                
                naam.Add(line.Substring(0, scheiding));
                wachtwoord.Add(line.Substring(scheiding + 1, line.Length - scheiding-1));               
            }           
        }

        public bool Controle(string naam,string wachtwoord)
        {
            if (this.naam.IndexOf(naam)!=-1&&wachtwoord.Equals(this.wachtwoord[this.naam.IndexOf(naam)]))
            {
                return true;
            }
            else
            {
                return false;
            }
                   
        }
    }
}
