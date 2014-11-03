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

//Add library below to use OpenFileDialog
using Microsoft.Win32;
//Add library below to use PumaPage
using Puma.Net;

namespace OCRTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            Nullable<bool> isSelected = fileDialog.ShowDialog();
            if (isSelected == true)
            {
                string filePath = fileDialog.FileName;
                txt_Path.Text = filePath;
            }
        }

        private void bt_read_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = txt_Path.Text.Trim();
            if (!string.IsNullOrEmpty(sourceFilePath))
            {
                PumaPage inputFile = new PumaPage(sourceFilePath);
                inputFile.FileFormat = PumaFileFormat.TxtAscii;
                inputFile.Language = PumaLanguage.English;
                string outputString = inputFile.RecognizeToString();
                txt_Display.Text = outputString;
                inputFile.Dispose();
            }
        }

        private void bt_openfile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            Nullable<bool> isSelected = fileDialog.ShowDialog();
            if (isSelected == true)
            {
                string destinationPath = fileDialog.FileName;
                txt_Destination.Text = destinationPath;
            }
        }

        private void bt_readToFile_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = txt_Path.Text.Trim();
            string destinationFilePath = txt_Destination.Text.Trim();

            if (!string.IsNullOrEmpty(destinationFilePath) & !string.IsNullOrEmpty(sourceFilePath))
            {
                PumaPage outputFile = new PumaPage(sourceFilePath);
                outputFile.FileFormat = PumaFileFormat.TxtAscii;
                outputFile.Language = PumaLanguage.English;
                outputFile.RecognizeToFile(destinationFilePath);
                outputFile.Dispose();
                MessageBox.Show("Success!");
            }
        }




    }
}
