using System.Collections.Generic;
using System.IO;

namespace leren.Algemeen
{
    class GebruikersLijst
    {
        private List<string> _naam;      
        private List<string> _wachtwoord;
        public GebruikersLijst(string gebruiker)
        {
            string[] lines = File.ReadAllLines("../../Data/"+gebruiker+"logins.txt");
            _naam = new List<string>();
            _wachtwoord = new List<string>();
            foreach (string line in lines)
            {
                int scheiding = line.IndexOf("$");                
                _naam.Add(line.Substring(0, scheiding));
                _wachtwoord.Add(line.Substring(scheiding + 1, line.Length - scheiding-1));               
            }           
        }

        public bool Controle(string naam,string wachtwoord)
        {
            //Controleren of de velden "naam" en "wachtwoord" ingevuld zijn.
            if (naam.Length == 0 || wachtwoord.Length == 0)
            {
               //errorLabel.Visibility = System.Windows.Visibility.Visible;
                //errorLabel.Text = "U moet een naam en wachtwoord ingeven";
                throw new LoginException("U moet een naam en wachtwoord ingeven");
            }
            //controleren of de credentials juist zijn en vervolgens juiste window tonen.
            if (this._naam.IndexOf(naam)!=-1&&wachtwoord.Equals(this._wachtwoord[this._naam.IndexOf(naam)]))
            {
                return true;
            }
            else
            {
                return false;
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
