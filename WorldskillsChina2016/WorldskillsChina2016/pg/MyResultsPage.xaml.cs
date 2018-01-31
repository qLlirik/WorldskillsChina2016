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
    /// Логика взаимодействия для MyResultsPage.xaml
    /// </summary>
    public partial class MyResultsPage : Page
    {
        User User = LoginPage.AuthorizationUser;
        public MyResultsPage()
        {
            InitializeComponent();

            txbName.Text = User.FirstName + " " + User.LastName;
            txbGender.Text = (User.IsMale == true) ? "Male" : "Female";
            txbIdNumber.Text = User.IDNumber;
            txbProvinceName.Text = User.Region.Name;
            txbProvinceCode.Text = User.RegionID + "";
            txbOrganization.Text = User.Organization;
        }
    }
}
