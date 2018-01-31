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
    /// Логика взаимодействия для MainScreenPage.xaml
    /// </summary>
    public partial class MainScreenPage : Page
    {
        public MainScreenPage()
        {
            InitializeComponent();
        }

        private void click_AboutWorldskills(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new AboutWorldskillsPage());
        }

        private void click_AboutWorldskillsChina(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new AboutWorldskillsChinaPage());
        }

        private void click_AboutShangHai(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new AboutShangHaiPage());
        }

        private void click_Login(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new LoginPage());
        }
    }
}
