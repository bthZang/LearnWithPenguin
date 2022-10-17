using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
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
    public class MainViewModel : BaseViewModel
    {

        protected BaseViewModel _navigatetoHome;

        public MainViewModel()
        {
            this.NavigatetoHome = new OnBoardingViewModel();

        }

        public BaseViewModel NavigatetoHome
        {
            get
            {
                return _navigatetoHome;
            }
            set
            {
                _navigatetoHome = value;
                OnPropertyChanged();
            }
        }
        public ICommand TransformToRead
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new ReadViewModel();
                });
            }

            set { }
        }
        public ICommand TransformToWrite
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new WriteViewModel();
                });
            }

            set { }
        }
        public ICommand TransformToPuzzle
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new PuzzleViewModel();
                });
            }

            set { }
        }
        public ICommand TransformToCoding
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new CodingViewModel();
                });
            }

            set { }
        }
        public ICommand Transform
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new HomeViewModel();                    
                });
            }

            set { }
        }


        
    }
}
