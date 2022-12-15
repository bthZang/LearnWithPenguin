using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Forms;
namespace LearnWithPenguin.ViewModel
{
    internal class QuizzView1ViewModel: BaseViewModel
    {
        protected BaseViewModel _navigateToQuizzView1;
        protected int _number = 1;

        protected string _isDisplayQuestion;
        public string IsDisplayQuestion
        {
            get
            {
                return _isDisplayQuestion;
            }
            set
            {
                _isDisplayQuestion = value;
                OnPropertyChanged();
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                OnPropertyChanged();
            }
        }

        public string ConcatTitle
        {
            get
            {
                return "Bài " + _number;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatQuestion
        {
            get
            {
                return "LearnWithPenguine\\images\\Question\\" + _number + ".mp3";
            }
            set
            {
                OnPropertyChanged();
            }
        }
        

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

        public ICommand _onclickHandleNextLevel;
        public ICommand OnclickHandleNextLevel
        {
            get
            {
                return _onclickHandleNextLevel;
            }

            set { _onclickHandleNextLevel = value; OnPropertyChanged(); }
        }

        public ICommand _onclickHandlePreviousLevel;
        public ICommand OnclickHandlePreviousLevel
        {
            get
            {
                return _onclickHandlePreviousLevel;
            }

            set { _onclickHandlePreviousLevel = value; OnPropertyChanged(); }
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
