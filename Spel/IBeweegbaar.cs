using System.Collections.Generic;
using System.Windows.Controls;

namespace leren.Spel
{
    //Een interface dient om andere classen te verplichten methodes the implementeren
    //Date: 16/04/2014 20:55
    //Author: Samy Coenen

    interface IBeweegbaar
    {
        void Beweeg(Canvas spelCanvas, List<ComputerSpeler> csList,List<ComputerSpeler> oudeComputerSpelers,int index, MensSpeler msSpeler,Label scoreLabel);
        void Maakvrij(Canvas spelCanvas);
    }
}
