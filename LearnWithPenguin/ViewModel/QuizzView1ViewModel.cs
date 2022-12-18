using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace LearnWithPenguin.ViewModel
{
    internal class QuizzView1ViewModel : BaseViewModel
    {
        protected BaseViewModel _navigateToQuizzView1;
        Number0 _number0 = new Number0();
        Number0 _number1 = new Number0();
        Number0 _number2 = new Number0();
        Number0 _number3 = new Number0();

        protected int _number = 1;

        public class Number0
        {
            public int name = 1;
            public bool correct = false;
        }//dap an
       


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


        //public bool SetAnswer()
        //{
           
        //    bool correct = false;
        //    List<int> _correctAnswer = new List<int>() { 1, 5, 9, 13, 21, 25, 29, 33, 37, 41, 45 };
        //    switch (_number)
        //    {
        //        case 1:
        //            _number0.name = 1;
        //            _number0.correct = true;
        //            _number1.name = 3;
        //            _number2.name = 2;
        //            _number3.name = 4;
        //            break;
        //        case 2:
        //            _number0.name = 5;
        //            _number0.correct = true;
        //            _number1.name = 6;
        //            _number2.name = 7;
        //            _number3.name = 8;
        //            break;
        //        case 3:
        //            _number0.name = 11;
        //            _number1.name = 10;
        //            _number2.name = 9;
        //            _number2.correct = true;
        //            _number3.name = 12;
        //            break;
        //        case 4:
        //            _number0.name = 16;
        //            _number1.name = 14;
        //            _number2.name = 15;
        //            _number3.name = 13;
        //            _number3.correct = true;
        //            break;
        //        case 5:
        //            _number0.name = 18;
        //            _number1.name = 17;
        //            _number1.correct = true;
        //            _number2.name = 19;
        //            _number3.name = 20;
        //            break;
        //        case 6:
        //            _number0.name = 23;
        //            _number1.name = 22;
        //            _number2.name = 21;
        //            _number2.correct = true;
        //            _number3.name = 24;
        //            break;
        //        case 7:
        //            _number0.name = 28;
        //            _number1.name = 26;
        //            _number2.name = 27;
        //            _number3.name = 25;
        //            _number3.correct = true;
        //            break;
        //        case 8:
        //            _number0.name = 29;
        //            _number0.correct = true;
        //            _number1.name = 30;
        //            _number2.name = 31;
        //            _number3.name = 32;
        //            break;
        //        case 9:
        //            _number0.name = 35;
        //            _number1.name = 34;
        //            _number2.name = 33;
        //            _number2.correct = true;
        //            _number3.name = 36;
        //            break;
        //        case 10:
        //            _number0.name = 40;
        //            _number1.name = 38;
        //            _number2.name = 39;
        //            _number3.name = 37;
        //            _number3.correct = true;
        //            break;
        //        case 11:
        //            _number0.name = 41;
        //            _number0.correct = true;
        //            _number1.name = 42;
        //            _number2.name = 43;
        //            _number3.name = 44;
        //            break;
        //        case 12:
        //            _number0.name = 47;
        //            _number1.name = 46;
        //            _number2.name = 45;
        //            _number2.correct = true;
        //            _number3.name = 48;
        //            break;
        //        case 13:
        //            _number0.name = 50;
        //            _number1.name = 49;
        //            _number1.correct = true;
        //            _number2.name = 51;
        //            _number3.name = 52;
        //            break;
        //        case 14:
        //            _number0.name = 53;
        //            _number0.correct = true;
        //            _number1.name = 54;
        //            _number2.name = 55;
        //            _number3.name = 56;
        //            break;
        //        case 15:
        //            _number0.name = 60;
        //            _number1.name = 58;
        //            _number2.name = 59;
        //            _number3.name = 57;
        //            _number3.correct = true;
        //            break;
        //        default:
        //            break;
        //    }

            

        //}

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
                return "E:\\Visual Programming\\LearnWithPenguin\\LearnWithPenguin\\images\\Question" + _number + ".mp3";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatSource1
        {
            get 
            {
                return "\\images\\Quiz\\" + _number0.name + ".jpg";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatSource2
        {
            get
            {
                return "images\\Quiz\\" + _number1.name + ".jpg";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatSource3
        {
            get
            {
                return "images\\Quiz\\" + _number2.name + ".jpg";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatSource4
        {
            get
            {
                return "images\\Quiz\\" + _number3.name + ".jpg";
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
                return _menu;
            }
            set
            {
                _menu = value;
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


    }
}
