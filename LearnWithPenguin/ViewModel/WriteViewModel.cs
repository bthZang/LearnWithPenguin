﻿using System;
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
            this._Star1 = "yellow";
            this._Star2 = "white";
            this._Star3 = "white";
            this._Star4 = "white";
            this._Star5 = "white";
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
                return "./TapViet/ChuThuong" + _number + ".mp4";
                //return "/TapViet/ChuThuong/" + _number + ".mp4";
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
                return "/TapViet/ChuDut/" + _number + ".png";
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
                return "/TapViet/ChuLien/" + _number + ".png";
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
                    if (distance < 20)
                        isCorrect = true;
                }

                if (isCorrect)
                    point += 1;
            }

            if (point >= 3)
            {
                _submit = true;

                switch (point)
                {
                    case 3:
                    case 4:
                        Star4 = Star5 = "white";
                        break;
                    case 5:
                        Star4 = "yellow";
                        Star5 = "white";
                        break;
                    case 6:
                        Star4 = Star5 = "yellow";
                        break;
                    default:
                        Star4 = Star5 = "yellow";
                        break;
                }
            }
            else
            {
                _submit = false;

                switch (point)
                {
                    case 1:
                        Star1 = "yellow";
                        Star2 = "white";
                        break;
                    case 2:
                        Star1 = Star2 = "yellow";
                        break;
                    default:
                        Star1 = "yellow";
                        Star2 = "white";
                        break;
                }
            }

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


        //star

        public string _Star1;
        public string _Star2;
        public string _Star3;
        public string _Star4;
        public string _Star5;

        public string Star1
        {
            get
            {
                return _Star1;
            }
            set
            {
                _Star1 = value;
                ChangeColor1 = "";
                OnPropertyChanged();
            }
        }

        public string ChangeColor1
        {
            get
            {
                return "/UserControls/" + _Star1 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string Star2
        {
            get
            {
                return _Star2;
            }
            set
            {
                _Star2= value;
                ChangeColor2 = "";
                OnPropertyChanged();
            }
        }


        public string ChangeColor2
        {
            get
            {
                return "/UserControls/" + _Star2 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string Star3
        {
            get
            {
                return _Star3;
            }
            set
            {
                _Star3= value;
                ChangeColor3 = "";
                OnPropertyChanged();
            }
        }


        public string ChangeColor3
        {
            get
            {
                return "/UserControls/" + _Star3 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string Star4
        {
            get
            {
                return _Star4;
            }
            set
            {
                _Star4= value;
                ChangeColor4 = "";
                OnPropertyChanged();
            }
        }


        public string ChangeColor4
        {
            get
            {
                return "/UserControls/" + _Star4 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string Star5
        {
            get
            {
                return _Star5;
            }
            set
            {
                _Star5 = value;
                ChangeColor5 = "5";
                OnPropertyChanged();
            }
        }


        public string ChangeColor5
        {
            get
            {
                return "/UserControls/" + _Star5 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }


        //endstar
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

        public bool _isReplay = false;

        public bool IsReplay
        {
            get
            {
                return _isReplay;
            }
            set
            {
                _isReplay = value;
            }
        }

        private ICommand _replay;
        public ICommand Replay
        {
            get
            {
                return _replay;
            }

            set { _replay = value; }
        }
    }

}




