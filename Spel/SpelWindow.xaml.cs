using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace leren
{
    /// <summary>
    /// Interaction logic for SpelWindow.xaml
    /// </summary>
    public partial class SpelWindow : Window
    {
        public SpelWindow()
        {
            InitializeComponent();
            ComputerSpeler cs = new ComputerSpeler();
            cs.Teken(ballenSpel);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer("../../Kernkraft.wav");
           
            sp.Play();
            
        }
    }
}
