using System;
using System.Collections.Generic;
using System.Linq;
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
    // TalenMenu window
    // Date: 05/05/15 - Last edit: 05/05/15
    // Author: Timothy Vanderaerden

    public partial class TalenMenu : Window
    {
        public TalenMenu()
        {
            InitializeComponent();
        }

        // Talen quiz openen
        private void Image_MouseDown(object sender, RoutedEventArgs e)
        {
            int graad = (int)graadSlider.Value;
            Taal talenWindow = new Taal();
            talenWindow.Graad = (int)graadSlider.Value;
            talenWindow.Show();
        }

    }
}