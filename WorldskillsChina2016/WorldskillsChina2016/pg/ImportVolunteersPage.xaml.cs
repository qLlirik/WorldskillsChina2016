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

namespace WorldskillsChina2016.pg
{
    /// <summary>
    /// Логика взаимодействия для ImportVolunteersPage.xaml
    /// </summary>
    public partial class ImportVolunteersPage : Page
    {
        public ImportVolunteersPage()
        {
            InitializeComponent();
        }

        private void click_Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.BackPage();
        }

        private void click_Browse(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Excel|*.xls;";
            if (ofd.ShowDialog() == true)
            {
                tbxPath.Text = ofd.FileName;
            }   
        }
    }
}
