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
using WorldskillsChina2016.cs;

namespace WorldskillsChina2016.pg
{
    /// <summary>
    /// Логика взаимодействия для CompetitorMenuPage.xaml
    /// </summary>
    public partial class CompetitorMenuPage : Page
    {
        public CompetitorMenuPage()
        {
            InitializeComponent();

            txbDayTime.Text = PageInitialize.GetDayPath();
            txbGenderHi.Text = LoginPage.AuthorizationUser.IsMale == true ? "Mr." : "Mrs.";
            txbName.Text = LoginPage.AuthorizationUser.FirstName;
        }
        
        private void click_MyProfile(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new MyProfilePage());
        }

        private void click_MySkills(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new MySkillsPage());
        }

        private void click_MyResults(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new MyResultsPage());
        }
    }
}
