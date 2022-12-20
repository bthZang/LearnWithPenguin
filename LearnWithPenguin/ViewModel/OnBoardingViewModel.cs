using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LearnWithPenguin.UserControl;
using LearnWithPenguin.UserControls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnWithPenguin.ViewModel
{
    public class OnBoardingViewModel : BaseViewModel
    {
        private BaseViewModel _PartOnBoarding;

        private bool _next;
        public bool Next
        {
            get { return _next; }
            set
            {
                _next = value;
                if (_next == true)
                    obacity = "/UserControls/next.png";
                else
                {

                    obacity = "/UserControls/BlurNext.png";
                }
                OnPropertyChanged();
            }
        }

        private string _obacity;

        public string obacity
        {
            get
            {
                return _obacity;

            }
            set
            {

                _obacity = value;
                OnPropertyChanged();
            }
        }

    

        public BaseViewModel PartOnBoarding
        {
            get
            {
                return _PartOnBoarding;
            }
            set
            {
                _PartOnBoarding = value;
                OnPropertyChanged();
            }
        }

        public ICommand Show
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new LoginViewModel();
                });
            }

            set { }
        }

        public ICommand TransformToRegester
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new RegisterViewModel();
                });
            }

            set { }
        }

        public OnBoardingViewModel()
        {
            this.PartOnBoarding = new TextOnBoardingViewModel();
            this.PartOnBoardingTerm = new TermAndConditionViewModel();
            this.obacity = "/UserControls/BlurNext.png";



        }

        private BaseViewModel _partOnBoardingTerm;

        public BaseViewModel PartOnBoardingTerm
        {
            get
            {
                return _partOnBoardingTerm;
            }
            set
            {
                _partOnBoardingTerm = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowTerm
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new TermAndConditionViewModel();
                });
            }

            set { }
        }
        public ICommand HideTerm
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new TextOnBoardingViewModel();
                });
            }

            set { }
        }


        //private BaseViewModel _;

        //public BaseViewModel PartOnBoarding
        //{
        //    get
        //    {
        //        return _PartOnBoarding;
        //    }
        //    set
        //    {
        //        _PartOnBoarding = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public ICommand Show
        //{
        //    get
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            PartOnBoarding = new TermAndConditionViewModel();
        //        });
        //    }

        //    set { }
        //}

    }
}
