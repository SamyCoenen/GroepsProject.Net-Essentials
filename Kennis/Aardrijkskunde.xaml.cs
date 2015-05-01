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
    // Date: 08/04/15 - Last edit: 28/04/15
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
            if (land1box.Items.Count == 0 && land2box.Items.Count == 0 && land3box.Items.Count == 0 && land4box.Items.Count == 0 && land5box.Items.Count == 0)
            {
                if (graad == 1)
                {
                    if (stad1box.Items.Count == 0 && stad2box.Items.Count == 0 && stad3box.Items.Count == 0 && stad4box.Items.Count == 0 && stad5box.Items.Count == 0)
                    {
                        string messageBoxText2 = Properties.Settings.Default.userName +  ", je heb geen land of stad versleept! Versleep de landen en steden naar het juiste land en druk vervolgens op resultaat.";
                        string caption2 = "Geen antwoord";
                        MessageBoxButton button2 = MessageBoxButton.OK;
                        MessageBoxImage icon2 = MessageBoxImage.Warning;
                        MessageBox.Show(messageBoxText2, caption2, button2, icon2);
                    }
                }
                else
                {
                    string messageBoxText = Properties.Settings.Default.userName + ", je heb geen land versleept! Versleep de landen en druk vervolgens op resultaat.";
                    string caption = "Geen antwoord";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            else
            {
                if (graad == 0)
                {
                    Resultaat_Makkelijk();
                }
                else
                {
                    Resultaat_Moeilijk();
                }
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (land1box.Items.Count == 0 && land2box.Items.Count == 0 && land3box.Items.Count == 0 && land4box.Items.Count == 0 && land5box.Items.Count == 0)
            {
                if (graad == 1)
                {
                    if (stad1box.Items.Count == 0 && stad2box.Items.Count == 0 && stad3box.Items.Count == 0 && stad4box.Items.Count == 0 && stad5box.Items.Count == 0)
                    {
                        WindowHelper close = new WindowHelper();
                        close.CloseWindows();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Bent u zeker dat u wilt stoppen? Je gegeven antwoorden worden niet opgeslagen!", "Je data zal verloren gaan", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                            WindowHelper close = new WindowHelper();
                            close.CloseWindows();
                        }
                        else
                        {
                            result = MessageBoxResult.No;
                        }
                    }
                }
                else
                {
                    WindowHelper close = new WindowHelper();
                    close.CloseWindows();
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Bent u zeker dat u wilt stoppen? Je gegeven antwoorden worden niet opgeslagen!", "Je data zal verloren gaan", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    WindowHelper close = new WindowHelper();
                    close.CloseWindows();
                }
                else
                {
                    result = MessageBoxResult.No;
                }
            }
        }

        private void Resultaat_Makkelijk()
        {
            int juist = 0;
            land1box.Foreground = Brushes.Red;
            land2box.Foreground = Brushes.Red;
            land3box.Foreground = Brushes.Red;
            land4box.Foreground = Brushes.Red;
            land5box.Foreground = Brushes.Red;

            if (land1box.Items.Contains(landenList[0]))
            {
                land1box.Foreground = Brushes.Green;
                juist++;
            }
            if (land2box.Items.Contains(landenList[1]))
            {
                land2box.Foreground = Brushes.Green;
                juist++;
            }
            if (land3box.Items.Contains(landenList[2]))
            {
                land3box.Foreground = Brushes.Green;
                juist++;
            }
            if (land4box.Items.Contains(landenList[3]))
            {
                land4box.Foreground = Brushes.Green;
                juist++;
            }
            if (land5box.Items.Contains(landenList[4]))
            {
                land5box.Foreground = Brushes.Green;
                juist++;
            }
        }

        private void Resultaat_Moeilijk()
        {
            double juist = 0;
            land1box.Foreground = Brushes.Red;
            land2box.Foreground = Brushes.Red;
            land3box.Foreground = Brushes.Red;
            land4box.Foreground = Brushes.Red;
            land5box.Foreground = Brushes.Red;

            stad1box.Foreground = Brushes.Red;
            stad2box.Foreground = Brushes.Red;
            stad3box.Foreground = Brushes.Red;
            stad4box.Foreground = Brushes.Red;
            stad5box.Foreground = Brushes.Red;

            if (land1box.Items.Contains(landenList[0]))
            {
                land1box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (land2box.Items.Contains(landenList[1]))
            {
                land2box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (land3box.Items.Contains(landenList[2]))
            {
                land3box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (land4box.Items.Contains(landenList[3]))
            {
                land4box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (land5box.Items.Contains(landenList[4]))
            {
                land5box.Foreground = Brushes.Green;
                juist += 0.5;
            }

            if (stad1box.Items.Contains(stedenList[0]))
            {
                stad1box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (stad2box.Items.Contains(stedenList[1]))
            {
                stad2box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (stad3box.Items.Contains(stedenList[2]))
            {
                stad3box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (stad4box.Items.Contains(stedenList[3]))
            {
                stad4box.Foreground = Brushes.Green;
                juist += 0.5;
            }
            if (stad5box.Items.Contains(stedenList[4]))
            {
                stad5box.Foreground = Brushes.Green;
                juist += 0.5;
            }
        }
    }
}