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
using leren.Spel;

namespace leren
{
    // Aardrijkskunde window
    // Date: 08/04/15 - Last edit: 09/05/15
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

        // Bij het laden van het scherm de graad aanpassen
        private void Aarderijkskunde_Loaded(object sender, RoutedEventArgs e)
        {
            Randomizer.Randomize(landenList);
            for (int i = 0; i < landenList.Length; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = landenList[i].ToString();
                landen.Items.Add(itm);
            }
            if (graad == 1)
            {
                Moeilijk();
            }
        }

        // Selecteren van een land
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

        // Selecteren van een stad
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

        // Drag land
        private void land_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        // Drag Land
        private void land_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        // Drop land
        private void land_Drop(object sender, DragEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string oldText = "";
            if (lb.Items.Count > 0)
            {
                oldText = lb.Items[0].ToString();
            }
            lb.Items.Clear();
            error.Content = "";
            string tstring;
            tstring = e.Data.GetData(DataFormats.StringFormat).ToString();
            lb.Items.Add(tstring.ToString());
            GebruikteItems(lb, "land", oldText);
            for (int i = 0; i < stedenList.Length; i++) {
                while (lb.Items.Contains(stedenList[i].ToString()))
                {
                    lb.Items.Clear();
                    error.Content = "Dit is geen land!";
                    break;
                }
            }
        }

        // Drop stad
        private void stad_Drop(object sender, DragEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string oldText = "";
            if (lb.Items.Count > 0)
            {
                oldText = lb.Items[0].ToString();
            }
            lb.Items.Clear();
            error.Content = "";
            string tstring;
            tstring = e.Data.GetData(DataFormats.StringFormat).ToString();
            lb.Items.Add(tstring.ToString());
            GebruikteItems(lb, "stad", oldText);
                for (int i = 0; i < landenList.Length; i++)
                {
                    while(lb.Items.Contains(landenList[i].ToString()))
                    {
                        lb.Items.Clear();
                        error.Content = "Dit is geen stad!";
                        break;
                    }
                }
        }

        // drop land en stad
        private void drop_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
        
        }

        // Visibility uitzetten voor moeilijk
        private void Moeilijk()
        {
            Randomizer.Randomize(stedenList);
            stedenGrid.Visibility = Visibility.Visible;
            for (int i = 0; i < stedenList.Length; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = stedenList[i].ToString(); 
                steden.Items.Add(itm);
            }
        }

        // Toon resultaat
        private void Resultaat(object sender, RoutedEventArgs e)
        {
            if (land1box.Items.Count == 0 || land2box.Items.Count == 0 || land3box.Items.Count == 0 || land4box.Items.Count == 0 || land5box.Items.Count == 0)
            {
                if (graad == 1)
                {
                    if (stad1box.Items.Count == 0 || stad2box.Items.Count == 0 || stad3box.Items.Count == 0 || stad4box.Items.Count == 0 || stad5box.Items.Count == 0)
                    {
                        string messageBoxText = Properties.Settings.Default.userName +  ", je hebt niet alle landen of staded versleept! Versleep de landen en steden naar het juiste land en druk vervolgens op resultaat.";
                        string caption = "Geen antwoord";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;
                        MessageBox.Show(messageBoxText, caption, button, icon);
                    }
                }
                else
                {
                    string messageBoxText = Properties.Settings.Default.userName + ", je hebt niet alle landen versleept! Versleep de landen en druk vervolgens op resultaat.";
                    string caption = "Geen antwoord";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
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

        // Terug naar het menu gaan
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

        // Sla het resultaat makkelijk op
        private void Resultaat_Makkelijk()
        {
            List<string> antwoorden = new List<string>{land1box.Items[0].ToString(), land2box.Items[0].ToString(), land3box.Items[0].ToString(), land4box.Items[0].ToString(), land5box.Items[0].ToString() };
            List<string> oplossingen = new List<string>{"België", "Nederland", "Spanje", "Duitsland", "Frankrijk"};
            IODatabase database = new IODatabase("Aardrijkskunde");
            database.SchrijfResultaatAarderijkskunde(antwoorden, oplossingen, Properties.Settings.Default.userName.ToString(), graad);
            SpelGegevens infoSpel = new SpelGegevens();
            infoSpel.VoegLevenToe();
            infoSpel.WegSchrijven();
            Resultaat resultaatWindow = new Resultaat("Aardrijkskunde");
            resultaatWindow.AntwoordenAarderijkskunde = antwoorden;
            resultaatWindow.OplossingenAarderijkskunde = oplossingen;
            resultaatWindow.Graad = graad;
            resultaatWindow.Show();
        }

        // Sla het resultaat moeilijk op
        private void Resultaat_Moeilijk()
        {
            List<string> antwoorden = new List<string> { land1box.Items[0].ToString(), land2box.Items[0].ToString(), land3box.Items[0].ToString(), land4box.Items[0].ToString(), land5box.Items[0].ToString(), stad1box.Items[0].ToString(), stad2box.Items[0].ToString(), stad3box.Items[0].ToString(), stad4box.Items[0].ToString(), stad5box.Items[0].ToString() };
            List<string> oplossingen = new List<string>{"België", "Nederland", "Spanje", "Duitsland", "Frankrijk", "Brussel", "Amsterdam", "Madrid", "Berlijn", "Parijs"}; // Opnieuw declareren nadat Randomize is opgeroepen
            IODatabase database = new IODatabase("Aardrijkskunde");
            database.SchrijfResultaatAarderijkskunde(antwoorden, oplossingen, Properties.Settings.Default.userName.ToString(), graad);
            SpelGegevens infoSpel = new SpelGegevens();
            infoSpel.VoegLevenToe();
            infoSpel.WegSchrijven();
            Resultaat resultaatWindow = new Resultaat("Aardrijkskunde");
            resultaatWindow.AntwoordenAarderijkskunde = antwoorden;
            resultaatWindow.OplossingenAarderijkskunde = oplossingen;
            resultaatWindow.Graad = graad;
            resultaatWindow.Show();
        }

        // Randomize steden en landen
        public class Randomizer
        {
            public static void Randomize<T>(T[] items)
            {
                Random rand = new Random();

                for (int i = 0; i < items.Length - 1; i++)
                {
                    int j = rand.Next(i, items.Length);
                    T temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                }
            }
        }

        // Gebruikte items een andere kleur geven
        public void GebruikteItems(ListBox lb, string type, string oldText)
        {
            if (type == "land")
            {
                for (int i = 0; i < landen.Items.Count; i++)
                {
                    while(lb.Items.Contains(landenList[i].ToString()))
                    {
                        ListBoxItem selectedItem = landen.Items[i] as ListBoxItem;
                        selectedItem.Foreground = Brushes.Gray;
                        break;
                    }
                    while(oldText.Contains(landenList[i].ToString()))
                    {
                        ListBoxItem oldItem = landen.Items[i] as ListBoxItem;
                        oldItem.Foreground = Brushes.Black;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < steden.Items.Count; i++)
                {
                    while (lb.Items.Contains(stedenList[i].ToString()))
                    {
                        ListBoxItem selectedItem = steden.Items[i] as ListBoxItem;
                        selectedItem.Foreground = Brushes.Gray;
                        break;
                    }
                    while (oldText.Contains(stedenList[i].ToString()))
                    {
                        ListBoxItem oldItem = steden.Items[i] as ListBoxItem;
                        oldItem.Foreground = Brushes.Black;
                        break;
                    }
                }
            }
        }

        public int Graad
        {
            get { return graad; }
            set { graad = value; }
        }

    }
}