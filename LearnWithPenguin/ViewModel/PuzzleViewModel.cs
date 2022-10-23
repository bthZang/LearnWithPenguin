using System.Runtime.CompilerServices;
using LearnWithPenguin.UserControl;
using LearnWithPenguin.UserControls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnWithPenguin.ViewModel
{
    public class PuzzleViewModel : BaseViewModel
    {
        protected BaseViewModel _navigateHome;
        public BaseViewModel NavigateHome
        {
            get
            {
                return _navigateHome;
            }
            set
            {
                _navigateHome = value;
                OnPropertyChanged();
            }
        }
        protected BaseViewModel _navigateToQuizzView1;
        public BaseViewModel NavigateToQuizzView1
        {
            get
            {
                return _navigateToQuizzView1;
            }
            set
            {
                _navigateToQuizzView1 = value;
                OnPropertyChanged();
            }
        }
    }
}
