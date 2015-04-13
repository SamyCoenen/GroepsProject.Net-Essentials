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
    // KennisMenu window
    // Date: 03/04/15 - Last edit: 06/04/15
    // Author: Timothy Vanderaerden

    public partial class KennisMenu : Window
    {
        public KennisMenu()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Kennis kennisWindow = new Kennis();
            kennisWindow.Graad = (int)graadSlider.Value;
            kennisWindow.Show();
        }

       

    }
}
