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
    // Date: 03/04/15 - Last edit: 08/04/15
    // Author: Timothy Vanderaerden

    public partial class KennisMenu : Window
    {
        public KennisMenu()
        {
            InitializeComponent();
        }

        // Open quiz window
        private void Image_MouseDown(object sender, RoutedEventArgs e)
        {
            int graad = (int)graadSlider.Value;
            switch (((Image)sender).Name)
            {
                case "kennis":
                    Kennis kennisWindow = new Kennis();
                    kennisWindow.Graad = (int)graadSlider.Value;
                    kennisWindow.Show();
                    break;
                case "aarde":
                    Aardrijkskunde aardrijkskundeWindow = new Aardrijkskunde();
                    aardrijkskundeWindow.Graad = (int)graadSlider.Value;
                    aardrijkskundeWindow.Show();
                    break;
            }
        }

    }
}
