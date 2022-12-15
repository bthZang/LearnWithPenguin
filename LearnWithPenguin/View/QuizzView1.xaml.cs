using LearnWithPenguin.ViewModel;
using System;

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


        public QuizzView1()
        {
            InitializeComponent();

            QuizzView1ViewModel viewmodel = media.DataContext as QuizzView1ViewModel;

            viewmodel.OnclickHandleNextLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                viewmodel.Number += 1;
                
            });

            viewmodel.OnclickHandlePreviousLevel = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (viewmodel.Number > 1)
                    viewmodel.Number -= 1;
            
            });
        }
        //private void FillQuestionNumList()
        //{
        //    for (int i = 1; i <= 50; i++)

        //        questionNumbers.Add(i);
        //}
        //private void checkAnswer(object sender, RoutedEventArgs e)
        //{
        //    Button senderButton = sender as Button;
        //    if (senderButton.Tag.ToString() == "1")
        //    {

        //    }
        //    if (questionNumber < 0)
        //    {
        //        questionNumber = 0;
        //    }
        //    else
        //    {
        //        questionNumber++;
        //    }
        //    NextQuestion();
        //}
        //private void NextQuestion()
        //{
        //    if (questionNumber < questionNumbers.Count)
        //    {
        //        i = questionNumbers[questionNumber];
        //    }
        //    else
        //    {
        //        RestartGame();
        //    }
        //    switch (i)
        //    {
        //        case 1:
        //            ans1.Content = "Answer 1";
        //            ans2.Content = "Answer 2 Correct";
        //            ans3.Content = "Answer 3";
        //            ans4.Content = "Answer 4";

        //            ans2.Tag = "1";
        //            break;
        //        case 2:
        //            ans1.Content = "Answer 1";
        //            ans2.Content = "Answer 2";
        //            ans3.Content = "Answer 3 Correct";
        //            ans4.Content = "Answer 4";

        //            ans3.Tag = "1";
        //            break;
        //        case 3:
        //            ans1.Content = "Answer 1";
        //            ans2.Content = "Answer 2 Correct";
        //            ans3.Content = "Answer 3";
        //            ans4.Content = "Answer 4";

        //            ans2.Tag = "1";
        //            break;
                    

        //    }
        //}
        //private void RestartGame()
        //{
        //    questionNumber = -1;
        //    i = 0;
        //    StartGame();
        //}
        //private void StartGame()
        //{

        //    var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();
        //    questionNumbers = randomList;
        //    QuestionOrder.Content = null;
        //    for (int i = 0; i < questionNumbers.Count; i++)
        //    {
        //        QuestionOrder.Content += " " + questionNumbers[i].ToString();
        //    }
        //}

    }
}
