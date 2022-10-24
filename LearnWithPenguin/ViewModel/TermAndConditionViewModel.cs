using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class TermAndConditionViewModel : BaseViewModel
    {
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
                    obacity = "/UserControls/BlurNext.png";

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

        public TermAndConditionViewModel()
        {
            obacity = "/UserControls/BlurNext.png";
            //Back = new TermAndConditionViewModel();
        }

        //public System.Windows.Controls.
        //public ICommand Next
        //{ 
        //    get { return }
        //    set {}
        //}


        //nut back ne

        protected BaseViewModel _back;



        public BaseViewModel Back
        {
            get
            {
                return _back;
            }
            set
            {
                _back = value;
                OnPropertyChanged();
            }
        }

        public ICommand BackBottom
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Back = new TextOnBoardingViewModel();
                });
            }

            set { }
        }


    }
}
