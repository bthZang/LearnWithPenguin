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
        protected int _number;
        protected int _number1;
        protected int _number2;
        protected int _number3;
        protected int _number4;

        protected string _color1;
        protected string _color2;
        protected string _color3;
        protected string _color4;

        protected string _nextLevel;
        protected string _backLevel;



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
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";


                OnPropertyChanged();
            }
        }

        public int Number1
        {
            get
            {
                return _number1;
            }
            set
            {
                _number1 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";
                OnPropertyChanged();
            }
        }
        public int Number2
        {
            get
            {
                return _number2;
            }
            set
            {
                _number2 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";
                OnPropertyChanged();
            }
        }
        public int Number3
        {
            get
            {
                return _number3;
            }
            set
            {
                _number3 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";
                OnPropertyChanged();
            }
        }
        public int Number4
        {
            get
            {
                return _number4;
            }
            set
            {
                _number4 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";
                OnPropertyChanged();
            }
        }

        public string Color1
        {
            get
            {
                return _color1;
            }
            set
            {
                _color1 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";
                OnPropertyChanged();
            }
        }

        public string Color2
        {
            get
            {
                return _color2;
            }
            set
            {
                _color2 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";
                OnPropertyChanged();
            }
        }
        public string Color3
        {
            get
            {
                return _color3;
            }
            set
            {
                _color3 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";

                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";
                OnPropertyChanged();
            }
        }
        public string Color4
        {
            get
            {
                return _color4;
            }
            set
            {
                _color4 = value;
                ConcatTitle = "";
                ConcatQuestion = "";
                ConcatSource1 = "";
                ConcatSource2 = "";
                ConcatSource3 = "";
                ConcatSource4 = "";
                ConcatColor1 = "";
                ConcatColor2 = "";
                ConcatColor3 = "";
                ConcatColor4 = "";

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
                return "/images/Question/" + _number + ".mp3";
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
                return "/images/Quiz/" + _number1 + ".jpg";
                //return "/images/Quiz/" + _number1 + ".jpg";
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

                return "/images/Quiz/" + _number2 + ".jpg";
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
                return "/images/Quiz/" + _number3 + ".jpg";
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
                return "/images/Quiz/" + _number4 + ".jpg";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatColor1
        {
            get
            {
                return _color1;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatColor2
        {
            get
            {

                return _color2;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatColor3
        {
            get
            {
                return _color3;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatColor4
        {
            get
            {
                return _color4;
            }
            set
            {
                OnPropertyChanged();
            }
        }


        public ICommand CheckAnswer
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Answer();
                });
            }

            set { }
        }

        public bool Answer()
        {
            switch (Number)
            {
                case 1:
                    Color1 = "green";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                case 2:
                    
                    Color1 = "red";
                    Color2 = "red";
                    Color3 = "green";
                    Color4 = "red";
                    break;

            }

            return false;
        }

        public bool Question()
        {
            switch (Number)
            {
                case 1:
                    Number1 = 1;
                    Number2 = 2;
                    Number3 = 3;
                    Number4 = 4;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 2:
                    Number1 = 8;
                    Number2 = 6;
                    Number3 = 5;
                    Number4 = 7;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                default:
                    break;
            }

            return true;
        }

        public QuizzView1ViewModel()
        {
            this.Number = 1;
            this.Number1 = 1;
            this.Number2 = 2;
            this.Number3 = 3;
            this.Number4 = 4;


            this.Color1 = "transparent";
            this.Color2 = "transparent";
            this.Color3 = "transparent";
            this.Color4 = "transparent";
        }


        public string NextLevel
        {
            get
            {
                return _nextLevel;
            }
            set
            {
                _nextLevel = value;
                OnPropertyChanged();
            }
        }

        public string BackLevel
        {
            get
            {
                return _backLevel;
            }
            set
            {
                _backLevel = value;
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
    }
}
