using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom;
using LearnWithPenguin.ViewModel.QuizzCommands;

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

        protected string _image;

        public MediaPlayer _sound = new MediaPlayer();

        public ICommand SoundButtom
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    _sound.Open(new Uri(@"./images/Question/" + Number + ".mp3", UriKind.Relative));
                    _sound.Position = TimeSpan.Zero;
                    _sound.Play();
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

        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;

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

        public string ConcatRedGreen
        {
            get
            {
                return _image;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public bool GreenRed()
        {
            switch (Number1)
            {

                case 1:
                    Image = "greenTick.png";
                    break;
                case 3:
                    Image = "greenTick.png";
                    break;
                case 6:
                    Image = "greenTick.png";
                    break;
                case 8:
                    Image = "greenTick.png";
                    break;
                case 11:
                    Image = "greenTick.png";
                    break;
                case 15:
                    Image = "greenTick.png";
                    break;
                default:
                    Image = "redCross.png";
                    break;
            }
            switch (Number2)
            {
                case 10:
                    Image = "greenTick.png";
                    break;
                case 13:
                    Image = "greenTick.png";
                    break;
                default:
                    Image = "redCross.png";

                    break;
            }
            switch (Number3)
            {
                case 2:
                    Image = "greenTick.png";
                    break;
                case 4:
                    Image = "greenTick.png";
                    break;
                case 7:
                    Image = "greenTick.png";
                    break;
                case 12:
                    Image = "greenTick.png";
                    break;
                default:
                    Image = "redCross.png";

                    break;
            }
            switch (Number4)
            {
                case 5:
                    Image = "greenTick.png";
                    break;
                case 9:
                    Image = "greenTick.png";
                    break;
                case 14:
                    Image = "greenTick.png";
                    break;
                default:
                    Image = "redCross.png";
                    break;

            }

            return true;
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
                case 3:
                    Color1 = "green";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                case 4:
                    Color1 = "red";
                    Color2 = "red";
                    Color3 = "green";
                    Color4 = "red";
                    break;
                case 5:
                    Color1 = "red";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "green";
                    break;
                case 6:
                    Color1 = "green";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                case 7:
                    Color1 = "red";
                    Color2 = "red";
                    Color3 = "green";
                    Color4 = "red";
                    break;
                case 8:
                    Color1 = "green";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                case 9:
                    Color1 = "red";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "green";
                    break;
                case 10:
                    Color1 = "red";
                    Color2 = "green";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                case 11:
                    Color1 = "green";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                case 12:
                    Color1 = "red";
                    Color2 = "red";
                    Color3 = "green";
                    Color4 = "red";
                    break;
                case 13:
                    Color1 = "red";
                    Color2 = "green";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                case 14:
                    Color1 = "red";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "green";
                    break;
                case 15:
                    Color1 = "green";
                    Color2 = "red";
                    Color3 = "red";
                    Color4 = "red";
                    break;
                default:
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
                case 3:
                    Number1 = 9;
                    Number2 = 10;
                    Number3 = 11;
                    Number4 = 12;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 4:
                    Number1 = 15;
                    Number2 = 14;
                    Number3 = 13;
                    Number4 = 16;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 5:
                    Number1 = 20;
                    Number2 = 18;
                    Number3 = 19;
                    Number4 = 17;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 6:
                    Number1 = 21;
                    Number2 = 22;
                    Number3 = 23;
                    Number4 = 24;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 7:
                    Number1 = 27;
                    Number2 = 26;
                    Number3 = 25;
                    Number4 = 28;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 8:
                    Number1 = 29;
                    Number2 = 30;
                    Number3 = 31;
                    Number4 = 32;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 9:
                    Number1 = 36;
                    Number2 = 34;
                    Number3 = 35;
                    Number4 = 33;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 10:
                    Number1 = 38;
                    Number2 = 37;
                    Number3 = 39;
                    Number4 = 40;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 11:
                    Number1 = 41;
                    Number2 = 42;
                    Number3 = 43;
                    Number4 = 44;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 12:
                    Number1 = 47;
                    Number2 = 46;
                    Number3 = 45;
                    Number4 = 48;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 13:
                    Number1 = 50;
                    Number2 = 49;
                    Number3 = 51;
                    Number4 = 52;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 14:
                    Number1 = 56;
                    Number2 = 54;
                    Number3 = 55;
                    Number4 = 53;
                    Color1 = "transparent";
                    Color2 = "transparent";
                    Color3 = "transparent";
                    Color4 = "transparent";
                    break;
                case 15:
                    Number1 = 57;
                    Number2 = 58;
                    Number3 = 59;
                    Number4 = 60;
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

            _sound.Open(new Uri(@"./images/Question/1.mp3", UriKind.Relative));

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



        protected BaseViewModel _navigatetoResult = null;

        public BaseViewModel NavigatetoResult
        {
            get
            {
                return _navigatetoResult;
            }
            set
            {
                _navigatetoResult = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowResult
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoResult = new QuizResultViewModel();
                });
            }
        }
        public ICommand HideResult
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoResult = null;
                });
            }

            set { }
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
    }
}
