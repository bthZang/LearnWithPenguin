using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Forms;

namespace LearnWithPenguin.ViewModel
{
    public class WriteViewModel : BaseViewModel
    {
        protected string _isDisplayVideo;
        protected int _number;
        protected string _nextLevel;
        protected string _backLevel;
        protected bool _submit = false;


        protected BaseViewModel _navigatetoResult = null;


        public string IsDisplayVideo
        {
            get
            {
                return _isDisplayVideo;
            }
            set
            {
                _isDisplayVideo = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReplayVideo
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    IsDisplayVideo = "Visible";
                });
            }

            set { }
        }

        public WriteViewModel()
        {
            this.IsDisplayVideo = "Hidden";
            this.Number = 1;
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
                ConcatVideo = "";
                SouceDash = "";
                SouceSolid = "";

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

        public string ConcatVideo
        {
            get
            {
                return "D:\\Zangg\\Penguin\\UIT\\HK3-II\\LTTQ\\Chu_Thuong\\" + _number + ".mp4";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string SouceDash
        {
            get
            {
                return "D:\\Zangg\\Penguin\\UIT\\HK3-II\\LTTQ\\Chu_Dut\\" + _number + ".png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string SouceSolid
        {
            get
            {
                return "D:\\Zangg\\Penguin\\UIT\\HK3-II\\LTTQ\\Chu_Lien\\" + _number + ".png";
            }
            set
            {
                OnPropertyChanged();
            }
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

        public ICommand OnclickHandleNextLevel
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Number = Number + 1;
                });
            }

            set { }
        }

        public ICommand OnclickHandlePreviousLevel
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    if (Number == 1)
                        Number = 1;
                    else
                        Number = Number - 1;
                });
            }

            set { }
        }

        public bool IsMouseDown
        {
            get
            {
                //System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed
                if ((System.Windows.Forms.Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
                    return true;
                return false;
            }
            set { }
        }

        public List<Point> mousePositions = new List<Point>();

        public void AddPosition(Point point)
        {
            mousePositions.Add(point);
        }

        public bool Submit()
        {
            float[] _positionX;
            float[] _positionY;

            switch (_number)
            {
                case 1:
                    _positionX = new float[6] { 617, 536, 425, 537, 664, 734 };
                    _positionY = new float[6] { 509, 381, 511, 634, 632, 534 };
                    break;

                default:
                    _positionX = new float[6] { 617, 536, 425, 537, 664, 734 };
                    _positionY = new float[6] { 509, 381, 511, 634, 632, 534 };
                    break;
            }

            int point = 1;

            for (int i = 0; i < 6; i++)
            {
                bool isCorrect = false;

                foreach (Point mousePoint in mousePositions)
                {
                    double distance = Math.Sqrt(Math.Pow(mousePoint.X - _positionX[i], 2) + Math.Pow(mousePoint.Y - _positionY[i], 2));
                    if (distance < 10)
                        isCorrect = true;
                }

                if (isCorrect)
                    point += 1;
            }
            if (point >= 3)
                _submit = true;
            else
                _submit = false;

            return _submit;
        }
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
                    Submit();
                    if (_submit == true)
                        NavigatetoResult = new GoodResultViewModel();
                    else
                        NavigatetoResult = new BadResultViewModel();
                });
            }

            set { }
        }


    }

}
