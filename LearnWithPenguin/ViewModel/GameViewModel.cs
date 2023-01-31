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
using System.Windows.Threading;

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

        public CodingViewModel CodingContext;
        public Game1ViewModel Game1Context;
        public Game2ViewModel Game2Context;
        public Game3ViewModel Game3Context;
        public ICommand Reload { get; set; }
        private string _ColumnNum;
        public string ColumnNum { get { return _ColumnNum; } set { _ColumnNum = value; OnPropertyChanged(); } }
        private string _RowNum;
        public string RowNum { get { return _RowNum; } set { _RowNum = value; OnPropertyChanged(); } }

        //private string _ViNo;
        //public string ViNo { get { return _ViNo; } set { _ViNo = value; OnPropertyChanged(); } }
        //private string _ViYes;
        //public string ViYes { get { return _ViYes; } set { _ViYes = value; OnPropertyChanged(); } }

        protected BaseViewModel _NavigatetoResult = null;
        public BaseViewModel NavigatetoResult { get { return _NavigatetoResult; } set { _NavigatetoResult = value; OnPropertyChanged(); } }

        public string _Star1;
        public string _Star2;
        public string _Star3;
        public string _Star4;
        public string _Star5;

        public ICommand _NextGame;
        public ICommand NextGame { get { return _NextGame; } set { _NextGame = value; } }
        public ICommand _ReplayGame;
        public ICommand ReplayGame { get { return _ReplayGame; } set { _ReplayGame = value; } }

        private int _Point;
        public int Point { get { return _Point; } set { _Point = value; OnPropertyChanged(); } }


        public string Star1
        {
            get
            {
                return _Star1;
            }
            set
            {
                _Star1 = value;
                ChangeColor1 = "";
                OnPropertyChanged();
            }
        }

        public string ChangeColor1
        {
            get
            {
                return "/UserControls/" + _Star1 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }
        public string Star2
        {
            get
            {
                return _Star2;
            }
            set
            {
                _Star2 = value;
                ChangeColor2 = "";
                OnPropertyChanged();
            }
        }


        public string ChangeColor2
        {
            get
            {
                return "/UserControls/" + _Star2 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string Star3
        {
            get
            {
                return _Star3;
            }
            set
            {
                _Star3 = value;
                ChangeColor3 = "";
                OnPropertyChanged();
            }
        }

        public string ChangeColor3
        {
            get
            {
                return "/UserControls/" + _Star3 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }
        public string Star4
        {
            get
            {
                return _Star4;
            }
            set
            {
                _Star4 = value;
                ChangeColor4 = "";
                OnPropertyChanged();
            }
        }

        public string ChangeColor4
        {
            get
            {
                return "/UserControls/" + _Star4 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string Star5
        {
            get
            {
                return _Star5;
            }
            set
            {
                _Star5 = value;
                ChangeColor5 = "";
                OnPropertyChanged();
            }
        }

        public string ChangeColor5
        {
            get
            {
                return "/UserControls/" + _Star5 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public GameViewModel()

        {
            CodingContext = new CodingViewModel();
            PositionNumber = CodingContext.PositionNumber;
             
            switch(PositionNumber)
            {
                case "1":
                    GameTurn = new Game1();
                    Game1Context = new Game1ViewModel();
                    break;

                case "2":
                    GameTurn = new Game2();
                    Game2Context = new Game2ViewModel();
                    break;

                case "3":
                    GameTurn = new Game3();
                    Game3Context = new Game3ViewModel();
                    break;
            }

            ViString = "Hidden";

            StepQueues = new Queue<string>();
            ColumnNum = "0";

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

            RunGameCommand = new RelayCommand<object>((p) => { return true; }, async (p) => 
            {
                try
                {
                    switch (PositionNumber)
                    {
                        case "1":
                            { 
                                string[] temp = new string[Game1Context.step];
                                StepQueues.CopyTo(temp, StepQueues.Count - Game1Context.step);

                                bool result;
                                int getNum = Convert.ToInt32(ColumnNum);
                                ColumnNum = Convert.ToString(getNum);
                                await Task.Delay(500);
                                Star1 = "white";
                                Star2 = "white";
                                Point = 0;

                                if (temp[0] == Direction.Right)
                                {
                                    getNum = Convert.ToInt32(ColumnNum);
                                    getNum++;
                                    ColumnNum = Convert.ToString(getNum);
                                    await Task.Delay(500);
                                    Star1 = "yellow";
                                    Star2 = "white";
                                    Point = 1;

                                    if (temp[1] == Direction.Right)
                                    {
                                        getNum = Convert.ToInt32(ColumnNum);
                                        getNum++;
                                        ColumnNum = Convert.ToString(getNum);
                                        await Task.Delay(500);
                                        Star1 = "yellow";
                                        Star2 = "yellow";
                                        Point = 2;

                                        if (temp[2] == Direction.Right)
                                        {
                                            getNum = Convert.ToInt32(ColumnNum);
                                            getNum++;
                                            ColumnNum = Convert.ToString(getNum);
                                            await Task.Delay(500);
                                            Star4 = "yellow";
                                            Star5 = "white";
                                            Point = 4;

                                            if (temp[3] == Direction.Right)
                                            {
                                                getNum = Convert.ToInt32(ColumnNum);
                                                getNum++;
                                                ColumnNum = Convert.ToString(getNum);
                                                await Task.Delay(500);

                                                getNum = Convert.ToInt32(ColumnNum);
                                                getNum++;
                                                ColumnNum = Convert.ToString(getNum);
                                                await Task.Delay(500);

                                                Star4 = "yellow";
                                                Star5 = "yellow";
                                                Point = 5;

                                                result = true;
                                            }
                                            else
                                                result = true;
                                        }
                                        else
                                            result = false;
                                    }
                                    else
                                        result = false;
                                }
                                else 
                                    result = false;

                                if (result)
                                    NavigatetoResult = new GRforGameViewModel();
                                else
                                    NavigatetoResult= new BRforGameViewModel();
                            }

                            break;
                        case "2":
                            {
                                string[] temp = new string[Game2Context.step];
                                StepQueues.CopyTo(temp, StepQueues.Count - Game2Context.step);

                                bool result;
                                int getCNum = Convert.ToInt32(ColumnNum);
                                int getRNum = Convert.ToInt32(RowNum);
                                getCNum = 0;
                                getRNum = 0;
                                ColumnNum = Convert.ToString(getCNum);
                                RowNum = Convert.ToString(getRNum);
                                await Task.Delay(500);
                                Star1 = "white";
                                Star2 = "white";
                                Point = 0;

                                if (temp[0] == Direction.Right)
                                {
                                    getCNum = Convert.ToInt32(ColumnNum);
                                    getRNum = Convert.ToInt32(RowNum);
                                    getCNum = 1;
                                    getRNum = 0;
                                    ColumnNum = Convert.ToString(getCNum);
                                    RowNum = Convert.ToString(getRNum);
                                    await Task.Delay(500);
                                    Star1 = "yellow";
                                    Star2 = "white";
                                    Point = 1;

                                    if (temp[1] == Direction.TurnDown)
                                    {
                                        getCNum = Convert.ToInt32(ColumnNum);
                                        getCNum = Convert.ToInt32(RowNum);
                                        getCNum = 2;
                                        getRNum = 0;
                                        ColumnNum = Convert.ToString(getCNum);
                                        RowNum = Convert.ToString(getRNum);
                                        await Task.Delay(500);
                                        Star1 = "yellow";
                                        Star2 = "yellow";
                                        Point = 2;

                                        if (temp[2] == Direction.TurnDR)
                                        {
                                            getCNum = Convert.ToInt32(ColumnNum);
                                            getCNum = Convert.ToInt32(RowNum);
                                            getCNum = 2;
                                            getRNum = 1;
                                            ColumnNum = Convert.ToString(getCNum);
                                            RowNum = Convert.ToString(getRNum);
                                            await Task.Delay(500);
                                            Star1 = "yellow";
                                            Star2 = "yellow";
                                            Point = 2;

                                            if (temp[3] == Direction.Right)
                                            {
                                                getCNum = Convert.ToInt32(ColumnNum);
                                                getCNum = Convert.ToInt32(RowNum);
                                                getCNum = 3;
                                                getRNum = 1;
                                                ColumnNum = Convert.ToString(getCNum);
                                                RowNum = Convert.ToString(getRNum);
                                                await Task.Delay(500);
                                                Star4 = "white";
                                                Star5 = "white";
                                                Point = 3;

                                                if (temp[4] == Direction.TurnUp)
                                                {
                                                    getCNum = Convert.ToInt32(ColumnNum);
                                                    getRNum = Convert.ToInt32(RowNum);
                                                    getCNum = 4;
                                                    getRNum = 1;
                                                    ColumnNum = Convert.ToString(getCNum);
                                                    RowNum = Convert.ToString(getRNum);
                                                    await Task.Delay(500);
                                                    Star4 = "yellow";
                                                    Star5 = "white";
                                                    Point = 4;

                                                    if (temp[5] == Direction.TurnUR)
                                                    {
                                                        getCNum = Convert.ToInt32(ColumnNum);
                                                        getCNum = Convert.ToInt32(RowNum);
                                                        getCNum = 4;
                                                        getRNum = 0;
                                                        ColumnNum = Convert.ToString(getCNum);
                                                        RowNum = Convert.ToString(getRNum);
                                                        await Task.Delay(500);

                                                        getCNum = Convert.ToInt32(ColumnNum);
                                                        getCNum = Convert.ToInt32(RowNum);
                                                        getCNum = 5;
                                                        getRNum = 0;
                                                        ColumnNum = Convert.ToString(getCNum);
                                                        RowNum = Convert.ToString(getRNum);
                                                        await Task.Delay(500);

                                                        Star4 = "yellow";
                                                        Star5 = "yellow";
                                                        Point = 5;
                                                        result = true;
                                                    }
                                                    else
                                                        result = true;
                                                }
                                                else
                                                    result = true;
                                            }
                                            else
                                                result = false;
                                        }
                                        else
                                            result = false;
                                    }
                                    else
                                        result = false;
                                }
                                else 
                                    result = false;
              
                                if (result)
                                    NavigatetoResult = new GRforGameViewModel();
                                else
                                    NavigatetoResult = new BRforGameViewModel();
                            }
                            break;
                        case "3":
                            {
                                string[] temp = new string[Game3Context.step];
                                StepQueues.CopyTo(temp, StepQueues.Count - Game3Context.step);

                                bool result;
                                int getCNum = Convert.ToInt32(ColumnNum);
                                int getRNum = Convert.ToInt32(RowNum);
                                getCNum = 0;
                                getRNum = 0;
                                ColumnNum = Convert.ToString(getCNum);
                                RowNum = Convert.ToString(getRNum);
                                await Task.Delay(500);
                                Star1 = "white";
                                Star2 = "white";
                                Point = 0;

                                if (temp[0] == Direction.TurnDR)
                                {
                                    getCNum = Convert.ToInt32(ColumnNum);
                                    getRNum = Convert.ToInt32(RowNum);
                                    getCNum = 0;
                                    getRNum = 1;
                                    ColumnNum = Convert.ToString(getCNum);
                                    RowNum = Convert.ToString(getRNum);
                                    await Task.Delay(500);
                                    Star1 = "yellow";
                                    Star2 = "white";
                                    Point = 1;

                                    if (temp[1] == Direction.Right)
                                    {
                                        getCNum = Convert.ToInt32(ColumnNum);
                                        getCNum = Convert.ToInt32(RowNum);
                                        getCNum = 1;
                                        getRNum = 1;
                                        ColumnNum = Convert.ToString(getCNum);
                                        RowNum = Convert.ToString(getRNum);
                                        await Task.Delay(500);
                                        Star1 = "yellow";
                                        Star2 = "yellow";
                                        Point = 2;

                                        if (temp[2] == Direction.TurnUp)
                                        {
                                            getCNum = Convert.ToInt32(ColumnNum);
                                            getCNum = Convert.ToInt32(RowNum);
                                            getCNum = 2;
                                            getRNum = 1;
                                            ColumnNum = Convert.ToString(getCNum);
                                            RowNum = Convert.ToString(getRNum);
                                            await Task.Delay(500);
                                            Star1 = "yellow";
                                            Star2 = "yellow";
                                            Point = 2;

                                            if (temp[3] == Direction.TurnUR)
                                            {
                                                getCNum = Convert.ToInt32(ColumnNum);
                                                getCNum = Convert.ToInt32(RowNum);
                                                getCNum = 2;
                                                getRNum = 0;
                                                ColumnNum = Convert.ToString(getCNum);
                                                RowNum = Convert.ToString(getRNum);
                                                await Task.Delay(500);
                                                Star4 = "white";
                                                Star5 = "white";
                                                Point = 3;

                                                if (temp[4] == Direction.Right)
                                                {
                                                    getCNum = Convert.ToInt32(ColumnNum);
                                                    getRNum = Convert.ToInt32(RowNum);
                                                    getCNum = 3;
                                                    getRNum = 0;
                                                    ColumnNum = Convert.ToString(getCNum);
                                                    RowNum = Convert.ToString(getRNum);
                                                    await Task.Delay(500);
                                                    Star4 = "white";
                                                    Star5 = "white";
                                                    Point = 3;

                                                    if (temp[5] == Direction.TurnDown)
                                                    {
                                                        getCNum = Convert.ToInt32(ColumnNum);
                                                        getRNum = Convert.ToInt32(RowNum);
                                                        getCNum = 4;
                                                        getRNum = 0;
                                                        ColumnNum = Convert.ToString(getCNum);
                                                        RowNum = Convert.ToString(getRNum);
                                                        await Task.Delay(500);
                                                        Star4 = "yellow";
                                                        Star5 = "white";
                                                        Point = 4;

                                                        if (temp[6] == Direction.TurnDR)
                                                        {
                                                            getCNum = Convert.ToInt32(ColumnNum);
                                                            getCNum = Convert.ToInt32(RowNum);
                                                            getCNum = 4;
                                                            getRNum = 1;
                                                            ColumnNum = Convert.ToString(getCNum);
                                                            RowNum = Convert.ToString(getRNum);
                                                            await Task.Delay(500);

                                                            getCNum = Convert.ToInt32(ColumnNum);
                                                            getCNum = Convert.ToInt32(RowNum);
                                                            getCNum = 5;
                                                            getRNum = 1;
                                                            ColumnNum = Convert.ToString(getCNum);
                                                            RowNum = Convert.ToString(getRNum);
                                                            await Task.Delay(500);

                                                            Star4 = "yellow";
                                                            Star5 = "yellow";
                                                            Point = 5;
                                                            result = true;
                                                        }
                                                        else
                                                            result = true;
                                                    }
                                                    else
                                                        result = true;
                                                }
                                                else
                                                    result = true;
                                            }
                                            else
                                                result = false;
                                        }
                                        else
                                            result = false;
                                    }
                                    else
                                        result = false;
                                }
                                else 
                                    result = false;

                                if (result)
                                    NavigatetoResult = new GRforGameViewModel();
                                else
                                    NavigatetoResult = new BRforGameViewModel();
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
                StepQueues = null;
                StepQueues = new Queue<string>();
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
                        ColumnNum = "0";
                        StepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        ColumnNum = "0";
                        RowNum = "0";
                        StepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        ColumnNum = "0";
                        RowNum = "0";
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
                        ColumnNum = "0";
                        StepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        ColumnNum = "0";
                        RowNum = "0";
                        StepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        ColumnNum = "0";
                        RowNum = "0";
                        StepQueues.Clear();
                        break;
                }
            });

            NextGame = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int getNum = Convert.ToInt32(PositionNumber);
                if (getNum == 3)
                    goto stopNum;
                getNum++;
            stopNum:
                PositionNumber = Convert.ToString(getNum);
                NavigatetoResult = null;
                switch (getNum)
                {
                    case 1:
                        GameTurn = new Game1();
                        ColumnNum = "0";
                        StepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        ColumnNum = "0";
                        RowNum = "0";
                        StepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        ColumnNum = "0";
                        RowNum = "0";
                        StepQueues.Clear();
                        break;
                }
            });

            ReplayGame = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int getNum = Convert.ToInt32(PositionNumber);
                PositionNumber = Convert.ToString(getNum);
                NavigatetoResult = null;
                switch (getNum)
                {
                    case 1:
                        GameTurn = new Game1();
                        ColumnNum = "0";
                        StepQueues.Clear();
                        break;
                    case 2:
                        GameTurn = new Game2();
                        ColumnNum = "0";
                        RowNum = "0";
                        StepQueues.Clear();
                        break;
                    case 3:
                        GameTurn = new Game3();
                        ColumnNum = "0";
                        RowNum = "0";
                        StepQueues.Clear();
                        break;
                }
            });
        }
    }
}
