using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AEORG
{
    /// <summary>
    /// Interaction logic for GapAnalysis.xaml
    /// </summary>
    public partial class GapAnalysis : UserControl
    {
        public GapAnalysis()
        {
            InitializeComponent();
        }


        private void BrowseProject_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            dialog.Title = "Select project file";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (dialog.ShowDialog() == true)
            {
                ProjectDirectoryText.Text = dialog.FolderName;
            }
        }

        private void BrowseReference_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            dialog.Title = "Select reference file";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (dialog.ShowDialog() == true)
            {
                ReferenceDirectoryText.Text = dialog.FolderName;
            }
        }

        private async void GapAnalysis_Click(object sender, RoutedEventArgs e)
        {
            string fullPath = System.IO.Path.Combine(ConfigurationManager.DefaultDirectory, ConfigurationManager.DefaultInputDirectory);

            string content = "GAP_ANALYSIS  PROJ_DIR = " + ProjectDirectoryText.Text + " &\r\n" + "REF_DIR = " + ReferenceDirectoryText.Text;
            try
            {
                File.WriteAllText(fullPath, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in creating file" + ex.Message, "Error");
            }
            MessageBox.Show("INS File created!");
            try
            {
                ResponseFromApp.Text = BackendRunner.RunTool(ConfigurationManager.ExePath, ConfigurationManager.DefaultInputDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start AEORG.exe", "ERROR");
            }
        }
    }
}

