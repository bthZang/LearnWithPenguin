using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Forms;
using LearnWithPenguin.Utils;
using Google.Cloud.Firestore;

namespace LearnWithPenguin.ViewModel
{
    public class WriteViewModel : BaseViewModel
    {
        protected string _isDisplayVideo;
        protected int _number;
        protected string _nextLevel;
        protected string _backLevel;
        protected bool _submit = false;


        protected BaseViewModel _navigatetoResult = null;


        public string IsDisplayVideo
        {
            get
            {
                return _isDisplayVideo;
            }
            set
            {
                _isDisplayVideo = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReplayVideo
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    IsDisplayVideo = "Visible";
                });
            }

            set { }
        }

        public WriteViewModel()
        {
            this.IsDisplayVideo = "Hidden";
            this.Number = 1;
            this._star1 = "yellow";
            this._star2 = "white";
            this._star3 = "white";
            this._star4 = "white";
            this._star5 = "white";
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                ConcatTitle = "";
                ConcatVideo = "";
                SouceDash = "";
                SouceSolid = "";

                OnPropertyChanged();
            }
        }

        public string ConcatTitle
        {
            get
            {
                return "Bài " + _number;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string ConcatVideo
        {
            get
            {
                return "./TapViet/ChuThuong/" + _number + ".mp4";
                //return "/TapViet/ChuThuong/" + _number + ".mp4";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string SouceDash
        {
            get
            {
                return "/TapViet/ChuDut/" + _number + ".png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string SouceSolid
        {
            get
            {
                return "/TapViet/ChuLien/" + _number + ".png";
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string NextLevel
        {
            get
            {
                return _nextLevel;
            }
            set
            {
                _nextLevel = value;
                OnPropertyChanged();
            }
        }

        public string BackLevel
        {
            get
            {
                return _backLevel;
            }
            set
            {
                _backLevel = value;
                OnPropertyChanged();
            }
        }

        public ICommand _onclickHandleNextLevel;
        public ICommand OnclickHandleNextLevel
        {
            get
            {
                return _onclickHandleNextLevel;
            }

            set { _onclickHandleNextLevel = value; OnPropertyChanged(); }
        }

        public ICommand _onclickHandlePreviousLevel;
        public ICommand OnclickHandlePreviousLevel
        {
            get
            {
                return _onclickHandlePreviousLevel;
            }

            set { _onclickHandlePreviousLevel = value; OnPropertyChanged(); }
        }

        public bool IsMouseDown
        {
            get
            {
                //System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed
                if ((System.Windows.Forms.Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
                    return true;
                return false;
            }
            set { }
        }

        public List<Point> mousePositions = new List<Point>();

        public void AddPosition(Point point)
        {
            mousePositions.Add(point);
        }

        public string _point;

        public string Point
        {
            get
            {
                return _point;
            }
            set
            {
                _point = value;
                OnPropertyChanged();
            }
        }

        async void updatePoint()
        {
            Dictionary<string, object> data = new Dictionary<string, object> {
                {"score_1", UserData.score_1 }
            };
            DocumentReference doc = Firestore.db.Collection("user").Document(UserData.email);
            DocumentSnapshot snap = await doc.GetSnapshotAsync();
            if (snap.Exists)
            {
                await doc.UpdateAsync(data);
                //MessageBox.Show("Cập nhật thành công");
            }
        }

        public bool Submit()
        {
            float[] _positionX;
            float[] _positionY;

            switch (_number)
            {
                case 1:
                    _positionX = new float[6] { 556, 503, 558, 601, 622, 663 };
                    _positionY = new float[6] { 399, 464, 528, 465, 524, 463 };
                    break;
                case 2:
                    _positionX = new float[6] { 772, 768, 880, 768, 814, 714 };
                    _positionY = new float[6] { 399, 376, 528, 468, 524, 462 };
                    break;
                case 3:
                    _positionX = new float[6] { 772, 715, 768, 815, 777, 863 };
                    _positionY = new float[6] { 400, 464, 528, 465, 364, 496 };
                    break;
                case 4:
                    _positionX = new float[6] { 747, 817, 801, 808, 752, 863 };
                    _positionY = new float[6] { 409, 419, 520, 294, 284, 426 };
                    break;
                case 5:
                    _positionX = new float[6] { 829, 761, 754, 762, 810, 850 };
                    _positionY = new float[6] { 511, 419, 520, 464, 421, 499 };
                    break;
                case 6:
                    _positionX = new float[6] { 772, 711, 768, 857, 810, 813 };
                    _positionY = new float[6] { 399, 464, 520, 277, 396, 515 };
                    break;
                case 7:
                    _positionX = new float[6] { 772, 862, 768, 816, 815, 813 };
                    _positionY = new float[6] { 399, 511, 520, 462, 275, 333 };
                    break;
                case 8:
                    _positionX = new float[6] { 742, 849, 820, 770, 804, 828 };
                    _positionY = new float[6] { 504, 500, 418, 465, 524, 408 };
                    break;
                case 9:
                    _positionX = new float[6] { 742, 849, 820, 770, 804, 828 };
                    _positionY = new float[6] { 504, 500, 418, 465, 364, 408 };
                    break;
                case 10:
                    _positionX = new float[6] { 780, 696, 843, 777, 788, 880 };
                    _positionY = new float[6] { 715, 496, 464, 404, 590, 487 };
                    break;
                case 11:
                    _positionX = new float[6] { 712, 741, 733, 777, 800, 855 };
                    _positionY = new float[6] { 442, 260, 366, 330, 404, 516 };
                    break;
                case 12:
                    _positionX = new float[6] { 763, 780, 778, 778, 800, 838 };
                    _positionY = new float[6] { 448, 400, 368, 471, 523, 476 };
                    break;
                case 13:
                    _positionX = new float[6] { 714, 790, 732, 834, 781, 781 };
                    _positionY = new float[6] { 428, 288, 488, 424, 465, 464 };
                    break;
                case 14:
                    _positionX = new float[6] { 739, 817, 755, 756, 800, 866 };
                    _positionY = new float[6] { 433, 274, 322, 456, 521, 479 };
                    break;
                case 15:
                    _positionX = new float[6] { 688, 716, 764, 791, 845, 908 };
                    _positionY = new float[6] { 399, 478, 399, 489, 403, 502 };
                    break;
                case 16:
                    _positionX = new float[6] { 727, 752, 782, 834, 831, 872 };
                    _positionY = new float[6] { 402, 503, 412, 435, 502, 498 };
                    break;
                case 17:
                    _positionX = new float[6] { 790, 752, 760, 818, 844, 828 };
                    _positionY = new float[6] { 399, 444, 502, 516, 463, 418 };
                    break;
                case 18:
                    _positionX = new float[6] { 795, 794, 756, 754, 820, 840 };
                    _positionY = new float[6] { 379, 410, 435, 492, 516, 460 };
                    break;
                case 19:
                    _positionX = new float[6] { 840, 794, 750, 766, 829, 840 };
                    _positionY = new float[6] { 400, 404, 447, 510, 506, 451 };
                    break;
                case 20:
                    _positionX = new float[6] { 703, 724, 779, 832, 881, 882 };
                    _positionY = new float[6] { 318, 348, 282, 325, 377, 378 };
                    break;
                case 21:
                    _positionX = new float[6] { 797, 744, 796, 847, 850, 846 };
                    _positionY = new float[6] { 277, 338, 393, 324, 427, 510 };
                    break;
                case 22:
                    _positionX = new float[6] { 721, 718, 772, 812, 837, 884 };
                    _positionY = new float[6] { 494, 365, 392, 433, 528, 479 };
                    break;
                case 23:
                    _positionX = new float[6] { 744, 780, 785, 855, 832, 786 };
                    _positionY = new float[6] { 505, 452, 388, 448, 517, 515 };
                    break;
                case 24:
                    _positionX = new float[6] { 751, 779, 783, 778, 816, 849 };
                    _positionY = new float[6] { 437, 348, 397, 480, 523, 484 };
                    break;
                case 25:
                    _positionX = new float[6] { 718, 739, 740, 787, 823, 853 };
                    _positionY = new float[6] { 446, 402, 493, 519, 433, 521 };
                    break;
                case 26:
                    _positionX = new float[6] { 725, 744, 804, 845, 822, 873 };
                    _positionY = new float[6] { 446, 492, 500, 403, 467, 508 };
                    break;
                case 27:
                    _positionX = new float[6] { 718, 766, 770, 834, 834, 872 };
                    _positionY = new float[6] { 418, 413, 486, 516, 402, 426 };
                    break;
                case 28:
                    _positionX = new float[6] { 742, 793, 714, 766, 840, 840 };
                    _positionY = new float[6] { 399, 462, 508, 516, 397, 527 };
                    break;
                case 29:
                    _positionX = new float[6] { 728, 778, 856, 847, 792, 896 };
                    _positionY = new float[6] { 400, 520, 421, 668, 594, 476 };
                    break;

                default:
                    _positionX = new float[6] { 617, 536, 425, 537, 664, 734 };
                    _positionY = new float[6] { 509, 381, 511, 634, 632, 534 };
                    break;
            }

            int point = 1;

            for (int i = 0; i < 6; i++)
            {
                bool isCorrect = false;

                foreach (Point mousePoint in mousePositions)
                {
                    double distance = Math.Sqrt(Math.Pow(mousePoint.X - _positionX[i], 2) + Math.Pow(mousePoint.Y - _positionY[i], 2));
                    if (distance < 20)
                        isCorrect = true;
                }

                if (isCorrect)
                    point += 1;
                //Point = Convert.ToString(UserData.score_1 += point);

            }

            UserData.score_1[_number-1] = point;
            updatePoint();

            if (point >= 3)
            {
                _submit = true;

                switch (point)
                {
                    case 3:
                    case 4:
                        Star4 = Star5 = "white";
                        break;
                    case 5:
                        Star4 = "yellow";
                        Star5 = "white";
                        break;
                    case 6:
                        Star4 = Star5 = "yellow";
                        break;
                    default:
                        Star4 = Star5 = "yellow";
                        break;
                }
            }
            else
            {
                _submit = false;

                switch (point)
                {
                    case 1:
                        Star1 = "yellow";
                        Star2 = "white";
                        break;
                    case 2:
                        Star1 = Star2 = "yellow";
                        break;
                    default:
                        Star1 = "yellow";
                        Star2 = "white";
                        break;
                }
            }

            return _submit;
        }
        public BaseViewModel NavigatetoResult
        {
            get
            {
                return _navigatetoResult;
            }
            set
            {
                _navigatetoResult = value;
                OnPropertyChanged();
            }
        }


        //star

        public string _star1;
        public string _star2;
        public string _star3;
        public string _star4;
        public string _star5;

        public string Star1
        {
            get
            {
                return _star1;
            }
            set
            {
                _star1 = value;
                ChangeColor1 = "";
                OnPropertyChanged();
            }
        }

       

        public string ChangeColor1
        {
            get
            {
                return "/UserControls/" + Star1 + "Star.png";
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
                return _star2;
            }
            set
            {
                _star2= value;
                ChangeColor2 = "";
                OnPropertyChanged();
            }
        }


        public string ChangeColor2
        {
            get
            {
                return "/UserControls/" + _star2 + "Star.png";
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
                return _star3;
            }
            set
            {
                _star3= value;
                ChangeColor3 = "";
                OnPropertyChanged();
            }
        }


        public string ChangeColor3
        {
            get
            {
                return "/UserControls/" + _star3 + "Star.png";
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
                return _star4;
            }
            set
            {
                _star4= value;
                ChangeColor4 = "";
                OnPropertyChanged();
            }
        }


        public string ChangeColor4
        {
            get
            {
                return "/UserControls/" + _star4 + "Star.png";
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
                return _star5;
            }
            set
            {
                _star5 = value;
                ChangeColor5 = "5";
                OnPropertyChanged();
            }
        }


        public string ChangeColor5
        {
            get
            {
                return "/UserControls/" + _star5 + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }


        //endstar'

        
        public ICommand ShowResult
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Submit();

                    if (_submit == true)
                        NavigatetoResult = new GoodResultViewModel();
                    else
                        NavigatetoResult = new BadResultViewModel();
                    //ChangeMedalWrite();
                    //UserViewModel.ChangeMedalWrite();
                });
            }

            set { }
        }

        public bool _isReplay = false;

        public bool IsReplay
        {
            get
            {
                return _isReplay;
            }
            set
            {
                _isReplay = value;
            }
        }

        private ICommand _replay;
        public ICommand Replay
        {
            get
            {
                return _replay;
            }

            set { _replay = value; }
        }
    }

}




