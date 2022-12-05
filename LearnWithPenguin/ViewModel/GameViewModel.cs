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
        public ICommand RunGameCommand { get; set; }
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

        private Queue<string> _StepQueues;
        public Queue<string> StepQueues
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
            StepQueues = new Queue<string>();
            HandleButtonPress = new RelayCommand<object>((p) => { return true; }, (p) => {
                Console.WriteLine(p as string);
                switch(PositionNumber)
                {
                    case "1":
                        {
                            if (StepQueues.Count < Game1Context.step)
                            {   
                                Queue<string> temp = new Queue<string>(StepQueues);
                                temp.Enqueue((string) p);
                                StepQueues = temp;
                            }
                        }
                        break;
                    case "2":
                        {
                            GameTurn = new Game2();
                            Game2Context = new Game2ViewModel();
                            if (StepQueues.Count < Game2Context.step)
                            {
                                Queue<string> temp = new Queue<string>(StepQueues);
                                temp.Enqueue((string)p);
                                StepQueues = temp;
                            }
                        }
                        break;
                    case "3":
                        {
                            GameTurn = new Game3();
                            Game3Context = new Game3ViewModel();
                            if (StepQueues.Count < Game3Context.step)
                            {
                                Queue<string> temp = new Queue<string>(StepQueues);
                                temp.Enqueue((string)p);
                                StepQueues = temp;
                            }
                        }
                        break;
                }
            });

            RunGameCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                switch(PositionNumber)
                {
                    case "1":
                        {
                            string[] temp = new string[Game1Context.step];
                            StepQueues.CopyTo(temp, StepQueues.Count - Game1Context.step);
                            if (temp[0] == "/images/right@3x.png" && temp[1] == "/images/right@3x.png" && temp[2] == "/images/right@3x.png" && temp[3] == "/images/right@3x.png")
                            {
                                Console.WriteLine("Dung roi pan oi");
                            }
                            else
                            {
                                Console.WriteLine("Ngu");
                            }  
                        }
                        break;
                    //case "2":
                    //    {
                    //        string[] temp = new string[Game2Context.step];
                    //        StepQueues.CopyTo(temp, StepQueues.Count - Game2Context.step);
                    //        foreach (string sqo in temp) { Console.WriteLine(sqo); }
                    //    }
                    //    break;
                    //case "3":
                    //    {
                    //        string[] temp = new string[Game3Context.step];
                    //        StepQueues.CopyTo(temp, StepQueues.Count - Game3Context.step);
                    //        foreach (string sqo in temp) { Console.WriteLine(sqo); }
                    //    }
                    //    break;
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
