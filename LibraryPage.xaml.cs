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

namespace DEBreader
{
    /// <summary>
    /// Interaktionslogik für LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        public LibraryPage()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.RemoveBackEntry();

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
