using LearnWithPenguin.ViewModel;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for QuizzView1.xaml
    /// </summary>
    public partial class QuizzView1 : System.Windows.Controls.Page
    {
        //List<int> questionNumbers = new List<int>();

        //int questionNumber = 0;
        //int i = 0;
        //public Button;

        public QuizzView1()
        {
            InitializeComponent();

            QuizzView1ViewModel viewmodel = media.DataContext as QuizzView1ViewModel;

            viewmodel.OnclickHandleNextLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                viewmodel.Number += 1;
                viewmodel.Question();
            });

            viewmodel.OnclickHandlePreviousLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (viewmodel.Number > 1)
                {
                    viewmodel.Number -= 1;
                    viewmodel.Question();
                }
            });
        }

        private void Sound_Click(object sender, RoutedEventArgs e)
        {
            //private MediaPlayer mediaPlayer = new MediaPlayer();
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //mediaPlayer.Open(new Uri());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
