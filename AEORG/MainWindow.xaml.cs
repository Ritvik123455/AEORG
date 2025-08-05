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
        }
        private void AddCommand_Click(object sender, RoutedEventArgs e)
        {
            var selectedCommand = (CommandSelector.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (string.IsNullOrWhiteSpace(selectedCommand) || selectedCommand == "Please select a command")
            {
                MessageBox.Show("Please select a valid command before adding.");
                return;
            }
            if (CommandSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                string command = selectedItem.Content.ToString();

                UserControl controlToAdd = null;

                switch (command)
                {
                    case "Gap Analysis":
                        controlToAdd = new GapAnalysis();
                        break;

                    case "Compare PDFs":
                        controlToAdd = new ComparePDFs(); // You need to define this
                        break;

                    default:
                        MessageBox.Show("Please select a valid command.");
                        return;
                }

                CommandsPanel.Children.Add(controlToAdd);
            }
        }

    }
}