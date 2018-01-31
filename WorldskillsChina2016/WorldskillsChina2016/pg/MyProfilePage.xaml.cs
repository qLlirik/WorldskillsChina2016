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
    /// Логика взаимодействия для MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : Page
    {
        Entity db = MainWindow.db;

        public MyProfilePage()
        {
            InitializeComponent();

            chbxPassModify.Click += (o, e) =>
            {
                BoolModifyPassword(chbxPassModify.IsChecked.Value);
            };

            BoolModifyPassword(false);

            LoadUserInfo(LoginPage.AuthorizationUser);
        }

        public void BoolModifyPassword(bool check)
        {
            tbxPassword.Text = "";
            tbxRePassword.Text = "";
            brdPassword.IsEnabled = check;
            brdPassword.Background = (check) ? null : Brushes.LightGray;
            btnSave.IsEnabled = check;
        }

        private void click_chbxShowPassword(object sender, RoutedEventArgs e)
        {
            if(chbxShowPassword.IsChecked == true)
            {
                tbxPassword.Text = pbxPassword.Password;
                tbxRePassword.Text = pbxRePassword.Password;
                tbxPassword.Visibility = Visibility.Visible;
                tbxRePassword.Visibility = Visibility.Visible;
            }
            else
            {
                pbxPassword.Password = tbxPassword.Text;
                pbxRePassword.Password = tbxRePassword.Text;
                tbxPassword.Visibility = Visibility.Hidden;
                tbxRePassword.Visibility = Visibility.Hidden;
            }
        }

        private void click_Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.BackPage();
        }

        private void LoadUserInfo(User user)
        {
            tbxName.Text = user.FirstName;
            tbxGender.Text = user.IsMale == true ? "Male" : "Female";
            tbxDateOfBirth.Text = user.DateOfBirth.ToString();
            tbxIdNumber.Text = user.IDNumber;
            tbxProvince.Text = user.Region.Name + '(' + user.RegionID + ')';
            tbxPhone.Text = user.Phone;
            tbxEmail.Text = user.Email; 
        }

        //Save a new password
        private void click_PasswordSave(object sender, RoutedEventArgs e)
        {
            if (tbxPassword.Text.CompareTo(tbxRePassword.Text) != 0)
            {
                MessageBox.Show("Passwords not be the same!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            if (CheckPassword(tbxPassword.Text))
            {
                LoginPage.AuthorizationUser.Password = tbxPassword.Text;
                db.SaveChanges();

                BoolModifyPassword(false);

                MessageBox.Show("New password will be saved!", "OK",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Password does not match specifications! Hover over the red * for information!","Error",MessageBoxButton.OK,MessageBoxImage.Error);

        }

        //checking password on rules
        private bool CheckPassword(string pass)
        {
            //проверка на количество символов
            if ((pass.Length < 6) || (pass.Length > 16))
                return false;

            //проверка на наличие заглавной буквы
            bool check1 = false;
            foreach (var i in pass)
                if (Char.IsUpper(i))
                {
                    check1 = true;
                    break;
                }
            if (!check1)
                return false;

            //проверка на наличие строчной буквы
            bool check2 = false;
            foreach (var i in pass)
                if (Char.IsLower(i))
                {
                    check2 = true;
                    break;
                }
            if (!check2)
                return false;

            //проврека на налаичие любого числа
            bool check3 = false;
            foreach (var i in pass)
                if (Char.IsNumber(i))
                {
                    check3 = true;
                    break;
                }
            if (!check3)
                return false;

            //проверка на наличие трёх последовательных одинаковых символа
            for (var i = 0; i < pass.Length; i++)
                try
                {
                    if ((pass[i] == pass[i + 1]) && (pass[i] == pass[i + 2]))
                        return false;
                }
                catch { }

            //проверка на наличие пробела
            if (pass.Contains(" "))
                return false;

            return true;
        }
    }
}
