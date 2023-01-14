using LearnWithPenguin.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Button = System.Windows.Controls.Button;

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for QuizzView1.xaml
    /// </summary>
    public partial class QuizzView1 : System.Windows.Controls.Page
    {
        private int score = 0;
        private int tempScore;
        private string preTag = "0";

        private int count = 0;

        private bool ans1Clicked = false;
        private bool ans2Clicked = false;
        private bool ans3Clicked = false;
        private bool ans4Clicked = false;

        private bool backClicked = false;
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        public QuizzView1()
        {
            InitializeComponent();
            GoBackImg.Source = new BitmapImage(new Uri(@"/UserControls/BlurBack.png", UriKind.Relative));

            ans1.Click += storePreAnswer;
            ans2.Click += storePreAnswer;
            ans3.Click += storePreAnswer;
            ans4.Click += storePreAnswer;

            GoBack.Click += checkBack;
            NextQuestion();
            QuizzView1ViewModel viewmodel = button.DataContext as QuizzView1ViewModel;

            viewmodel.OnclickHandleNextLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (viewmodel.Number < 15)
                {
                  
                    if (count >= 3)
                    {
                        GoBackImg.Source = new BitmapImage(new Uri(@"/UserControls/BlurBack.png", UriKind.Relative));
                    }
                    else
                    {
                        GoBackImg.Source = new BitmapImage(new Uri(@"/UserControls/backIcon.png", UriKind.Relative));
                    }
                    viewmodel.Number += 1;
                    viewmodel.Question();
                    viewmodel.NavigatetoResult = null;
                    backClicked = false;
                    GoBack.IsEnabled = true;
                    NextQuestion();
                }
                if(viewmodel.Number > 14)
                {
                    GoNextImg.Source = new BitmapImage(new Uri(@"/UserControls/BlurNext.png", UriKind.Relative));
                }
                    

            });

            viewmodel.OnclickHandlePreviousLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (viewmodel.Number > 1)
                {
                    if (count <= 3)
                    {
                        backClicked = true;
                        viewmodel.Number -= 1;
                        viewmodel.Question();
                        viewmodel.NavigatetoResult = null;
                        GoBack.IsEnabled = false;
                        GoBackImg.Source = new BitmapImage(new Uri(@"/UserControls/BlurBack.png", UriKind.Relative));
                        GoNextImg.Source = new BitmapImage(new Uri(@"/UserControls/next.png", UriKind.Relative));
                        NextQuestion();

                    }
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

        private void storePreAnswer(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(ans1))
            {
                ans1Clicked = true;
                preTag = ans1.Tag.ToString();
            }
            else if (sender.Equals(ans2))
            {
                ans2Clicked = true;
                preTag = ans2.Tag.ToString();
            }
            else if (sender.Equals(ans3))
            {
                ans3Clicked = true;
                preTag = ans3.Tag.ToString();
            }
            else if (sender.Equals(ans4))
            {
                ans4Clicked = true;
                preTag = ans4.Tag.ToString();
            }
            else { }
        }
        //checkanswer
        private void checkAnswer(object sender, RoutedEventArgs e)
        {

            Button senderButton = sender as Button;
            tempScore = score;
            //if (senderButton.Tag.ToString() == "1")
            //{
            //    score++;
            //}


            if (senderButton.Tag.ToString() == "1" && backClicked == false)
            {
                score++;
            }
            else if (backClicked == true && senderButton.Tag.ToString() == "1" && tempScore + 1 == score)
            {
                score = score;
            }
            

            //if (ans1Clicked == true)
            //{
            //    preTag = ans1.Tag.ToString();
            //}
            //else if (ans2Clicked == true)
            //{
            //    preTag = ans2.Tag.ToString();
            //}
            //else if (ans3Clicked == true)
            //{
            //    preTag = ans3.Tag.ToString();
            //}
            //else if (ans4Clicked == true)
            //{
            //    preTag = ans4.Tag.ToString();
            //}
            //else { }


            //if (senderButton.Tag.ToString() == "1" && backClicked == false && preTag == "0")
            //{
            //    score++;
            //}
            //else if (backClicked == true && senderButton.Tag.ToString() == "1" && preTag == "1")
            //{
            //    score = score;
            //}
            //else if (senderButton.Tag.ToString() == "1" && backClicked == false)
            //{
            //    score++;
            //}




            scoreText.Content = "Số câu trả lời đúng " + score + "/" + questionNumbers.Count;

        }
        private void checkBack(object sender, RoutedEventArgs e)
        {
            //if (score > 0)
            //{
            //    tempScore = score;
            //    tempScore--;
            //}
            //else
            //{
            //    score = 0;
            //}



            ////if (score > 0 && tempScore + 1 == score)
            ////{
            ////    score--;
            ////}


            //if(tempScore + 1 == score)
            //{
            //    score = tempScore + 1;
            //}
            ////else
            ////{
            ////    score++;
            ////}
            //scoreText.Content = "Số câu trả lời đúng " + score + "/" + questionNumbers.Count;

            //backClicked = true;
            count++;


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
