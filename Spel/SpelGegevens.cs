using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace leren.Spel
{
    //Met deze klasse kunnen gegevens in verband met het spel bekomen worden en ze ook veranderen door weg te schrijven
    //Date: 06/05/2014 23:03
    //Author: Samy Coenen

    class SpelGegevens
    {

        private List<int> _highScores;
        private List<string> _namen;
        private List<int> _levens;
        private string _bestand = "../../Data/spelgegevens.txt";

        public SpelGegevens()
        {
            _namen = new List<string>();
            _highScores = new List<int>();
            _levens = new List<int>();
            StreamReader inputStream = null;
            try
            {
                inputStream = File.OpenText(_bestand);
                string line = inputStream.ReadLine();
                while (line != null)
                {
                    string[] lijneDeel = line.Split('$');
                    _namen.Add(lijneDeel[0]);
                    _highScores.Add(Convert.ToInt32(lijneDeel[1]));
                    _levens.Add(Convert.ToInt32(lijneDeel[2]));
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

        public void VoegSpelerToe(string student)
        {
            _namen.Add(student);
            _highScores.Add(0);
            _levens.Add(3);
        }

        public void WegSchrijven()
        {
            StreamWriter outputStream = null;
            try
            {
                outputStream = new StreamWriter(_bestand);
                for (int i = 0; i < _namen.Count; i++)
                {
                    outputStream.WriteLine(_namen[i] + "$" + _highScores[i] + "$" + _levens[i]);
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

        public void UpdateHighScore(int punten)
        {
            int score = HighScore[Naam.IndexOf(Properties.Settings.Default.userName)];
            if (score < punten)
            {
                _highScores[Naam.IndexOf(Properties.Settings.Default.userName)] = punten;
            }
            MessageBox.Show("Game Over! U score was: " + punten + ", uw vorige highscore: " + score);
        }

        public void VoegLevenToe()
        {
            _levens[Naam.IndexOf(Properties.Settings.Default.userName)]++;
        }

        public List<int> HighScore
        {
            get { return _highScores; }
            set { _highScores = value; }
        }

        public List<string> Naam
        {
            get { return _namen; }
            set { _namen = value; }
        }

        public List<int> Levens
        {
            get { return _levens; }
            set { _levens = value; }
        }
    }
}
