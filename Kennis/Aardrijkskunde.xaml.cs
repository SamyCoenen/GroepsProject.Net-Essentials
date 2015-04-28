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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace leren
{
    // Aardrijkskunde window
    // Date: 08/04/15 - Last edit: 14/04/15
    // Author: Timothy Vanderaerden

    public partial class Aardrijkskunde : Window
    {
        private int graad;
        string[] landenList = new string[5]{"België", "Nederland", "Spanje", "Duitsland", "Frankrijk"};
        string[] stedenList = new string[5]{ "Brussel", "Amsterdam", "Madrid", "Berlijn", "Parijs" };

        public Aardrijkskunde()
        {
            InitializeComponent();
            Loaded+=Aarderijkskunde_Loaded;
        }

        private void Aarderijkskunde_Loaded(object sender, RoutedEventArgs e)
        {
            Moeilijk(graad);
            for (int i = 0; i < landenList.Length; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = landenList[i].ToString();
                landen.Items.Add(itm);
            }
        }

        private void landen_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
                if (landen.SelectedItems.Count > 0)
                {
                    ListBoxItem mySelectedItem = landen.SelectedItem as ListBoxItem;
                    if (mySelectedItem != null)
                    {
                        DragDrop.DoDragDrop(landen, mySelectedItem.Content.ToString(), DragDropEffects.Copy);
                    }

                }
        }

        private void steden_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (steden.SelectedItems.Count > 0)
            {
                ListBoxItem mySelectedItem = steden.SelectedItem as ListBoxItem;
                if (mySelectedItem != null)
                {
                    DragDrop.DoDragDrop(steden, mySelectedItem.Content.ToString(), DragDropEffects.Copy);
                }

            }
        }

        private void land_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        private void land_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void land_Drop(object sender, DragEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            lb.Items.Clear();
            error.Content = "";
            string tstring;
            tstring = e.Data.GetData(DataFormats.StringFormat).ToString();
            lb.Items.Add(tstring.ToString());

            for (int i = 0; i < stedenList.Length; i++) {
                if (lb.Items.Contains(stedenList[i].ToString()))
                {
                    lb.Items.Clear();
                    error.Content = "Dit is geen land!";
                }
            }
        }

        private void stad_Drop(object sender, DragEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            lb.Items.Clear();
            error.Content = "";
            string tstring;
            tstring = e.Data.GetData(DataFormats.StringFormat).ToString();
            lb.Items.Add(tstring.ToString());

            for (int i = 0; i < landenList.Length; i++)
            {
                if (lb.Items.Contains(landenList[i].ToString()))
                {
                    lb.Items.Clear();
                    error.Content = "Dit is geen stad!";
                }
            }
        }

        private void drop_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
        
        }

        public int Graad
        {
            get { return graad; }
            set { graad = value; }
        }

        private void Moeilijk(int graad)
        {
            if (graad == 1)
            {
                stedenGrid.Visibility = Visibility.Visible;
                for (int i = 0; i < stedenList.Length; i++)
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = stedenList[i].ToString();
                    steden.Items.Add(itm);
                }
            }
        }

        private void Resultaat(object sender, RoutedEventArgs e)
        {
            //if (graad == 0) {
            //    if (land1box.Items.Count == 0)
            //    {

            //    }
            //    else
            //    {

            //    }
            //} else 
            //{

            //}
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            //if (graad == 0)
            //{
            //    if ()
            //}
        }
    }
}