using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldskillsChina2016.md;
using WorldskillsChina2016.cs;

namespace WorldskillsChina2016.pg
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Entity db = MainWindow.db;
        static public User AuthorizationUser = null;

        HelpClass Captcha = null;
        Int16 CheckedCount = 0;

        public LoginPage()
        {
            InitializeComponent();

            btnLogin.IsEnabled = PageInitialize.CanAuth;

            try
            {
                var str = File.ReadAllText("RememberMe.txt");
                if (str != "null")
                {
                    var arr = str.Split('`');
                    tbxIdNumber.Text = arr.First();
                    pbxPassword.Password = arr.Last();
                    chbxRememberMe.IsChecked = true;
                }
            }
            catch { }

            click_Image(null, null);

            //удалить
            tbxAuthCode.Text = Captcha.AuthCodeString;
        }

        private void click_Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.BackPage();
        }
        
        //Create Captcha
        public HelpClass CreateAuthCode(int Width, int Height)
        {
            Random rnd = new Random();
            Bitmap AuthCode = new Bitmap(Width, Height);

            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(0, Height - 15);

            Graphics graph = Graphics.FromImage(AuthCode);

            graph.Clear(System.Drawing.Color.White);
            string AuthCodeString = String.Empty;
            string numbers = "0123456789";
            string ALF = "QWERTYUIOPLKJHGFDSAZXCVBNM";
            string alf = "qwertyuiopasdfghjklzxcvbnm";

            AuthCodeString += numbers[rnd.Next(numbers.Length)];
            AuthCodeString += ALF[rnd.Next(ALF.Length)];
            AuthCodeString += alf[rnd.Next(alf.Length)];
            AuthCodeString += numbers[rnd.Next(numbers.Length)];

            graph.DrawString(AuthCodeString, new Font("Calibri", 20), System.Drawing.Brushes.Black, Xpos, Ypos);

            for (var i = 0; i <= 3000; i++)
            {
                graph.DrawString(".", new Font("Calibri", 9), System.Drawing.Brushes.Gray, rnd.Next(Width), rnd.Next(Height));
            }

            return new HelpClass(AuthCode, AuthCodeString);
        }
        
        //Click on Captcha
        private void click_Image(object sender, MouseButtonEventArgs e)
        {
            Captcha = CreateAuthCode(100, 50);
            img.Source = Captcha.GetSource;
        }
        
        //Login
        private void click_Login(object sender, RoutedEventArgs e)
        {
            AuthorizationUser = db.User.ToList().Find(w => w.IDNumber == tbxIdNumber.Text && w.Password == pbxPassword.Password);

            if ((AuthorizationUser == null) || (tbxAuthCode.Text.CompareTo(Captcha.AuthCodeString) != 0))
            {
                CheckedCount++;
                if (CheckedCount != 3)
                    MessageBox.Show("User cannot be finded! Please, input valid information!", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
                else
                {
                    PageInitialize.CanAuth = false;
                    btnLogin.IsEnabled = PageInitialize.CanAuth;
                    MessageBox.Show("You input invalid information three time! Please, restart application!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return;
            }

            if (chbxRememberMe.IsChecked == true)
            {
                File.WriteAllText("RememberMe.txt", tbxIdNumber.Text + '`' + pbxPassword.Password);
            }
            else
                File.WriteAllText("RememberMe.txt", "null");


            if (AuthorizationUser != null)
            {
                switch (AuthorizationUser.RoleID)
                {
                    case "A": { MainWindow.OpenPage(new AdministratorMenuPage()); break; }
                    case "C": { MainWindow.OpenPage(new CompetitorMenuPage()); break; }
                    case "O": { MainWindow.OpenPage(new CoordinatorMenuPage()); break; }
                    case "J": { MainWindow.OpenPage(new JudgerMenuPage()); break; }
                }
            }
        }
        
        //HelpClass for get result method CreateAuthCode
        public class HelpClass
        {
            public Bitmap AuthCode { get; set; }
            public string AuthCodeString { get; set; }

            public ImageSource GetSource
            {
                get
                {
                    return Imaging.CreateBitmapSourceFromHBitmap(AuthCode.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
            }

            public HelpClass(Bitmap Bitmap, string str)
            {
                this.AuthCode = Bitmap;
                this.AuthCodeString = str;
            }
        }
    }
}
