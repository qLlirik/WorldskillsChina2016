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
    /// Логика взаимодействия для AboutWorldskillsPage.xaml
    /// </summary>
    public partial class AboutWorldskillsPage : Page
    {
        public AboutWorldskillsPage()
        {
            InitializeComponent();
        }

        private void click_HistoryOfWorldskills(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new HistoryOfWorldskillsPage());
        }

        private void click_CompetitionSkills(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new CompetitionSkillsPage());
        }

        private void click_PreviousCompetitions(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new PreviousCompetitionsPage());
        }
    }
}
