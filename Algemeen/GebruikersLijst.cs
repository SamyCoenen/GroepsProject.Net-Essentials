using System.Collections.Generic;
using System.IO;

namespace leren.Algemeen
{
    //Deze klasse is nodig om al de gebruikergegevens te controleren/aan te passen
    //Date: 16/04/2014 20:48
    //Author: Samy Coenen
    class GebruikersLijst
    {
        private List<string> _naam;
        private List<string> _wachtwoord;
        public GebruikersLijst(string gebruiker)
        {
            string[] lines = File.ReadAllLines("../../Data/" + gebruiker + "logins.txt");
            _naam = new List<string>();
            _wachtwoord = new List<string>();
            foreach (string line in lines)
            {
                int scheiding = line.IndexOf("$");
                _naam.Add(line.Substring(0, scheiding));
                _wachtwoord.Add(line.Substring(scheiding + 1, line.Length - scheiding - 1));
            }
        }

        public void Controle(string naam, string wachtwoord)
        {
            //Controleren of de velden "naam" en "wachtwoord" ingevuld zijn.
            if (naam.Length == 0 || wachtwoord.Length == 0)
            {
                throw new LoginException("U moet een naam en wachtwoord ingeven");
            }
            else if (_naam.IndexOf(naam) == -1)
            {
                throw new LoginException("Deze naam bestaat niet");
            }
            else if (!wachtwoord.Equals(_wachtwoord[_naam.IndexOf(naam)]))
            {
                throw new LoginException("Uw naam of wachtwoord is niet juist");
            }
        }

        // Marnic
        public List<string> Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }
        public List<string> Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; }
        }
    }
}
