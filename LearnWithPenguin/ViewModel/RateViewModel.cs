using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    internal class RateViewModel : BaseViewModel
    {
        protected string _colour1;
        protected string _colour2;
        protected string _colour3;
        protected string _colour4;
        protected string _colour5;


        public string Colour1
        {
            get
            {
                return _colour1;
            }
            set
            {
                _colour1 = value;
                ChangeColor1 = "";
                OnPropertyChanged();
            }
        }

        public string Colour2
        {
            get
            {
                return _colour2;
            }
            set
            {
                _colour2 = value;
                ChangeColor2 = "";
                OnPropertyChanged();
            }
        }
        public string Colour3
        {
            get
            {
                return _colour3;
            }
            set
            {
                _colour3 = value;
                ChangeColor3 = "";
                OnPropertyChanged();
            }
        }
        public string Colour4
        {
            get
            {
                return _colour4;
            }
            set
            {
                _colour4 = value;
                ChangeColor4 = "";
                OnPropertyChanged();
            }
        }
        public string Colour5
        {
            get
            {
                return _colour5;
            }
            set
            {
                _colour5 = value;
                ChangeColor5 = "";
                OnPropertyChanged();
            }
        }

        public RateViewModel()
        {
            this._colour1 = "white";
            this._colour2 = "white";
            this._colour3 = "white";
            this._colour4 = "white";
            this._colour5 = "white";
        }

        public string ChangeColor1
        {
            get
            {
                return "/View/" + _colour1 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ChangeColor2
        {
            get
            {
                return "/View/" + _colour2 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ChangeColor3
        {
            get
            {
                return "/View/" + _colour3 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ChangeColor4
        {
            get
            {
                return "/View/" + _colour4 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ChangeColor5
        {
            get
            {
                return "/View/" + _colour5 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public ICommand Rate1
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Colour1 = "yellow";
                    Colour2 = Colour3 = Colour4 = Colour5 = "white";

                });
            }
            set { }
        }

        public ICommand Rate2
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Colour1 = Colour2 = "yellow";
                    Colour4 = Colour3 = Colour5 = "white";
                });
            }
            set { }
        }

        public ICommand Rate3
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Colour1 = Colour2 = Colour3 = "yellow";
                    Colour4 = Colour5 = "white";
                });
            }
            set { }
        }

        public ICommand Rate4
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Colour1 = Colour2 = Colour4 = Colour3 = "yellow";
                    Colour5 = "white";
                });
            }
            set { }
        }

        public ICommand Rate5
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Colour1 = Colour2 = Colour4 = Colour3 = Colour5 = "yellow";
                });
            }
            set { }
        }


    }
}
