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
    /// <summary>
    /// Interaction logic for WiskundeMenu.xaml
    /// </summary>
    public partial class WiskundeMenu : Window
    {
        public WiskundeMenu()
        {
            InitializeComponent();

        }
        // Wiskunde oefeningen openen
        private void Image_MouseDown(object sender, RoutedEventArgs e)
        {
            int graad = (int)graadSlider.Value;
            Wiskunde wiskundeWindow = new Wiskunde();
            wiskundeWindow.Graad = (int)graadSlider.Value;
            wiskundeWindow.Show();
        }
    }
}
