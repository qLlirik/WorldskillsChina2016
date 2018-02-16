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
    /// Логика взаимодействия для SponsorshipStatisticsPage.xaml
    /// </summary>
    public partial class SponsorshipStatisticsPage : Page
    {
        md.Entity db = MainWindow.db;

        public SponsorshipStatisticsPage()
        {
            InitializeComponent();


            var list = db.Championship.ToList();
            list.Insert(0, new md.Championship { Name = "All Event" });
            cbxEvent.ItemsSource = list;
            cbxEvent.DisplayMemberPath = "Name";
            cbxEvent.SelectedIndex = 0;

            var list2 = db.Sponsorship.ToList();
            list2.Insert(0, new md.Sponsorship { SponsorClassName = "All SponsorClassNames" });
            cbxClassBy.ItemsSource = list2.GroupBy(w => w.SponsorClassName).ToList();
            cbxClassBy.DisplayMemberPath = "SponsorClassName";
            cbxClassBy.SelectedIndex = 0;


            click_Statistiks(null,null);
        }

        private void click_Statistiks(object sender, RoutedEventArgs e)
        {
            try
            {
                var qvery = db.Sponsorship.Where(w => w.Amount != null);
                if (cbxEvent.SelectedIndex != 0)
                    qvery = qvery.Where(w => w.Championship.ID == ((md.Championship)cbxEvent.SelectedItem).ID);
                if (cbxClassBy.SelectedIndex != 0)
                    qvery = qvery.Where(w => w.SponsorClassName.Contains(cbxClassBy.Text + ""));
                lv.ItemsSource = qvery.ToList();
                txbTotalAmount.Text = qvery.Sum(w => w.Amount) + "";
            }
            catch
            {
                MessageBox.Show("Поиск не дал результаты!","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
