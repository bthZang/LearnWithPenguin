using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    internal class QuizzView1ViewModel: BaseViewModel
    {
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
