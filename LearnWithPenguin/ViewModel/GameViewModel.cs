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
        public ICommand handleButtonPress { get; set; }

        public struct StepQueueObject
        {
            public string Image;
        }
        private Queue<StepQueueObject> _stepQueues;
        public Queue<StepQueueObject> stepQueues
        {
            get { return _stepQueues; }
            set { _stepQueues = value; OnPropertyChanged(); }
        }

        public Game1ViewModel game1Context;
        public Game2ViewModel game2Context;
        public Game3ViewModel game3Context;

        public GameViewModel()
        {
            PositionNumber = "1";
            GameTurn = new Game1();
            game1Context = new Game1ViewModel();
            stepQueues = new Queue<StepQueueObject>();

            handleButtonPress = new RelayCommand<object>((p) => { return true; }, (p) => {
                Console.WriteLine(p as string);
                //if (PositionNumber == "1")
                //{
                //    game1Context = new Game1ViewModel();
                //    stepQueues = new Queue<StepQueueObject>();
                    if (stepQueues.Count < game1Context.step)
                    {
                        StepQueueObject sqo = new StepQueueObject();
                        sqo.Image = (string)p;
                        Queue<StepQueueObject> temp = new Queue<StepQueueObject>(stepQueues);
                        temp.Enqueue(sqo);
                        stepQueues = temp;
                    }           
                //}

                //if (PositionNumber == "2")
                //{
                //    game2Context = new Game2ViewModel();
                //    stepQueues = new Queue<StepQueueObject>();
                //    GameTurn = new Game2();
                //    if (stepQueues.Count < game2Context.step)
                //    {
                //        StepQueueObject sqo = new StepQueueObject();
                //        sqo.Image = p as string;
                //        Queue<StepQueueObject> temp = new Queue<StepQueueObject>(stepQueues);
                //        temp.Enqueue(sqo);
                //        stepQueues = temp;
                //    }
                //    Console.WriteLine(stepQueues);
                //}

                //if (PositionNumber == "3")
                //{
                //    game3Context = new Game3ViewModel();
                //    stepQueues = new Queue<StepQueueObject>();
                //    GameTurn = new Game3();
                //    if (stepQueues.Count < game3Context.step)
                //    {
                //        StepQueueObject sqo = new StepQueueObject();
                //        sqo.Image = p as string;
                //        Queue<StepQueueObject> temp = new Queue<StepQueueObject>(stepQueues);
                //        temp.Enqueue(sqo);
                //        stepQueues = temp;
                //    }
                //    Console.WriteLine(stepQueues);
                //}
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
                        stepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        stepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        stepQueues.Clear();
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
                        stepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        stepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        stepQueues.Clear();
                        break;
                }
            });
        }
    }
}
