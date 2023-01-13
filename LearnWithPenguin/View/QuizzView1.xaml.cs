using LearnWithPenguin.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for QuizzView1.xaml
    /// </summary>
    public partial class QuizzView1 : System.Windows.Controls.Page
    {
        private int score;
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        public QuizzView1()
        {
            InitializeComponent();
            NextQuestion();

            QuizzView1ViewModel viewmodel = button.DataContext as QuizzView1ViewModel;

            viewmodel.OnclickHandleNextLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (viewmodel.Number < 15)
                {
                    viewmodel.Number += 1;
                    viewmodel.Question();
                    viewmodel.NavigatetoResult = null;
                    NextQuestion();
                }
            });

            viewmodel.OnclickHandlePreviousLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (viewmodel.Number > 1)
                {
                    viewmodel.Number -= 1;
                    viewmodel.Question();
                    viewmodel.NavigatetoResult = null;
                    NextQuestion();
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


        //checkanswer
        private void checkAnswer(object sender, RoutedEventArgs e)
        {

            Button senderButton = sender as Button;
            if (senderButton.Tag.ToString() == "1")
            {
                score++;
            }
            scoreText.Content = "Số câu trả lời đúng " + score + "/" + questionNumbers.Count;

        }
        private void checkBack(object sender, RoutedEventArgs e)
        {
            if(score > 0)
            {
                score--;
            }
            else
            {
                score = 0;
            } 
            scoreText.Content = "Số câu trả lời đúng " + score + "/" + questionNumbers.Count;
        }
        private void NextQuestion()
        {
            QuizzView1ViewModel viewmodel = button.DataContext as QuizzView1ViewModel;
            switch (viewmodel.Number)
            {
                case 1:
                    ans1.Tag = "1";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    break;
                case 2:
                    ans1.Tag = "0";
                    ans2.Tag = "0";
                    ans4.Tag = "0";
                    ans3.Tag = "1";
                    break;
                case 3:
                    ans1.Tag = "1";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    break;
                case 4:
                    ans1.Tag = "0";
                    ans3.Tag = "1";
                    ans2.Tag = "0";
                    ans4.Tag = "0";
                    break;
                case 5:
                    ans1.Tag = "0";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "1";
                    break;
                case 6:
                    ans1.Tag = "1";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    break;
                case 7:
                    ans1.Tag = "0";
                    ans2.Tag = "0";
                    ans3.Tag = "1";
                    ans4.Tag = "0";
                    break;
                case 8:
                    ans1.Tag = "1";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    break;
                case 9:
                    ans1.Tag = "0";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "1";
                    break;
                case 10:
                    ans1.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    ans2.Tag = "1";
                    break;
                case 11:
                    ans1.Tag = "1";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    break;

                case 12:
                    ans1.Tag = "0";
                    ans2.Tag = "0";
                    ans3.Tag = "1";
                    ans4.Tag = "0";
                    break;
                case 13:
                    ans1.Tag = "0";
                    ans2.Tag = "1";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    break;
                case 14:
                    ans1.Tag = "0";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "1";
                    break;
                case 15:
                    ans1.Tag = "1";
                    ans2.Tag = "0";
                    ans3.Tag = "0";
                    ans4.Tag = "0";
                    break;
                default:
                    break;
            }
        }

    }
}
