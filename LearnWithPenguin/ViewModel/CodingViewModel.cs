using LearnWithPenguin.UserControls;
using LearnWithPenguin.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;

namespace LearnWithPenguin.ViewModel
{
    public class CodingViewModel : BaseViewModel
    {
        protected BaseViewModel _navigatetoView;
        public BaseViewModel NavigatetoView { get { return _navigatetoView; } set { _navigatetoView = value; OnPropertyChanged(); } }
        public ICommand ReviewTransform { get; set; }
        public ICommand PlayTransform { 
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoView = new GameViewModel();
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
        private string _GameView;
        public string GameView { get { return _GameView; } set { _GameView = value; OnPropertyChanged(); } }

        public CodingViewModel()
        {
            PositionNumber = "1";
           
            GameView = @"/images/game1@3x.png";

            ForwardCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int getNum = Convert.ToInt32(PositionNumber);
                if (getNum == 3)
                    goto stopNum;
                getNum++;
            stopNum:
                PositionNumber = Convert.ToString(getNum);

                switch (getNum)
                {
                    case 1:
                        string gv1 = @"/images/game1@3x.png";
                        GameView = gv1;
                        break;
                    case 2:
                        string gv2 = @"/images/game2@3x.png";
                        GameView = gv2;
                        break;
                    case 3:
                        string gv3 = @"/images/game3@3x.png";
                        GameView = gv3;
                        break;
                }
            });

            BackwardCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int getNum = Convert.ToInt32(PositionNumber);
                if (getNum == 1)
                    goto stopNum;
                getNum--;
            stopNum:
                PositionNumber = Convert.ToString(getNum);
                switch (getNum)
                {
                    case 1:
                        string gv1 = @"/images/game1@3x.png";
                        GameView = gv1;
                        break;
                    case 2:
                        string gv2 = @"/images/game2@3x.png";
                        GameView = gv2;
                        break;
                    case 3:
                        string gv3 = @"/images/game3@3x.png";
                        GameView = gv3;
                        break;
                }
            });

            //ReviewTransform = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => { });

            //this.NavigatetoView = new GameViewModel();
            //PlayTransform = new RelayCommand<System.Windows.Controls.UserControl>((p) =>
            //{
            //    return true;
            //}, (p) =>
            //{
            //    NavigatetoView = new GameViewModel();
            //});
        }
}
}
