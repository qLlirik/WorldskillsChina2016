using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

namespace WorldskillsChina2016.pg
{
    /// <summary>
    /// Логика взаимодействия для CompetitionServicePage.xaml
    /// </summary>
    public partial class CompetitionServicePage : Page
    {
        bool DragDrop = false;
        Image DragDropImage = new Image();
        const int CVSLEFT = 200;
        const int CVSTOP = 140;
        const int CVSRIGHT = 200 + 565;
        const int CVSBOTTOM = 140 + 295;
        string FileName = "IconsPoints.xml";

        public CompetitionServicePage()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(1);
            timer.Tick += delegate {
                if (DragDrop)
                {
                    // если ЛКМ отпускается над картиной, то срабаотывает MLBUp, если нет, то данное условие, ЭТО И УДАЛЯЕТ ИКОНКУ
                    if (Mouse.LeftButton == MouseButtonState.Released)
                    {
                        DragDrop = false;
                        cvs.Children.Remove(DragDropImage);
                        return;
                    }
                    var mouse_position = Mouse.GetPosition(cvs);
                    if (!cvs.Children.Contains(DragDropImage))
                        cvs.Children.Add(DragDropImage);
                    DragDropImage.SetValue(Canvas.LeftProperty,mouse_position.X);
                    DragDropImage.SetValue(Canvas.TopProperty,mouse_position.Y);
                }
            };
            timer.Start();

            DragDropImage.MouseLeftButtonDown += DragDropImage_MouseLeftButtonDown;

            LoadIconsXML();

        }

        private void DragDropImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop = true;
            DragDropImage = (Image)sender;
        }

        private void MLBDown(object sender, MouseButtonEventArgs e)
        {
            if (DragDrop)
                return;
            DragDrop = true;
            Image im = new Image { Source = ((Image)sender).Source, Width = 35, Height = 35 };
            im.MouseLeftButtonDown += DragDropImage_MouseLeftButtonDown;
            DragDropImage = im;
        }

        private void MLBUp(object sender, MouseButtonEventArgs e)
        {
            var left = (double)DragDropImage.GetValue(Canvas.LeftProperty);
            var top = (double)DragDropImage.GetValue(Canvas.TopProperty);
            if ((((left >= CVSLEFT) && (left <= CVSRIGHT - DragDropImage.Width)) && ((top >= CVSTOP) && (top <= CVSBOTTOM - DragDropImage.Height))))
                DragDrop = false;
        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
            cvs.Children.Clear();
        }

        private void Click_Save(object sender, RoutedEventArgs e)
        {
            System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(Environment.CurrentDirectory + @"\" + FileName);
            writer.WriteStartDocument();
            if (cvs.Children.Count != 0)
            {
                writer.WriteStartElement("Icons");
                foreach(var i in cvs.Children)
                {
                    var im = (Image)i;
                    writer.WriteStartElement("Icon");
                    writer.WriteElementString("Source",im.Source + "");
                    writer.WriteElementString("Width",im.Width + "");
                    writer.WriteElementString("Height",im.Height + "");
                    writer.WriteElementString("Left", im.GetValue(Canvas.LeftProperty) + "");
                    writer.WriteElementString("Top", im.GetValue(Canvas.TopProperty) + "");
                    writer.WriteEndElement();
                    writer.Flush();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            else
            {
                writer.WriteStartElement("Null");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            writer.Close();
            MessageBox.Show("Позиции иконок сохранены!","Perfect",MessageBoxButton.OK,  MessageBoxImage.Information);
        }

        private void LoadIconsXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Environment.CurrentDirectory + @"\" + FileName);

            if ((doc.DocumentElement).Name == "Null")
                return;

            foreach(XmlNode i in doc.DocumentElement)
            {
                Image im = new Image {
                    Source = new BitmapImage(new Uri(i["Source"].InnerText)),
                    Width = int.Parse(i["Width"].InnerText),
                    Height = int.Parse(i["Height"].InnerText)
                };
                im.SetValue(Canvas.LeftProperty, double.Parse(i["Left"].InnerText));
                im.SetValue(Canvas.TopProperty, double.Parse(i["Top"].InnerText));
                im.MouseLeftButtonDown += DragDropImage_MouseLeftButtonDown;
                cvs.Children.Add(im);
            }
            doc = null;
        }
    }
}
