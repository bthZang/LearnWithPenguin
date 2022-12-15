using LearnWithPenguin.ViewModel;
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

namespace LearnWithPenguin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var viewmodel = grid.DataContext as MainViewModel;
            viewmodel._music.Stop();
            viewmodel.isClosing = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var viewmodel = grid.DataContext as MainViewModel;
            viewmodel._music.Play();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var viewmodel = grid.DataContext as MainViewModel;
            viewmodel._music.Stop();
            viewmodel.isClosing = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var viewmodel = grid.DataContext as MainViewModel;
            //viewmodel._sound.Position = TimeSpan.Zero;
            //viewmodel._sound.Play();
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewmodel = grid.DataContext as MainViewModel;
            if (viewmodel.isSound)
            {
                viewmodel._sound.Position = TimeSpan.Zero;
                viewmodel._sound.Play();
            }
        }
    }
}
