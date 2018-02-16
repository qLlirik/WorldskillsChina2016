using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Логика взаимодействия для ExportSponsorshipDetailPage.xaml
    /// </summary>
    public partial class ExportSponsorshipDetailPage : Page
    {
        public ExportSponsorshipDetailPage()
        {
            InitializeComponent();
        }

        private void Click_Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.BackPage();
        }

        private void Click_Browse(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.Description = "Выберите папку для сохранения файла.";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tbxPath.Text = fbd.SelectedPath;
        }

        private void Click_Export(object sender, RoutedEventArgs e)
        {
            if (tbxPath.Text.Length == 0)
            {
                MessageBox.Show("Выберите папку для сохраения файла!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            if (rbXLS.IsChecked == true)
            {
                string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0;Extended properties = Excel 8.0; Data Source = " + tbxPath.Text + @"\Export.xls";
                OleDbConnection conn = new OleDbConnection(connectionString);

                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                cmd.CommandText = "Create Table [Sponsorships] (Name Varchar, Championship Varchar, Skill Varchar, SponsorClassName Varchar, Sponsor Varchar, Amount Varchar, Picture Varchar)";
                cmd.ExecuteNonQuery();

                foreach(var i in cs.StaticClass.SponsorshipList)
                {
                    cmd.CommandText = "Insert Into [Sponsorships] (Name , Championship , Skill , SponsorClassName , Sponsor , Amount , Picture) Values ('" + i.Name + "', '" + i.Championship.Name + "', '" + i.Competition.NameRussian + "', '" + i.SponsorClassName + "', '" + i.Sponsor + "', '" + i.Amount + "', '" + i.Picture + "')";
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            else if (rbXML.IsChecked == true)
            {
                System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(tbxPath.Text + @"\Export.xml");
                writer.WriteStartDocument();
                writer.WriteStartElement("Sponsorships");

                foreach (var i in cs.StaticClass.SponsorshipList)
                {
                    writer.WriteStartElement("Sponsorship");
                    writer.WriteElementString("Name", i.Name);
                    writer.WriteElementString("Championship", i.Championship.Name);
                    writer.WriteElementString("Skill", i.Competition.NameRussian);
                    writer.WriteElementString("SponsorClassName", i.SponsorClassName);
                    writer.WriteElementString("Sponsor",i.Sponsor);
                    writer.WriteElementString("Amount", i.Amount + "");
                    writer.WriteElementString("Picture",i.Picture + "");
                    writer.WriteEndElement();
                    writer.Flush();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            MessageBox.Show("Экспорт совершён!","Perfect",MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
