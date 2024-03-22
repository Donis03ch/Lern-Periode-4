
using System.Text;
using System.Collections.Generic;
using System.Linq;
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


using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Collections.ObjectModel;


namespace DEBreader
{
    public class Book
    {
        public string? Title { get; set; }
        public string? FilePath { get; set; }
    }

    public partial class MainWindow : Window
    {
        private ObservableCollection<Book> books = new ObservableCollection<Book>();

        public MainWindow()
        {
            InitializeComponent();

            lstBooks.ItemsSource = books;
            txtBookTitle.Text = "Enter Book Title";
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            string bookTitle = txtBookTitle.Text;
            if (!string.IsNullOrEmpty(bookTitle))
            {
                books.Add(new Book { Title = bookTitle });
                txtBookTitle.Text = "Enter Book Title";
            }
        }


        private void TxtBookTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBookTitle.Text == "Enter Book Title")
            {
                txtBookTitle.Text = "";
            }
        }

        private void TxtBookTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
            {
                txtBookTitle.Text = "Enter Book Title";
            }
        }


        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sFilename = UploadTxt.Text;

                PdfReader pdf_Reader = new PdfReader(sFilename);
                string sText = "";

                for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
                {
                    sText = sText + PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
                }

                // Create a new Book object and add it to the collection
                books.Add(new Book { Title = sText, FilePath = sFilename });

                lblPDF_Output.Text = sText;
            }
            catch (Exception)
            {
                string noFile = $"error: No file such as {UploadTxt.Text} has been found.";
                UploadTxt.Text = noFile;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
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
