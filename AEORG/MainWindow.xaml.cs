using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.IO;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AEORG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandContent.Content = new GapAnalysis();
        }
        private void CommandSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (CommandSelector.SelectedItem as ComboBoxItem)?.Content?.ToString();

            switch (selected)
            {
                case "Gap Analysis":
                    CommandContent.Content = new GapAnalysis();
                    break;

                case "Compare PDFs":
                    CommandContent.Content = new ComparePDFs();
                    break;
            }
        }
    }
}