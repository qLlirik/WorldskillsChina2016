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

namespace WorldskillsChina2016.pg
{
    /// <summary>
    /// Логика взаимодействия для VolunteerManagementPage.xaml
    /// </summary>
    public partial class VolunteerManagementPage : Page
    {
        Entity db = MainWindow.db;
        List<User> AllVolunteersList = new List<User>();
        public VolunteerManagementPage()
        {
            InitializeComponent();

            SetItemsOnGroupBox(cbxSkillsOfService, db.Competition.Select(w=>w.NameEnglish).ToList());
            var list = new List<string> { "IdNumber", "Name", "Gender", "Occupation", "Province", "Skills of Service"};
            SetItemsOnGroupBox(cbxSortBy, list);
            
            AllVolunteersList = db.User.Where(w => w.RoleID == "V").ToList();
            lv.ItemsSource = AllVolunteersList.Take(10);
        }

        private void SetItemsOnGroupBox(ComboBox cbx, List<string> list)
        {
            cbx.ItemsSource = list;
            cbx.SelectedIndex = 0;
        }

        private void click_First(object sender, RoutedEventArgs e)
        {

        }
    }
}
