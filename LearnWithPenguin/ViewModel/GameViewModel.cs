using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Security.Permissions;

namespace LearnWithPenguin.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        protected BaseViewModel _navigatetoCoding;

        public BaseViewModel NavigatetoCoding
        {
            get
            {
                return _navigatetoCoding;
            }
            set
            {
                _navigatetoCoding = value;
                OnPropertyChanged();
            }
        }

        public ICommand TransformToCoding
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoCoding = new CodingViewModel();
                });
            }

            set { }
        }

        public ICommand ForwardCommand { get; set; }
        public ICommand BackwardCommand { get; set; }


        private string _PositionNumber;
        public string PositionNumber { get { return _PositionNumber; } set { _PositionNumber = value; OnPropertyChanged(); } }

        private string _GameTurn;
        public string GameTurn { get { return _GameTurn; } set { _GameTurn = value; OnPropertyChanged(); } }

        public GameViewModel()
        {

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