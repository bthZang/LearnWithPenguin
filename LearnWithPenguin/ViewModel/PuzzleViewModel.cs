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
        protected BaseViewModel _navigateToQuizzView2;
        public BaseViewModel NavigateToQuizzView2
        {
            get
            {
                return _navigateToQuizzView2;
            }
            set
            {
                _navigateToQuizzView2 = value;
                OnPropertyChanged();
            }
        }


        protected MainViewModel _navigateToQuizAside;
        public MainViewModel NavigateQuizAside
        {
            get
            {
                return _navigateToQuizAside;
            }
            set
            {
                _navigateToQuizAside = value;
                OnPropertyChanged();
            }
        }


        private BaseViewModel _menu;

        public BaseViewModel Menu
        {
            get
            {
                return _menu;
            }
            set
            {
                _menu = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowMenu
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Menu = new MenuViewModel();
                });
            }

            set { }
        }
    }
}
