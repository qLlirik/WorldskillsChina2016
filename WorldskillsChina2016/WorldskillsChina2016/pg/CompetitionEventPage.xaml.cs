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
    /// Логика взаимодействия для CompetitionEventPage.xaml
    /// </summary>
    public partial class CompetitionEventPage : Page
    {
        md.Entity db = MainWindow.db;

        public CompetitionEventPage()
        {
            InitializeComponent();

            Click_Search(null,null);
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            var qwery = db.Championship.Where(w => w.DateFinish != null);
            if (tbxSearch.Text.Length != 0)
                qwery = qwery.Where(w=>w.Name.Contains(tbxSearch.Text) || w.DateFinish.Value.ToString().Contains(tbxSearch.Text) || w.DateStart.Value.ToString().Contains(tbxSearch.Text) || w.Place.Contains(tbxSearch.Text));
            lv.ItemsSource = qwery.ToList();
        }

        private void SelectionChange_lv(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = ((md.Championship)((ListView)sender).SelectedItem).DateStart >= DateTime.Now ? true : false;    
        }

        private void Click_btnEdit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button’s function has not been developed should be prompted.", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
