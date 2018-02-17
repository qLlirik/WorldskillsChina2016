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
    /// Логика взаимодействия для EventManagementPage.xaml
    /// </summary>
    public partial class EventManagementPage : Page
    {
        public EventManagementPage()
        {
            InitializeComponent();
        }

        private void Click_CompetitionEvent(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new CompetitionEventPage());
        }
    }
}
