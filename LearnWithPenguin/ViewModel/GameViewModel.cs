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
        static class Direction
        {
            public static string Left = "\\images\\left@3x.png";
            public static string Right = "\\images\\right@3x.png";
            public static string TurnUp = "\\images\\turnUp@3x.png";
            public static string TurnDown = "\\images\\turnDown@3x.png";
            public static string TurnUR = "\\images\\turnUR@3x.png";
            public static string TurnDR = "\\images\\turnDR@3x.png";
        }

        private System.Windows.Controls.UserControl _GameTurn;
        public System.Windows.Controls.UserControl GameTurn { get { return _GameTurn; } set { _GameTurn = value; OnPropertyChanged(); } }

        private System.Windows.Controls.UserControl _GameWarn;
        public System.Windows.Controls.UserControl GameWarn { get { return _GameWarn; } set { _GameWarn = value; OnPropertyChanged(); } }
        private string _ViString;
        public string ViString { get { return _ViString; } set { _ViString = value; OnPropertyChanged(); } }

        public ICommand ForwardCommand { get; set; }
        public ICommand RunGameCommand { get; set; }
        public ICommand BackwardCommand { get; set; }

        private string _PositionNumber;
        public string PositionNumber { get { return _PositionNumber; } set { _PositionNumber = value; OnPropertyChanged(); } }
        public ICommand HandleButtonPress { get; set; }

        private Queue<string> _StepQueues;
        public Queue<string> StepQueues
        {
            get { return _StepQueues; }
            set { _StepQueues = value; OnPropertyChanged(); }
        }

        public Game1ViewModel Game1Context;
        public Game2ViewModel Game2Context;
        public Game3ViewModel Game3Context;

        public ICommand Reload { get; set; }
        public GameViewModel()
        {
            PositionNumber = "1";
            GameTurn = new Game1();

            ViString = "Hidden";

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
                try
                {
                    switch (PositionNumber)
                    {
                        case "1":
                            {
                                string[] temp = new string[Game1Context.step];
                                StepQueues.CopyTo(temp, StepQueues.Count - Game1Context.step);
                                if (temp[0] == Direction.Right &&
                                    temp[1] == Direction.Right &&
                                    temp[2] == Direction.Right &&
                                    temp[3] == Direction.Right)
                                {
                                    Console.WriteLine("Dung roi pan oi");
                                }
                                else
                                {
                                    Console.WriteLine("Ngu");
                                }
                            }
                            break;
                        case "2":
                            {
                                string[] temp = new string[Game2Context.step];
                                StepQueues.CopyTo(temp, StepQueues.Count - Game2Context.step);
                                if (temp[0] == Direction.Right &&
                                    temp[1] == Direction.TurnDown &&
                                    temp[2] == Direction.TurnDR &&
                                    temp[3] == Direction.Right &&
                                    temp[4] == Direction.TurnUp &&
                                    temp[5] == Direction.TurnUR)
                                {
                                    Console.WriteLine("Dung roi pan oi");
                                }
                                else
                                {
                                    Console.WriteLine("Ngu");
                                }
                            }
                            break;
                        case "3":
                            {
                                string[] temp = new string[Game3Context.step];
                                StepQueues.CopyTo(temp, StepQueues.Count - Game3Context.step);
                                if (temp[0] == Direction.TurnDR &&
                                    temp[1] == Direction.Right &&
                                    temp[2] == Direction.TurnUp &&
                                    temp[3] == Direction.TurnUR &&
                                    temp[4] == Direction.Right &&
                                    temp[5] == Direction.TurnDown &&
                                    temp[6] == Direction.TurnDR)
                                {
                                    Console.WriteLine("Dung roi pan oi");
                                }
                                else
                                {
                                    Console.WriteLine("Ngu");
                                }
                            }
                            break;
                    }
                }
                catch
                {
                    ViString = "Visible";
                }
            });

            Reload = new RelayCommand<object>((p) => { return true; }, (p) => {
                StepQueues.Clear();

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
