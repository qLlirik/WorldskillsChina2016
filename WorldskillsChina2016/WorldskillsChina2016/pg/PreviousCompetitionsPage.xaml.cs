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
    /// Логика взаимодействия для PreviousCompetitionsPage.xaml
    /// </summary>
    public partial class PreviousCompetitionsPage : Page
    {
        Entity db = new Entity();

        public PreviousCompetitionsPage()
        {
            InitializeComponent();

            click_Search(null,null);
        }

        private void click_Search(object sender, RoutedEventArgs e)
        {
            var query = db.Championship.Where(w=>w.ID != null);
            if (tbxOrdianlNo.Text.Length != 0)
            {
                int No = Convert.ToInt32(tbxOrdianlNo.Text);
                query = query.Where(w => w.ID == No);
            }
            if (tbxCityOrCountry.Text.Length != 0)
                query = query.Where(w => w.Address.Contains(tbxCityOrCountry.Text));
            lv.ItemsSource = query.ToList();
        }
    }
}
