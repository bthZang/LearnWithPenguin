using LearnWithPenguin.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for WriteView.xaml
    /// </summary>
    public partial class WriteView : System.Windows.Controls.Page
    {
        public void clearCanvas()
        {
            WriteViewModel viewmodel = media.DataContext as WriteViewModel;
            viewmodel.NavigatetoResult = null;
            MyCanvas.Strokes.Clear();
        }

        public WriteView()
        {
            InitializeComponent();
            MyCanvas.DefaultDrawingAttributes.Color = Colors.White;
            MyCanvas.DefaultDrawingAttributes.Width = 20;
            MyCanvas.DefaultDrawingAttributes.Height = 20;

            WriteViewModel viewmodel = media.DataContext as WriteViewModel;
            viewmodel.Replay = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                clearCanvas();
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            media.Position = TimeSpan.FromSeconds(0);
            media.Play();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            var viewModelInstance = media.DataContext;
            (viewModelInstance as WriteViewModel).IsDisplayVideo = "Hidden";
            media.Stop();
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point position = e.GetPosition(this);

            var viewModelInstance = media.DataContext;
            if (System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed)
                (viewModelInstance as WriteViewModel).AddPosition(position);
        }
    }
}
