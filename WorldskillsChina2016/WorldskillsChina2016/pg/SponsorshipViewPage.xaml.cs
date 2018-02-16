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
    /// Логика взаимодействия для SponsorshipViewPage.xaml
    /// </summary>
    public partial class SponsorshipViewPage : Page
    {
        md.Entity db = MainWindow.db;

        public SponsorshipViewPage()
        {
            InitializeComponent();

            var list = db.Championship.ToList();
            list.Insert(0, new md.Championship { Name = "All Event" });
            cbxEvent.ItemsSource = list;
            cbxEvent.DisplayMemberPath = "Name";
            cbxEvent.SelectedIndex = 0;

            var list2 = db.Sponsorship.ToList();
            list2.Insert(0, new md.Sponsorship { SponsorClassName = "All SponsorClassNames" });
            cbxSkills.ItemsSource = list2.GroupBy(w => w.SponsorClassName).ToList();
            cbxSkills.DisplayMemberPath = "SponsorClassName";
            cbxSkills.SelectedIndex = 0;

            Click_Search(null,null);

        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            var qwery = db.Sponsorship.Where(w=>w.Amount != null);
            if (cbxEvent.SelectedIndex != 0)
                qwery = qwery.Where(w => w.Championship.ID == ((md.Championship)cbxEvent.SelectedItem).ID);
            if (cbxSkills.SelectedIndex != 0)
                qwery = qwery.Where(w => w.SponsorClassName.Contains(cbxSkills.Text));
            if (tbxSponsor.Text.Length != 0)
                qwery = qwery.Where(w=>w.Name.Contains(tbxSponsor.Text));
            lv.ItemsSource = qwery.ToList();
            txbTotalRecords.Text = qwery.Count() + "";
            txbTotalAmount.Text = qwery.Sum(w=>w.Amount) + "";
        }

        private void Click_Export(object sender, RoutedEventArgs e)
        {
            cs.StaticClass.SponsorshipList = (List<md.Sponsorship>)lv.ItemsSource;
            MainWindow.OpenPage(new ExportSponsorshipDetailPage());
        }
    }
}
