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
using System.Windows.Threading;

namespace leren
{
    /// <summary>
    /// Interaction logic for SpelWindow.xaml
    /// </summary>
    public partial class SpelWindow : Window
    {
        private List<ComputerSpeler> cs = new List<ComputerSpeler>();
        private SoundPlayer sp = new SoundPlayer("../../Kernkraft.wav");
        public SpelWindow()
        {
            InitializeComponent();
            ComputerSpeler cs = new ComputerSpeler();
            cs.Teken(ballenSpel);
            this.cs.Add(cs);
            DispatcherTimer spelKlok = new DispatcherTimer();
            spelKlok.Tick+=spelKlok_Tick;
            spelKlok.Interval = new TimeSpan(0, 0, 0, 0, 500);
            sp.Play();
        }
        void spelKlok_Tick(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
