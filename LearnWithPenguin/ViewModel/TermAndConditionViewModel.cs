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
