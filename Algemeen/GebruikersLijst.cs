using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace leren.Algemeen
{
    //Deze klasse is gebruikt om al de gebruikergegevens te controleren/aan te passen
    //Date: 16/04/2014 20:48
    //Author: Samy Coenen
    class GebruikersLijst
    {

        private List<string> _namen;
        private List<string> _wachtwoorden;
        private string _bestand;

        public GebruikersLijst(string gebruiker)
        {
            _namen = new List<string>();
            _wachtwoorden = new List<string>();
            _bestand = "../../Data/" + gebruiker + "logins.txt";
            StreamReader inputStream = null;
            try
            {
                inputStream = File.OpenText(_bestand);
                string line = inputStream.ReadLine();
                //string[] lines = File.ReadAllLines("../../Data/" + gebruiker + "logins.txt");   
                while (line != null)
                {
                    int scheiding = line.IndexOf("$");
                    _namen.Add(line.Substring(0, scheiding));
                    _wachtwoorden.Add(line.Substring(scheiding + 1, line.Length - scheiding - 1));
                     line = inputStream.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Het gegevensbestand van het spel werd niet teruggevonden");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (inputStream != null)
                {
                    inputStream.Close();
                }
            }
        }

        public void Controle(string naam, string wachtwoord)
        {
            //Controleren of de velden "naam" en "wachtwoord" ingevuld zijn.
            if (naam.Length == 0 || wachtwoord.Length == 0)
            {
                throw new LoginException("U moet een naam en wachtwoord ingeven");
            }
            else if (_namen.IndexOf(naam) == -1)
            {
                throw new LoginException("Deze naam bestaat niet");
            }
            else if (!wachtwoord.Equals(_wachtwoorden[_namen.IndexOf(naam)]))
            {
                throw new LoginException("Uw naam of wachtwoord is niet juist");
            }
        }

        public void WegSchrijven()
        {
            StreamWriter outputStream = null;
            try
            {
                outputStream = new StreamWriter(_bestand);
                for (int i = 0; i < _namen.Count; i++)
                {
                    outputStream.WriteLine(_namen[i] + "$" + _wachtwoorden[i]);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Het gegevensbestand van het spel werd niet teruggevonden");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (outputStream != null)
                {
                    outputStream.Close();
                }
            }
        }

        // Marnic
        public List<string> Naam
        {
            get { return _namen; }
            set { _namen = value; }
        }
        public List<string> Wachtwoord
        {
            get { return _wachtwoorden; }
            set { _wachtwoorden = value; }
        }
    }
}
