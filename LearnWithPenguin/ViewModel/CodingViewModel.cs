
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class CodingViewModel : BaseViewModel
    {
        public ICommand ReviewTransform { get; set; }
        public ICommand PlayTransform { get; set; }
        public ICommand ForwardCommand { get; set; }
        public ICommand BackwardCommand { get; set; }


        private string _PositionNumber;
        public string PositionNumber { get { return _PositionNumber; } set { _PositionNumber = value; OnPropertyChanged(); } }

        private string _GameTurn;
        public string GameTurn { get { return _GameTurn; } set { _GameTurn = value; OnPropertyChanged(); } }

        public CodingViewModel()
        {
            ReviewTransform = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => { });
            PlayTransform = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => { });

            PositionNumber = "1";
            ForwardCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                int getNum = Convert.ToInt32(PositionNumber);
                if (getNum == 3)
                    goto stopNum;
                getNum++;
                stopNum:
                PositionNumber = Convert.ToString(getNum);
            });

            BackwardCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                int getNum = Convert.ToInt32(PositionNumber);
                if (getNum == 1)
                    goto stopNum;
                getNum--;
                stopNum:
                PositionNumber = Convert.ToString(getNum);
            });

        }
    }
}
