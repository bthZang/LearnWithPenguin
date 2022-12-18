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
        protected int _number;
      
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
                return "\\Question\\" + _number + ".mp3";
            }
            set
            {
                OnPropertyChanged();
            }
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
        public ICommand _onclickHandleNextLevel;
        public ICommand OnclickHandleNextLevel
        {
            get
            {
                return _onclickHandleNextLevel;
            }

            set { _onclickHandleNextLevel = value; OnPropertyChanged(); }
        }

    }
}
