using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace LearnWithPenguin.ViewModel
{
    public class BackViewModel : BaseViewModel
    {
        private int _PositionNumber;
        public int PositionNumber { get { return _PositionNumber; } set { _PositionNumber = value; OnPropertyChanged(); } }
        public ICommand BackCommand { get; set; }
        public ICommand ForwardCommand { get; set; }

        public BackViewModel()
        {
            PositionNumber = 1;

            BackCommand = new RelayCommand<System.Windows.Controls.UserControl>((p) => { 
                if (PositionNumber == 1)
                    return false;
                return true;
            }, 
                
            (p) => {
                PositionNumber--;
            });
            ForwardCommand = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => {
                PositionNumber++;
            });
        }
    }
}
