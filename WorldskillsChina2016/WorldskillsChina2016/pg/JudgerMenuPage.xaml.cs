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
    /// Логика взаимодействия для JudgerMenuPage.xaml
    /// </summary>
    public partial class JudgerMenuPage : Page
    {
        public JudgerMenuPage()
        {
            InitializeComponent();

            txbDayTime.Text = PageInitialize.GetDayPath();
            txbGenderHi.Text = LoginPage.AuthorizationUser.IsMale == true ? "Mr." : "Mrs.";
            txbName.Text = LoginPage.AuthorizationUser.FirstName;
        }
    }
}
