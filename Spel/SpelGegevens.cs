using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leren.Spel
{
    class SpelGegevens
    {

        private List<int> _highScore;
        private List<string> _naam;
        private List<int> _levens; 

        public SpelGegevens()
        {
            string[] lines = File.ReadAllLines("../../Data/spelgegevens.txt");
            _naam = new List<string>();
            _highScore = new List<int>();
            _levens = new List<int>();
            foreach (string line in lines)
            {
                int scheiding = line.IndexOf("$");
                _naam.Add(line.Substring(0, scheiding));
               // _highScore.Add(line.Substring(scheiding + 1, line.Length - scheiding - 1));
            }
        }
    }
}
