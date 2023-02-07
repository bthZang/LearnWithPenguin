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

namespace LearnWithPenguin.UserControls
{
    /// <summary>
    /// Interaction logic for EndQuizBadResult.xaml
    /// </summary>
    public partial class EndQuizBadResult : System.Windows.Controls.UserControl
    {
        public EndQuizBadResult()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty EndQuizProperty =
  DependencyProperty.Register("EndQuiz", typeof(ICommand), typeof(EndQuizBadResult), new UIPropertyMetadata());

        public ICommand EndQuiz
        {
            get { return (ICommand)GetValue(EndQuizProperty); }
            set { SetValue(EndQuizProperty, value); }
        }
    }
}
