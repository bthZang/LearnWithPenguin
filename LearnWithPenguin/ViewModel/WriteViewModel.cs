using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace LearnWithPenguin.ViewModel
{
    public class WriteViewModel : BaseViewModel
    {
        protected string _isDisplayVideo;
        protected int _number;
        protected string _nextLevel;
        protected string _backLevel;



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
    }

}
