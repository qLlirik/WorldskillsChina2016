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
using System.Windows.Threading;
using WorldskillsChina2016.pg;
using WorldskillsChina2016.md;

namespace WorldskillsChina2016
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public List<Page> navList = new List<Page>();
        static public MainWindow main;
        static public Entity db = new Entity();

        public MainWindow()
        {
            InitializeComponent();

            main = this;

            OpenPage(new MainScreenPage());

            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(1);
            Timer.Tick += delegate {
                DateTime date = new DateTime(2018, 10, 14);
                var AbuDhabiDate = date - DateTime.Now;
                txbTimer.Text = AbuDhabiDate.Days.ToString() + " days " + AbuDhabiDate.Hours.ToString() + " hour " + AbuDhabiDate.Minutes.ToString() + " minutes " + AbuDhabiDate.Seconds.ToString() + " seconds until the 2018 Abu Dhabi WorldSkills Competition starts";
            };
            Timer.Start();

            btnBack.Click += (o, e) =>
            {
                BackPage();
            };

            btnLogout.Click += (o, e) =>
            {
                LoginPage.AuthorizationUser = null;
                navList.Clear();
                OpenPage(new MainScreenPage());
            };
        }

        static public void OpenPage(Page page)
        {
            navList.Add(page);
            main.Title = "Skills Competition Management System - " + page.Title;
            if (navList.Count == 1)
                main.grDop.Visibility = Visibility.Visible;
            else
                main.grDop.Visibility = Visibility.Collapsed;

            main.btnBack.Visibility = ((LoginPage.AuthorizationUser != null) && (navList.Count == 3)) ? Visibility.Hidden : Visibility.Visible;
            main.btnLogout.Visibility = LoginPage.AuthorizationUser != null ? Visibility.Visible : Visibility.Hidden;

            main.frmCont.Navigate(page);
        }

        static public void BackPage()
        {
            navList.Remove(navList.Last());
            main.Title = "Skills Competition Management System - " + navList.Last().Title;
            if (navList.Count == 1)
                main.grDop.Visibility = Visibility.Visible;
            else
                main.grDop.Visibility = Visibility.Collapsed;

            main.btnBack.Visibility = ((LoginPage.AuthorizationUser != null) && (navList.Count == 3)) ? Visibility.Hidden : Visibility.Visible;
            main.btnLogout.Visibility = LoginPage.AuthorizationUser != null ? Visibility.Visible : Visibility.Hidden;

            main.frmCont.Navigate(navList.Last());
        }
    }
}
