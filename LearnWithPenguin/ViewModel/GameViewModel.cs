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
using LearnWithPenguin.UserControls;
using System.Windows.Navigation;

namespace LearnWithPenguin.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        protected BaseViewModel _navigatetoCoding;

        private System.Windows.Controls.UserControl _GameTurn;
        public System.Windows.Controls.UserControl GameTurn { get { return _GameTurn; } set { _GameTurn = value; OnPropertyChanged(); } }

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
        public ICommand HandleButtonPress { get; set; }

        private string _ImgSrc { get; set; }
        public string ImgSrc { get { return _ImgSrc; } set { _ImgSrc = value; OnPropertyChanged(); } }
        public struct StepQueueObject
        {
            public string ImgSrc;
        }

        private Queue<StepQueueObject> _StepQueues;
        public Queue<StepQueueObject> StepQueues
        {
            get { return _StepQueues; }
            set { _StepQueues = value; OnPropertyChanged(); }
        }

        public Game1ViewModel Game1Context;
        public Game2ViewModel Game2Context;
        public Game3ViewModel Game3Context;

        public GameViewModel()
        {
            PositionNumber = "1";
            GameTurn = new Game1();
            Game1Context = new Game1ViewModel();
            StepQueues = new Queue<StepQueueObject>();
            HandleButtonPress = new RelayCommand<object>((p) => { return true; }, (p) => {
                Console.WriteLine(p as string);
                if (PositionNumber == "1")
                {
                //    game1Context = new Game1ViewModel();
                //    stepQueues = new Queue<StepQueueObject>();
                if (StepQueues.Count < Game1Context.step)
                    {
                        StepQueueObject sqo = new StepQueueObject
                        {
                            ImgSrc = (string)p
                        };
                        Queue<StepQueueObject> temp = new Queue<StepQueueObject>(StepQueues);
                        temp.Enqueue(sqo);
                        StepQueues = temp;
                    }
                }

                if (PositionNumber == "2")
                {
                    GameTurn = new Game2();
                    Game2Context = new Game2ViewModel();
                    if (StepQueues.Count < Game2Context.step)
                    {
                        StepQueueObject sqo = new StepQueueObject
                        {
                            ImgSrc = (string)p
                        };
                        Queue<StepQueueObject> temp = new Queue<StepQueueObject>(StepQueues);
                        temp.Enqueue(sqo);
                        StepQueues = temp;
                    }
                    Console.WriteLine(StepQueues);
                }

                if (PositionNumber == "3")
                {
                    GameTurn = new Game3();
                    Game3Context = new Game3ViewModel();
                    if (StepQueues.Count < Game3Context.step)
                    {
                        StepQueueObject sqo = new StepQueueObject
                        {
                            ImgSrc = (string)p
                        };
                        Queue<StepQueueObject> temp = new Queue<StepQueueObject>(StepQueues);
                        temp.Enqueue(sqo);
                        StepQueues = temp;
                    }
                    Console.WriteLine(StepQueues);
                }
            });

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
                        GameTurn = new Game1();
                        StepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        StepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        StepQueues.Clear();
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
                        GameTurn = new Game1();
                        StepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        StepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        StepQueues.Clear();
                        break;
                }
            });
        }
    }
}
