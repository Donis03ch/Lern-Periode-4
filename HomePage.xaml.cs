using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DEBreader
{

    /// <summary>
    /// Interaktionslogik für HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {

        private MainWindow parent;

        public HomePage(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void CollectionButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CollectionPage());
            MainFrame.NavigationService.RemoveBackEntry();
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LibraryPage());
            MainFrame.NavigationService.RemoveBackEntry();
        }

    }
}
