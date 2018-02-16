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
using WorldskillsChina2016.md;
using WorldskillsChina2016.cs;

namespace WorldskillsChina2016.pg
{
    /// <summary>
    /// Логика взаимодействия для MySkillsPage.xaml
    /// </summary>
    public partial class MySkillsPage : Page
    {
        Entity db = MainWindow.db;

        public MySkillsPage()
        {
            InitializeComponent();

            LoadInfo();
            try
            {
                LoadCompetitorsJudger(wpCompetitors, LoginPage.AuthorizationUser.Participation.First(w => w.UserID == LoginPage.AuthorizationUser.ID).Competition, "C");
                LoadCompetitorsJudger(wpJudgers, LoginPage.AuthorizationUser.Participation.First(w => w.UserID == LoginPage.AuthorizationUser.ID).Competition, "J");
            }
            catch
            {
            }
        }

        private void LoadInfo()
        {
            try
            {
                var UserCompetition = LoginPage.AuthorizationUser.Participation.First(w => w.UserID == LoginPage.AuthorizationUser.ID);

                txbSkillsId.Text = UserCompetition.CompetitionID.ToString();
                txbSkillsName.Text = UserCompetition.Competition.NameEnglish.ToString();
            }
            catch
            {
                MessageBox.Show("You haven't information about your skill!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void LoadCompetitorsJudger(WrapPanel wp, Competition comp, string RoleId)
        {
            foreach(var i in comp.Participation.Select(w=>w.User))
            {
                if ((i.ID != LoginPage.AuthorizationUser.ID) && (i.RoleID == RoleId))
                {
                    UserControl1 uc = new UserControl1();
                    uc.imgUCImage.Source = new BitmapImage(new Uri("/WorldskillsChina2016;component/im/logo.png", UriKind.Relative));
                    uc.txbUCUserName.Text = i.FirstName + ' ' + i.LastName;
                    uc.txbUCProvinceName.Text = i.Region.Name;
                    wp.Children.Add(uc);
                }
            }
        }
    }
}
