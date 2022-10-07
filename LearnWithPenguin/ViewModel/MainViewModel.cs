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
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _PartOnBoarding;
        public BaseViewModel PartOnBoarding
        {
            get
            {
                return _PartOnBoarding;
            }
            set
            {
                _PartOnBoarding = value;
                    Console.WriteLine("hyyy");
                OnPropertyChanged();
            }
        }

        public ICommand Show
        {
            get
            {
                //MessageBox.Show("Hyyyyy");

                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new LoginViewModel();
                });
            }

            set { }
        }

        public MainViewModel()
        {
            this.PartOnBoarding = new TextOnBoardingViewModel();
        }
    }
}
