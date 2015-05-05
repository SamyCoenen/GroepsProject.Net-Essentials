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
                        string messageBoxText = Properties.Settings.Default.userName +  ", je heb geen land of stad versleept! Versleep de landen en steden naar het juiste land en druk vervolgens op resultaat.";
                        string caption = "Geen antwoord";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBox.Show(messageBoxText, caption, button, icon);
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
        }

        private void Resultaat_Makkelijk()
        {
            List<string> antwoorden = new List<string>{land1box.Items[0].ToString(), land2box.Items[0].ToString(), land3box.Items[0].ToString(), land4box.Items[0].ToString(), land5box.Items[0].ToString() };
            List<string> oplossingen = new List<string>(landenList);
            IODatabase database = new IODatabase("Aardrijkskunde");
            database.SchrijfResultaatAarderijkskunde(antwoorden, oplossingen, Properties.Settings.Default.userName.ToString(), graad);
            Resultaat resultaatWindow = new Resultaat("Aardrijkskunde");
            resultaatWindow.AntwoordenAarderijkskunde = antwoorden;
            resultaatWindow.OplossingenAarderijkskunde = oplossingen;
            resultaatWindow.Graad = graad;
            resultaatWindow.Show();
        }

        private void Resultaat_Moeilijk()
        {
            List<string> antwoorden = new List<string> { land1box.Items[0].ToString(), land2box.Items[0].ToString(), land3box.Items[0].ToString(), land4box.Items[0].ToString(), land5box.Items[0].ToString(), stad1box.Items[0].ToString(), stad2box.Items[0].ToString(), stad3box.Items[0].ToString(), stad4box.Items[0].ToString(), stad5box.Items[0].ToString() };
            List<string> oplossingen = new List<string>(landenList);
            oplossingen.AddRange(stedenList);
            IODatabase database = new IODatabase("Aardrijkskunde");
            database.SchrijfResultaatAarderijkskunde(antwoorden, oplossingen, Properties.Settings.Default.userName.ToString(), graad);
            Resultaat resultaatWindow = new Resultaat("Aardrijkskunde");
            resultaatWindow.AntwoordenAarderijkskunde = antwoorden;
            resultaatWindow.OplossingenAarderijkskunde = oplossingen;
            resultaatWindow.Graad = graad;
            resultaatWindow.Show();
        }

        public int Graad
        {
            get { return graad; }
            set { graad = value; }
        }

    }
}