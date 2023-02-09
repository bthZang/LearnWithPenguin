using LearnWithPenguin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Google.Cloud.Firestore;
using System.Windows;

namespace LearnWithPenguin.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        private BaseViewModel _displayUser;

        private string _colorInfor;
        private string _colorRanking;
        private string _colorStatistic;
        private int _heightInfor;
        private int _heightRanking;
        private int _heightStatistic;

        private BaseViewModel _popup;


        public BaseViewModel Popup
        {
            get
            {
                return _popup;
            }
            set
            {
                _popup = value;
                OnPropertyChanged();
            }
        }


        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ICommand DoneEditUserName
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, async (p) =>
                {
                    Dictionary<string, object> data = new Dictionary<string, object> {
                        {"name", UserName}
                    };
                    DocumentReference doc = Firestore.db.Collection("user").Document(UserData.email);
                    DocumentSnapshot snap = await doc.GetSnapshotAsync();
                    if (snap.Exists)
                    {
                        await doc.UpdateAsync(data);
                        UserData.name = UserName;

                        //MessageBox.Show("Cập nhật thành công");
                    }
                });
            }

            set { }
        }

        // hàm xong avatar
        public ICommand DoneAvatar
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {

                });
            }

            set { }
        }

        //hàm xong avatar
        public ICommand EditUserName
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Popup = new EditUserNameViewModel();

                });
            }

            set { }
        }

        public ICommand EditAvartar
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Popup = new AvartarViewModel();

                });
            }

            set { }
        }

        public ICommand HidePopup
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Popup = null;

                });
            }

            set { }
        }
        public int HeightInfor
        {
            get
            {
                return _heightInfor;
            }
            set
            {
                _heightInfor = value;
                OnPropertyChanged();
            }
        }

        public int HeightRanking
        {
            get
            {
                return _heightRanking;
            }
            set
            {
                _heightRanking = value;
                OnPropertyChanged();
            }
        }

        public int HeightStatistic
        {
            get
            {
                return _heightStatistic;
            }
            set
            {
                _heightStatistic = value;
                OnPropertyChanged();
            }
        }
        public string ColorInfor
        {
            get
            {
                return _colorInfor;
            }
            set
            {
                _colorInfor = value;
                OnPropertyChanged();
            }
        }

        public string ColorRanking
        {
            get
            {
                return _colorRanking;

            }
            set
            {
                _colorRanking = value;
                OnPropertyChanged();
            }
        }
        public string ColorStatistic
        {
            get
            {
                return _colorStatistic;

            }
            set
            {
                _colorStatistic = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModel DisplayUser
        {
            get
            {
                return _displayUser;
            }
            set
            {

                _displayUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowChosenInfor
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    DisplayUser = new UserInfoViewModel();
                    ColorInfor = "#073580";
                    ColorRanking = "#586A86";
                    ColorStatistic = "#586A86";
                    this.HeightInfor = 5;
                    this.HeightRanking = 0;
                    this.HeightStatistic = 0;
                });
            }

            set { }
        }

        public ICommand ShowChosenRanking
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    DisplayUser = new UserRankingViewModel();
                    ColorRanking = "#073580";
                    ColorInfor = "#586A86";
                    ColorStatistic = "#586A86";
                    this.HeightInfor = 0;
                    this.HeightRanking = 5;
                    this.HeightStatistic = 0;
                });
            }

            set { }
        }

        public ICommand ShowChosenStatistic
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    DisplayUser = new UserStatisticViewModel();
                    ColorStatistic = "#073580";
                    ColorInfor = "#586A86";
                    ColorRanking = "#586A86";
                    this.HeightInfor = 0;
                    this.HeightRanking = 0;
                    this.HeightStatistic = 5;
                });
            }

            set { }
        }

        public UserViewModel()
        {
            this.DisplayUser = new UserInfoViewModel();
            this.ColorInfor = "#073580";
            this.ColorRanking = "#586A86";
            this.ColorStatistic = "#586A86";
            this.HeightInfor = 5;
            this.HeightRanking = 0;
            this.HeightStatistic = 0;
            _popup = null;



        }

        




    }
}
