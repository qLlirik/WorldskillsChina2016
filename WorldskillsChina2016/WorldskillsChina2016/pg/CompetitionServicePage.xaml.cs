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
    /// Логика взаимодействия для CompetitionServicePage.xaml
    /// </summary>
    public partial class CompetitionServicePage : Page
    {
        bool DragDrop = false;
        Image DragDropImage = new Image() { Width = 35, Height = 35 };
        const int CVSLEFT = 200;
        const int CVSTOP = 30;
        const int CVSRIGHT = 200 + 550;
        const int CVSBOTTOM = 30 + 300;

        public CompetitionServicePage()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(1);
            timer.Tick += delegate {
                if (DragDrop)
                {
                    var mouse_position = Mouse.GetPosition(cvs);
                    if (!cvs.Children.Contains(DragDropImage))
                        cvs.Children.Add(DragDropImage);
                    DragDropImage.SetValue(Canvas.LeftProperty,mouse_position.X);
                    DragDropImage.SetValue(Canvas.TopProperty,mouse_position.Y);
                }
            };
            timer.Start();

            DragDropImage.MouseLeftButtonDown += DragDropImage_MouseLeftButtonDown;
        }

        private void DragDropImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop = true;
        }

        private void MLBDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop = true;
            DragDropImage.Source = ((Image)sender).Source;
        }

        private void MLBUp(object sender, MouseButtonEventArgs e)
        {
            DragDrop = false;
            var left = (double)DragDropImage.GetValue(Canvas.LeftProperty);
            var top = (double)DragDropImage.GetValue(Canvas.TopProperty);
            if (!(((left >= CVSLEFT) && (left <= CVSRIGHT - DragDropImage.Width)) && ((top >= CVSTOP) && (top <= CVSBOTTOM - DragDropImage.Height))))
                cvs.Children.Remove(DragDropImage);
        }
    }
}
