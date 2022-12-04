using System;
using System.Collections.Generic;
using System.Diagnostics;
using LearnWithPenguin.Models;
using LearnWithPenguin.ViewModel.QuizzCommands;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class QuestionViewModel : BaseViewModel
    {
        // selected Questionaire
        private Questionaire questionaire;
        // question to display
        private Question question;
        // answers to display
        private ObservableCollection<Answer> answers;
        // number of questions with selected answers
        private int completedQuestions;
        // index of displayed question
        private int displayedQuestionIndex;
        // the User History, Settings, etc.
        private User user;
        // the wrong questions for results page
        private ObservableCollection<WrongAnswer> wrongAnswers;
        private string pathToImage;
        private ImageSource imageSource;
        // the selected/displayed questionaire id and the list for selection (from class user, TODO: get from db there)
        private int questionaireID;
        private ObservableCollection<int> questionaireIDList;
        // the displayed history results
        private ObservableCollection<string> questionaireHistory;
        // Debug-Properties
        private int questionLimit;

        public QuestionViewModel()
        {
            // Instantiate the defaultUser for the view
            User = new User();
            // Load defaultUser.txt if it exists
            User.ReadCSVFile();
            // Load Settings
            User.LoadSettings();
            // create the questionnaire id, add to list
            QuestionaireIDList = new ObservableCollection<int>();
            QuestionaireID = 1;
            QuestionaireIDList.Add(QuestionaireID);

            // create the model
            Questionaire = new Questionaire(0, questionaireID);
            // create the displayed question
            Question = Questionaire.Questions[0];
            // fills the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < Question.AnswerList.Count; i++)
            {
                Answers.Add(new Answer(i, Question.AnswerList[i].text, Question.AnswerList[i].correctAnswer, Question.AnswerList[i].selectedAnswer));
            }
            // set these counters for logic and display
            CompletedQuestions = 0; // answers selected by user, wrapping
            DisplayedQuestionIndex = 0; // base 0 for navigation, wrapping
            // image string path
            PathToImage = Question.PathToImage;
            // image source from string
            ImageSource = new BitmapImage(new Uri(@"" + Question.PathToImage, UriKind.Relative));
            // for results page
            WrongAnswers = new ObservableCollection<WrongAnswer>();
            // display the user history
            ShowHistory();

        }
        public void ShowHistory()
        {
            QuestionaireHistory = new ObservableCollection<string>();
            // display the history like this: "Sportbootführerschein Binnen (Fragebogen 10) - bestanden"
            foreach (string questionaireResult in User.EvaluateHistory())
                QuestionaireHistory.Add(questionaireResult);
        }
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public Question Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }
        public ObservableCollection<Answer> Answers
        {
            get { return answers; }
            set
            {
                answers = value;
                OnPropertyChanged("Answers");
            }
        }
        public int QuestionaireID
        {
            get { return questionaireID; }
            set
            {
                questionaireID = value;
                OnPropertyChanged("QuestionaireID");
            }
        }
        public ObservableCollection<int> QuestionaireIDList
        {
            get { return questionaireIDList; }
            set
            {
                questionaireIDList = value;
                OnPropertyChanged("QuestionaireIDList");
            }
        }
        public Questionaire Questionaire
        {
            get { return questionaire; }
            set
            {
                questionaire = value;
                OnPropertyChanged("Questionaire");
            }
        }
        public ObservableCollection<WrongAnswer> WrongAnswers
        {
            get { return wrongAnswers; }
            set
            {
                wrongAnswers = value;
                OnPropertyChanged("WrongAnswers");
            }
        }
        public int CompletedQuestions
        {
            get { return completedQuestions; }
            set
            {
                completedQuestions = value;
                OnPropertyChanged("CompletedQuestions");
            }
        }
        public int DisplayedQuestionIndex
        {
            get { return displayedQuestionIndex; }
            set
            {
                displayedQuestionIndex = value;
                OnPropertyChanged("DisplayedQuestionIndex");
            }
        }
        public string PathToImage
        {
            get { return pathToImage; }
            set
            {
                ImageSource = new BitmapImage(new Uri(@"" + value, UriKind.Relative));
                pathToImage = value;
                OnPropertyChanged("PathToImage");
            }
        }
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
        public int QuestionLimit
        {
            get { return questionLimit; }
            set
            {
                questionLimit = value;
                OnPropertyChanged("QuestionLimit");
            }
        }
        public ObservableCollection<string> QuestionaireHistory
        {
            get { return questionaireHistory; }
            set
            {
                questionaireHistory = value;
                OnPropertyChanged("QuestionaireHistory");
            }
        }

        public ICommand AnswerClickedCommand
        {
            get
            {
                return new DelegatingCommand(o => AnswerClicked((int)o));
            }
        }
        public void AnswerClicked(int o)
        {
            Question.AnswerClicked(o);
            OnPropertyChanged("AnswerSelected");
        }
    }
}
