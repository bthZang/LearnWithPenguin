//using LearnWithPenguin.Models;
//using LearnWithPenguin.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace LearnWithPenguin.View
//{
//    /// <summary>
//    /// Interaction logic for PuzzleView.xaml
//    /// </summary>
//    public partial class PuzzleView : System.Windows.Controls.Page
//    {
//        public QuizQuestionAsideViewModel QuestionVM { get; set; }
//        public PuzzleView()
//        {
//            InitializeComponent();

//        }
//        public PuzzleView(QuizQuestionAsideViewModel questionVM)
//        {
//            QuestionVM = questionVM;
//            this.DataContext = QuestionVM;
//        }

//        private void StartClicked(object sender, RoutedEventArgs e)
//        {
//            QuizQuestionAsideViewModel currentQuestionVM = QuestionVM;
//            NavigationService.Navigate(new QuizQuestionAside(new QuizQuestionAsideViewModel(/*currentQuestionVM*/)));
//        }

//        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
//        {
//            QuestionVM = dockpanel.DataContext as QuizQuestionAsideViewModel;
//            this.DataContext = QuestionVM;
//        }
//    }
//}
