using LearnWithPenguin.Models;
using LearnWithPenguin.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for QuizQuestionAside.xaml
    /// </summary>
    public partial class QuizQuestionAside : System.Windows.Controls.Page
    {
        public QuizQuestionAsideViewModel QuestionVM { get; set; }
        public QuizQuestionAside(QuizQuestionAsideViewModel questionVM)
        {
            QuestionVM = questionVM;
            InitializeComponent();
            this.DataContext = QuestionVM;
            bool result = QuestionVM.Question.Solve();
        }
        public QuizQuestionAside(QuizQuestionAsideViewModel questionVM, int questionIndex)
        {
            // Instantiate the Viewmodel (and thus the old Model)
            QuestionVM = questionVM;
            if (questionIndex >= 0 && questionIndex < QuestionVM.Questionaire.Questions.Count)
            {
                QuestionVM.Question = QuestionVM.Questionaire.Questions[questionIndex];
                //QuestionVM.AnswerSelected = -1;  // Do this only forward
                ObservableCollection<Answer> answersVM = new ObservableCollection<Answer>();
                for (int i = 0; i < QuestionVM.Questionaire.Questions[questionIndex].AnswerList.Count; i++)
                {
                    answersVM.Add(QuestionVM.Questionaire.Questions[questionIndex].AnswerList[i]);
                }
                QuestionVM.Answers = answersVM;
                QuestionVM.DisplayedQuestionIndex = questionIndex;
            }
            // reset image source
            QuestionVM.PathToImage = QuestionVM.Question.PathToImage;
            InitializeComponent();
            // set the views data context to the model object in the viewmodel
            this.DataContext = QuestionVM;
        }
        public int CompletedQuestionsCount(QuizQuestionAsideViewModel questionVM)
        {
            int questionsCompleted = 0;
            foreach (Question question in questionVM.Questionaire.Questions)
                foreach (Answer answer in question.AnswerList)
                    if (answer.selectedAnswer)
                        questionsCompleted += 1;
            return questionsCompleted;
        }
        private void AnswerClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var test = sender as RadioButton;
            string str = test.Tag.ToString();
            int i = Int32.Parse(str);
            QuestionVM.AnswerClicked(i);
        }
        private void ForwardClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            // count completed question
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            if (QuestionVM.CompletedQuestions == QuestionVM.Questionaire.Questions.Count)
            {
                // get selected and correct answer ids
                int selectedAnswerID = -1;
                int correctAnswerID = -1;
                foreach (Answer answer in QuestionVM.Answers)
                {
                    if (answer.selectedAnswer)
                        selectedAnswerID = answer.index;
                    if (answer.correctAnswer)
                        correctAnswerID = answer.index;
                }
                // save AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer to history
                QuestionVM.User.UserHistory.Add(new History(QuestionVM.User.Title, QuestionVM.User.SelectedDB, QuestionVM.QuestionaireID, QuestionVM.User.QuestionLimit, QuestionVM.User.PassingPercentage, QuestionVM.Question.ID, selectedAnswerID, correctAnswerID));

                //NavigationService.Navigate(new ResultsPage(QuestionVM));
            }
            else //not answer all questions
            {
                if (QuestionVM.DisplayedQuestionIndex + 1 < QuestionVM.Questionaire.Questions.Count)
                {
                    // get selected and correct answer ids
                    int selectedAnswerID = -1;
                    int correctAnswerID = -1;
                    foreach (Answer answer in QuestionVM.Answers)
                    {
                        if (answer.selectedAnswer)
                            selectedAnswerID = answer.index;
                        if (answer.correctAnswer)
                            correctAnswerID = answer.index;
                    }
                    // save AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer to history
                    QuestionVM.User.UserHistory.Add(new History(QuestionVM.User.Title, QuestionVM.User.SelectedDB, QuestionVM.QuestionaireID, QuestionVM.User.QuestionLimit, QuestionVM.User.PassingPercentage, QuestionVM.Question.ID, selectedAnswerID, correctAnswerID));
                    // gehe zur nächsten frage
                    NavigationService.Navigate(new QuizQuestionAside(QuestionVM, QuestionVM.DisplayedQuestionIndex + 1));
                }
                else
                {
                    int positionUnansweredQuestion = 0;
                    foreach (Question question in QuestionVM.Questionaire.Questions) //go through all questions
                    {
                        bool selectedFound = false;
                        foreach (Answer answer in question.AnswerList) // go through all answered questions 
                        {
                            if (answer.selectedAnswer)
                            {
                                positionUnansweredQuestion += 1;
                                selectedFound = true;
                            }
                        }
                        if (!selectedFound)
                            NavigationService.Navigate(new QuizQuestionAside(QuestionVM, positionUnansweredQuestion)); // jump to position of Unanswered question
                    }
                }
            }
        }
        private void BackClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            if (QuestionVM.DisplayedQuestionIndex > 0)
            {
                if (QuestionVM.CompletedQuestions == QuestionVM.Questionaire.Questions.Count)
                {
                    NavigationService.Navigate(new QuizQuestionAside(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
                }
                else 
                    NavigationService.Navigate(new QuizQuestionAside(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
            }
            else 
            {
                // do nothing
            }
        }
    }
}
