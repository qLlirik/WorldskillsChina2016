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

            var list2 = db.Competition.ToList();
            list2.Insert(0,new Competition { NameEnglish = "All Skills"});
            cbxSkillsOfService.ItemsSource = list2;
            cbxSkillsOfService.DisplayMemberPath = "NameEnglish";
            cbxSkillsOfService.SelectedIndex = 0;

            var list = new List<string> { "IdNumber", "Name", "Gender", "Occupation", "Province", "Skills of Service"};
            cbxSortBy.ItemsSource = list;
            cbxSortBy.SelectedIndex = 0;

            AllVolunteersList = db.User.Where(w => w.RoleID == "V").ToList();
            txbTotalPage.Text = Math.Truncate(Convert.ToDecimal(AllVolunteersList.Count / 5)) + 1 + "";

            click_First(null,null);
        }

        private void click_First(object sender, RoutedEventArgs e)
        {
            lv.ItemsSource = AllVolunteersList.Take(5);
            txbCurrentPage.Text = "1";
        }

        private void click_Search(object sender, RoutedEventArgs e)
        {
            
        }

        private void click_Next(object sender, RoutedEventArgs e)
        {
            var currentPage = int.Parse(txbCurrentPage.Text);
            if (currentPage == int.Parse(txbTotalPage.Text))
                return;

            lv.ItemsSource = AllVolunteersList.Skip(currentPage * 5).Take(5).ToList();
            txbCurrentPage.Text = currentPage + 1 + "";
        }

        private void click_Previous(object sender, RoutedEventArgs e)
        {
            var currentPage = int.Parse(txbCurrentPage.Text);
            if (currentPage == 1)
                return;

            lv.ItemsSource = AllVolunteersList.Skip((currentPage - 2) * 5).Take(5).ToList();
            txbCurrentPage.Text = currentPage - 1 + "";
        }

        private void click_Last(object sender, RoutedEventArgs e)
        {
            var totalPage = int.Parse(txbTotalPage.Text);
            lv.ItemsSource = AllVolunteersList.Skip((totalPage - 1) * 5).Take(5).ToList();
            txbCurrentPage.Text = txbTotalPage.Text;
        }

        private void click_Go(object sender, RoutedEventArgs e)
        {
            if (txbGoToPage.Text.Length == 0)
            {
                MessageBox.Show("Введите номер страницы!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            try
            {
                var gotoPage = int.Parse(txbGoToPage.Text);
                if ((gotoPage <= int.Parse(txbTotalPage.Text)) && (gotoPage >= 1))
                {
                    lv.ItemsSource = AllVolunteersList.Skip((gotoPage - 1) * 5).Take(5);
                    txbCurrentPage.Text = txbGoToPage.Text;
                }
                else
                {
                    MessageBox.Show("Такой страницы не существует!","Error",MessageBoxButton.OK,    MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!","Error",MessageBoxButton.OK,   MessageBoxImage.Error);
            }
        }

        private void click_ImportVolunteers(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(new ImportVolunteersPage());
        }
    }
}
