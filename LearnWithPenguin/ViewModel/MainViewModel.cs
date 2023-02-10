using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LearnWithPenguin.UserControl;
using LearnWithPenguin.UserControls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using LearnWithPenguin.Stores;
using Firebase.Auth;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Google.Cloud.Firestore;
using LearnWithPenguin.Utils;
using DocumentReference = Google.Cloud.Firestore.DocumentReference;
using UserInfo = LearnWithPenguin.Utils.UserInfo;
using LearnWithPenguin.View;
using Google.Cloud.Firestore;
using LearnWithPenguin.Utils;
using System.Xml.Linq;

namespace LearnWithPenguin.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        protected BaseViewModel _navigatetoHome;

        public bool isClosing = false;
        public bool isSound = true;

        public static string userEmail;

        public MainViewModel()
        {
            this.NavigatetoHome = new OnBoardingViewModel();
            ImageVolume = "/UserControls/Volume.png";
            ImageSound = "/UserControls/Sound.png";

            //MessageBox.Show(Convert.ToString(new Uri(@"../audio/y2mate.com - Wii Music  Gaming Background Music HD.mp3", UriKind.Relative)));
            _music.Open(new Uri("y2mate.com - Wii Music  Gaming Background Music HD.mp3", UriKind.Relative));
            _music.MediaEnded += ReplayMusic;
            _sound.Open(new Uri("y2mate.com - Video Game Beep  Sound Effect.mp3", UriKind.Relative));
            this.MedalCompleteWrite = "/images/medal/HoanThanhTapViet.png";
            this.MedalGoodWrite = "/images/medal/TotTapViet.png";
            this.MedalExcelentWrite = "/images/medal/XuatSacTapViet.png";
            this.MedalCompleteRead = "/images/medal/HoanThanhTapDoc.png";
            this.MedalGoodRead = "/images/medal/TotTapDoc.png";
            this.MedalExcelentRead = "/images/medal/XuatSacTapDoc.png";
            this.MedalCompleteGame = "/images/medal/HoanThanhTroChoi.png";
            this.MedalGoodGame = "/images/medal/TotTroChoi.png";
            this.MedalExcelentGame = "/images/medal/XuatSacTroChoi.png";
            this.MedalCompleteQuizz = "/images/medal/HoanThanhNhanBiet.png";
            this.MedalGoodQuizz = "/images/medal/TotNhanBiet.png";
            this.MedalExcelentQuizz = "/images/medal/XuatSacNhanBiet.png";


        }

        private BaseViewModel _achi;

        public BaseViewModel Achi
        {
            get
            {
                return _achi;
            }
            set
            {
                _achi = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowAchi
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    // if ((s1 >= 100 && s1<250 && MedalCompleteWrite == "/images/medal/HoanThanhTapViet.png") || (s1 >= 250 && s1<350 && MedalGoodWrite == "/images/medal/TotTapViet.png") || (s1 >= 390 && MedalExcelentWrite == "/images/medal/XuatSacTapViet.png") || (s2 >= 5 && s2<9 && MedalCompleteGame == "/images/medal/HoanThanhTroChoi.png") || (s2 >= 9 && s2 <13 && MedalGoodGame == "/images/medal/TotTroChoi.png") || (s2 >=13 && MedalExcelentGame == "/images/medal/XuatSacTroChoi.png") || (s4 >= 5 && s4 < 9 && MedalCompleteQuizz == "/images/medal/HoanThanhNhanBiet.png") || (s3 >= 15 && MedalExcelentRead == "/images/medal/XuatSacTapDoc.png") || (s3 >= 13 && s3 <15 && MedalGoodRead == "/images/medal/TotTapDoc.png") || (s3 >= 9 || s3 <13 && MedalCompleteRead == "/images/medal/HoanThanhTapDoc.png") || (s4 >= 9 && s4<13 && MedalGoodQuizz == "/images/medal/TotNhanBiet.png") || (s4 >= 13 && MedalExcelentQuizz == "/images/medal/XuatSacNhanBiet.png"))
                    Achi = new NewAchivmViewModel();
                });
            }

            set { }
        }
        public void ReplayMusic(object sender, EventArgs e)
        {
            _music.Position = TimeSpan.Zero;
            _music.Play();
        }

        public BaseViewModel NavigatetoHome
        {
            get
            {
                return _navigatetoHome;
            }
            set
            {
                _navigatetoHome = value;
                OnPropertyChanged();
            }
        }
        public ICommand TransformToRead
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    _music.Stop();
                    NavigatetoHome = new ReadViewModel();
                    Menu = null;

                });
            }

            set { }
        }
        public ICommand TransformToWrite
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new WriteViewModel();
                    Menu = null;

                });
            }

            set { }
        }
        public ICommand TransformToPuzzle
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    _music.Stop();
                    NavigatetoHome = new QuizzView1ViewModel();
                    Menu = null;
                });
            }

            set { }
        }
        public ICommand TransformToCoding
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new CodingViewModel();
                    Menu = null;

                });
            }

            set { }
        }

        public ICommand TransformOutRead
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    _music.Position = TimeSpan.Zero;
                    _music.Play();
                    NavigatetoHome = new HomeViewModel();
                    Menu = null;

                });
            }

            set { }
        }

        //public ICommand TransformOutRead
        //{
        //    get
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            _music.Position = TimeSpan.Zero;
        //            _music.Play();
        //            NavigatetoHome = new HomeViewModel();
        //        });
        //    }

        //    set { }
        //}
        public ICommand Transform
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new HomeViewModel();
                    Menu = null;

                });
            }

            set { }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
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

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }


        public ICommand Register
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, async (p) =>
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    string email = Email;
                    string password = Password;
                    string confirmPassword = ConfirmPassword;
                    string userName = UserName;

                    if (email == null || password == null || confirmPassword == null || userName == null)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                        return;
                    }
                    if (password != confirmPassword)
                    {
                        MessageBox.Show("Xác nhận mật khẩu sai");
                        //return;
                    }

                    if (password.Length < 6)
                    {
                        MessageBox.Show("Tài khoản chưa hợp lệ! Vui lòng nhập mật khẩu tối thiểu 6 ký tự");
                        //return;
                    }

                    try
                    {
                        string firebaseApikey = "AIzaSyASQNYYKfeSJWHfbYiw4KDlxNrQk9qFQqA";

                        var f = new FirebaseAuthProvider(new FirebaseConfig(firebaseApikey));
                        var a = await f.CreateUserWithEmailAndPasswordAsync(email, password, userName);

                        // create user in firestore
                        DocumentReference doc = Firestore.db.Collection("user").Document(email);
                        Dictionary<string, object> data = new Dictionary<string, object> {
                            {"birthDay", "" },
                            {"gender", true },
                            {"name", userName },
                            { "score_1", Enumerable.Repeat(0, 68).ToArray() },
                            { "score_2", Enumerable.Repeat(0, 68).ToArray() },
                            { "score_3", Enumerable.Repeat(0, 68).ToArray() },
                            { "score_4", Enumerable.Repeat(0, 68).ToArray() }
                    };
                        await doc.SetAsync(data);

                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        MessageBox.Show("Đăng ký thành công");

                        //  PartOnBoarding = new LoginViewModel();
                        // Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Không có đăng ký nào");
                        //  PartOnBoarding = new LoginViewModel();
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                        //throw;
                    }


                });
            }
            set { }
        }



        public ICommand Login
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, async (p) =>
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    string email = Email;
                    string password = Password;
                    string confirmPassword = ConfirmPassword;
                    string userName = UserName;
                    userEmail = email;

                    try
                    {

                        string firebaseApikey = "AIzaSyASQNYYKfeSJWHfbYiw4KDlxNrQk9qFQqA";

                        var f = new FirebaseAuthProvider(new FirebaseConfig(firebaseApikey));
                        FirebaseAuthLink firebaseAuthLink = await f.SignInWithEmailAndPasswordAsync(email, password);
                        UserName = firebaseAuthLink.User.DisplayName;
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        NavigatetoHome = new HomeViewModel();


                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Mật khẩu hoặc email không hợp lệ!");
                        //throw;
                    }


                });
            }
            set { }
        }

        public ICommand Logout
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, async (p) =>
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    string email = Email;
                    string password = Password;
                    string confirmPassword = ConfirmPassword;
                    string userName = UserName;
                    userEmail = email;

                    try
                    {

                        string firebaseApikey = "AIzaSyASQNYYKfeSJWHfbYiw4KDlxNrQk9qFQqA";
                        NavigatetoHome = new OnBoardingViewModel();
                        var f = new FirebaseAuthProvider(new FirebaseConfig(firebaseApikey));
                        FirebaseAuthLink firebaseAuthLink = null;
                        Menu = null;
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                    }
                    catch (Exception e)
                    {
                        //throw;
                    }
                });
            }
            set { }
        }

        public ICommand TransformToUser
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    ChangeMedal();
                    GetHighScore();
                    GetTotalScore();
                    Ranking();
                    GetNumber();
                    _music.Play();
                    NavigatetoHome = new UserViewModel();
                    Menu = null;
                });
            }

            set { }
        }

        public ICommand TransformToGame
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new GameViewModel();
                    Menu = null;

                });
            }

            set { }
        }

        public ICommand TransformToRegister
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new RegisterBugViewModel();

                });
            }

            set { }
        }


        //public ICommand TurnOffMenu
        //{

        //    get
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            if (_navigatetoHome == HomeViewModel)
        //            {
        //                NavigatetoHome = new UserViewModel();
        //            }
        //        });
        //    }

        //    set { }
        //}

        //public void SupportTurnOffMenu()
        //{

        //}

        private BaseViewModel _menu;

        public BaseViewModel Menu
        {
            get
            {
                return _menu;
            }
            set
            {
                _menu = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowMenu
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Menu = new MenuViewModel();
                });
            }

            set { }
        }


        public ICommand HideMenu
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Menu = null;
                });
            }

            set { }
        }




        //public ICommand DetailAchi
        //{
        //    get
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            Achi = new UserRankingViewModel();
        //        });
        //    }

        //    set { }
        //}
        public ICommand TransformToQuizzView1
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new QuizzView1ViewModel();
                    Menu = null;

                });
            }
            set { }
        }
        public ICommand TransformToQuizzView2
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    //NavigatetoHome = new QuizzView2ViewModel();
                    // NavigatetoHome = new QuizzView2ViewModel();
                    Menu = null;

                });
            }
            set { }
        }

        public ICommand TransformtoRateView
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new RateViewModel();
                    Menu = null;

                });
            }
            set { }
        }

        public ICommand Show
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoHome = new OnBoardingViewModel();
                    Menu = null;

                });
            }

            set { }
        }

        //play sound + button on menu

        public string _imageVolume;

        public MediaPlayer _sound = new MediaPlayer();
        public MediaPlayer _music = new MediaPlayer();

        public string ImageVolume
        {
            get
            {
                return _imageVolume;

            }
            set
            {

                _imageVolume = value;
                OnPropertyChanged();
            }
        }

        public ICommand VolumeButtom
        {
            get
            {

                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    if (ImageVolume == "/UserControls/Volume.png")
                    {
                        ImageVolume = "/UserControls/Mute.png";
                        _sound.Stop();
                        isSound = false;

                    }
                    else if (ImageVolume == "/UserControls/Mute.png")
                    {
                        ImageVolume = "/UserControls/Volume.png";
                        //if (MouseAction.LeftClick(true))
                        //{
                        //    _sound.Play();
                        //}
                        _sound.Position = TimeSpan.Zero;

                        _sound.Play();
                        isSound = true;

                    }

                });
            }

            set { }
        }


        public string _imageSound;

        public string ImageSound
        {
            get
            {
                return _imageSound;

            }
            set
            {

                _imageSound = value;
                OnPropertyChanged();
            }
        }


        public ICommand SoundButtom
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    if (ImageSound == "/UserControls/Sound.png")
                    {
                        ImageSound = "/UserControls/noSound.png";
                        _music.Stop();

                    }
                    else if (ImageSound == "/UserControls/noSound.png")
                    {
                        ImageSound = "/UserControls/Sound.png";

                        //  _music.Position = TimeSpan.Zero;
                        _music.Play();
                    }

                });
            }

            set { }
        }
        //avartar
        protected string _avatar = "1";
        public string Avatar
        {
            get
            {
                return "/Avartar/" + _avatar + ".png";
            }
            set
            {
                _avatar = value;
                OnPropertyChanged();
            }
        }

        public ICommand b1
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "1";
                });
            }

            set { }
        }
        public ICommand b2
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "2";
                });
            }

            set { }
        }
        public ICommand b3
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "3";
                });
            }

            set { }
        }
        public ICommand b4
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "4";
                });
            }

            set { }
        }
        public ICommand b5
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "5";
                });
            }

            set { }
        }
        public ICommand b6
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "6";
                });
            }

            set { }
        }
        public ICommand b7
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "7";
                });
            }

            set { }
        }
        public ICommand b8
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "8";
                });
            }

            set { }
        }
        public ICommand b9
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "9";
                });
            }

            set { }
        }
        public ICommand b10
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "10";
                });
            }

            set { }
        }
        public ICommand b11
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "11";
                });
            }

            set { }
        }
        public ICommand b12
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "12";
                });
            }

            set { }
        }
        public ICommand b13
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "13";
                });
            }

            set { }
        }
        public ICommand b14
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "14";
                });
            }

            set { }
        }
        public ICommand b15
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    Avatar = "15";
                });
            }

            set { }
        }
        //public void heyClick(object sender, RoutedEventArgs e)
        //{
        //    if (sender.Equals(a))
        //    {
        //        //User click BtnA to trigger TestBtn_Click()
        //    }
        //    else if (sender.Equals(a))
        //    {
        //        //User click BtnB to trigger TestBtn_Click()
        //    }
        //    else
        //    {
        //        //trigger TestBtn_Click() by another reason.
        //    }
        //}



        //firebase

        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public BaseViewModel CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsOpen => _modalNavigationStore.IsOpen;

        public MainViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsOpen));
        }


        //protected string _medal;


        //public string Medal
        //{
        //    get
        //    {
        //        return _medal;

        //    }
        //    set
        //    {
        //        _medal = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public ICommand ChangeMedal
        //{
        //    get
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            int s1 = 0;
        //            for (int i = 0; i <= 67; i++)
        //                s1 += UserData.score_1[i];
        //            if (s1 >= 100 && s1 < 250)
        //            {
        //                Medal = "/images/medal/HCHoanThanhTapViet.png";
        //            }
        //            else if (s1 >= 250 && s1 < 390)
        //            {
        //                Medal = "/images/medal/HCTotTapViet.png";
        //            }
        //            else if (s1 >= 390)
        //            {
        //                Medal = "/images/medal/HCXuatSacTapViet.png";
        //            }
        //        });
        //    }
        //    set
        //    {
        //    }
        //}

        //medal
        protected string _medalCompleteWrite;
        protected string _medalCompleteRead;
        protected string _medalCompleteGame;
        protected string _medalCompleteQuizz;

        protected string _medalGoodWrite;
        protected string _medalGoodRead;
        protected string _medalGoodGame;
        protected string _medalGoodQuizz;

        protected string _medalExcelentWrite;
        protected string _medalExcelentRead;
        protected string _medalExcelentGame;
        protected string _medalExcelentQuizz;

        protected string _medal;

        public string Medal
        {
            get
            {
                return _medal;

            }
            set
            {
                _medal = value;
                OnPropertyChanged();
            }
        }

        public string MedalCompleteWrite
        {
            get
            {
                return _medalCompleteWrite;

            }
            set
            {
                _medalCompleteWrite = value;
                OnPropertyChanged();
            }
        }

        public string MedalGoodWrite
        {
            get
            {
                return _medalGoodWrite;

            }
            set
            {
                _medalGoodWrite = value;
                OnPropertyChanged();
            }
        }

        public string MedalExcelentWrite
        {
            get
            {
                return _medalExcelentWrite;

            }
            set
            {
                _medalExcelentWrite = value;
                OnPropertyChanged();
            }
        }

        public string MedalCompleteQuizz
        {
            get
            {
                return _medalCompleteQuizz;

            }
            set
            {
                _medalCompleteQuizz = value;
                OnPropertyChanged();
            }
        }

        public string MedalGoodQuizz
        {
            get
            {
                return _medalGoodQuizz;

            }
            set
            {
                _medalGoodQuizz = value;
                OnPropertyChanged();
            }
        }

        public string MedalExcelentQuizz
        {
            get
            {
                return _medalExcelentQuizz;

            }
            set
            {
                _medalExcelentQuizz = value;
                OnPropertyChanged();
            }
        }
        public string MedalCompleteGame
        {
            get
            {
                return _medalCompleteGame;

            }
            set
            {
                _medalCompleteGame = value;
                OnPropertyChanged();
            }
        }

        public string MedalGoodGame
        {
            get
            {
                return _medalGoodGame;

            }
            set
            {
                _medalGoodWrite = value;
                OnPropertyChanged();
            }
        }

        public string MedalExcelentGame
        {
            get
            {
                return _medalExcelentGame;

            }
            set
            {
                _medalExcelentGame = value;
                OnPropertyChanged();
            }
        }
        public string MedalCompleteRead
        {
            get
            {
                return _medalCompleteRead;

            }
            set
            {
                _medalCompleteRead = value;
                OnPropertyChanged();
            }
        }

        public string MedalGoodRead
        {
            get
            {
                return _medalGoodRead;

            }
            set
            {
                _medalGoodRead = value;
                OnPropertyChanged();
            }
        }

        public string MedalExcelentRead
        {
            get
            {
                return _medalExcelentRead;

            }
            set
            {
                _medalExcelentRead = value;
                OnPropertyChanged();
            }
        }


        int s1 = 0;
        int s2 = 0;
        int s3 = 0;
        int s4 = 0;

        public void ChangeMedal()
        {
            for (int i = 0; i <= 29; i++)
                s1 += UserData.score_1[i];
            if (s1 < 40)
            {
                MedalCompleteWrite = "/images/medal/HoanThanhTapViet.png";
                MedalGoodWrite = "/images/medal/TotTapViet.png";
                MedalExcelentWrite = "/images/medal/XuatSacTapViet.png";
            }
            else if (s1 >= 40 && s1 < 100)
            {
                MedalCompleteWrite = "/images/medal/HCHoanThanhTapViet.png";
                MedalGoodWrite = "/images/medal/TotTapViet.png";
                MedalExcelentWrite = "/images/medal/XuatSacTapViet.png";
                Medal = "/images/medal/HCHoanThanhTapViet.png";
            }
            else if (s1 >= 100 && s1 < 150)
            {
                MedalCompleteWrite = "/images/medal/HCHoanThanhTapViet.png";
                MedalGoodWrite = "/images/medal/HCTotTapViet.png";
                MedalExcelentWrite = "/images/medal/XuatSacTapViet.png";
                Medal = "/images/medal/HCTotTapViet.png";
            }
            else if (s1 >= 150)
            {
                MedalCompleteWrite = "/images/medal/HCHoanThanhTapViet.png";
                MedalGoodWrite = "/images/medal/HCTotTapViet.png";
                MedalExcelentWrite = "/images/medal/HCXuatSacTapViet.png";
                Medal = "/images/medal/HCXuatSacTapViet.png";

            }

            for (int i = 0; i <= 3; i++)
                s2 += UserData.score_2[i];
            if (s2 < 5)
            {
                MedalCompleteGame = "/images/medal/HoanThanhTroChoi.png";
                MedalGoodGame = "/images/medal/TotTroChoi.png";
                MedalExcelentGame = "/images/medal/XuatSacTroChoi.png";
            }
            else if (s2 >= 5 && s2 < 9)
            {
                MedalCompleteGame = "/images/medal/HCHoanThanhTroChoi.png";
                MedalGoodGame = "/images/medal/TotTroChoi.png";
                MedalExcelentGame = "/images/medal/XuatSacTroChoi.png";
                Medal = "/images/medal/HCHoanThanhTroChoi.png";
            }
            else if (s2 >= 9 && s2 < 13)
            {
                MedalCompleteGame = "/images/medal/HCHoanThanhTroChoi.png";
                MedalGoodGame = "/images/medal/HCTotTroChoi.png";
                MedalExcelentGame = "/images/medal/XuatSacTroChoi.png";
                Medal = "/images/medal/HCTotTroChoi.png";
            }
            else if (s2 >= 13)
            {
                MedalCompleteGame = "/images/medal/HCHoanThanhTroChoi.png";
                MedalGoodGame = "/images/medal/HCTotTroChoi.png";
                MedalExcelentGame = "/images/medal/HCXuatSacTroChoi.png";
                Medal = "/images/medal/HCXuatSacTroChoi.png";
            }

            for (int i = 0; i <= 26; i++)
                s3 += UserData.score_3[i];
            if (s3 < 9)
            {
                MedalCompleteRead = "/images/medal/HoanThanhTapDoc.png";
                MedalGoodRead = "/images/medal/TotTapDoc.png";
                MedalExcelentRead = "/images/medal/XuatSacTapDoc.png";
            }
            else if (s3 >= 9 && s3 < 15)
            {
                MedalCompleteRead = "/images/medal/HCHoanThanhTapDoc.png";
                MedalGoodRead = "/images/medal/TotTapDoc.png";
                MedalExcelentRead = "/images/medal/XuatSacTapDoc.png";
                Medal = "/images/medal/HCHoanThanhTapDoc.png";
            }
            else if (s3 >= 15 && s3 < 23)
            {
                MedalCompleteRead = "/images/medal/HCHoanThanhTapDoc.png";
                MedalGoodRead = "/images/medal/HCTotTapDoc.png";
                MedalExcelentRead = "/images/medal/XuatSacTapDoc.png";
                Medal = "/images/medal/HCTotTapDoc.png";
            }
            else if (s3 >= 23)
            {
                MedalCompleteRead = "/images/medal/HCHoanThanhTapDoc.png";
                MedalGoodRead = "/images/medal/HCTotTapDoc.png";
                MedalExcelentRead = "/images/medal/HCXuatSacTapDoc.png";
                Medal = "/images/medal/HCXuatSacTapDoc.png";
            }

            for (int i = 0; i <= 15; i++)
                s4 += UserData.score_4[i];
            if (s4 < 5)
            {
                MedalCompleteQuizz = "/images/medal/HoanThanhNhanBiet.png";
                MedalGoodQuizz = "/images/medal/TotNhanBiet.png";
                MedalExcelentQuizz = "/images/medal/XuatSacNhanBiet.png";
            }
            else if (s4 >= 5 && s4 < 9)
            {
                MedalCompleteQuizz = "/images/medal/HCHoanThanhNhanBiet.png";
                MedalGoodQuizz = "/images/medal/TotNhanBiet.png";
                MedalExcelentQuizz = "/images/medal/XuatSacNhanBiet.png";
                Medal = "/images/medal/HCHoanThanhNhanBiet.png";
            }
            else if (s4 >= 9 && s4 < 13)
            {
                MedalCompleteQuizz = "/images/medal/HCHoanThanhNhanBiet.png";
                MedalGoodQuizz = "/images/medal/HCTotNhanBiet.png";
                MedalExcelentQuizz = "/images/medal/XuatSacNhanBiet.png";
                Medal = "/images/medal/HCTotNhanBiet.png";
            }
            else if (s4 >= 13)
            {
                MedalCompleteQuizz = "/images/medal/HCHoanThanhNhanBiet.png";
                MedalGoodQuizz = "/images/medal/HCTotNhanBiet.png";
                MedalExcelentQuizz = "/images/medal/HCXuatSacNhanBiet.png";
                Medal = "/images/medal/HCXuatSacNhanBiet.png";
            }
        }

        protected string _highWriteScore;
        public string HighWriteScore
        {
            get { return _highWriteScore; }
            set
            {
                _highWriteScore = value;
                OnPropertyChanged();
            }
        }

        protected string _highReadScore;
        public string HighReadScore
        {
            get { return _highReadScore; }
            set
            {
                _highReadScore = value;
                OnPropertyChanged();
            }
        }
        protected string _highGameScore;
        public string HighGameScore
        {
            get { return _highGameScore; }
            set
            {
                _highGameScore = value;
                OnPropertyChanged();
            }
        }
        protected string _highQuizzScore;
        public string HighQuizzScore
        {
            get { return _highQuizzScore; }
            set
            {
                _highQuizzScore = value;
                OnPropertyChanged();
            }
        }
        public void GetHighScore()
        {
            HighWriteScore = Convert.ToString(UserData.score_1[0]);
            for (int i = 1; i <= 29; i++)
            {
                if (UserData.score_1[i] > UserData.score_1[i - 1])
                { HighWriteScore = Convert.ToString(UserData.score_1[i]); }
            }

            HighReadScore = Convert.ToString(UserData.score_3[0]);
            for (int j = 1; j <= 29; j++)
            {
                if (UserData.score_3[j] > UserData.score_3[j - 1])
                { HighReadScore = Convert.ToString(UserData.score_3[j]); }
            }

            HighQuizzScore = Convert.ToString(UserData.score_4[0]);
            for (int t = 1; t <= 14; t++)
            {
                if (UserData.score_4[t] > UserData.score_4[t - 1])
                { HighQuizzScore = Convert.ToString(UserData.score_4[t]); }

            }

            HighGameScore = Convert.ToString(UserData.score_2[0]);
            for (int k = 1; k <= 2; k++)
            {
                if (UserData.score_2[k] > UserData.score_4[k - 1])
                { HighGameScore = Convert.ToString(UserData.score_2[k]); }
            }


        }
        protected string _totalWriteScore;
        public string TotalWriteScore
        {
            get { return _totalWriteScore; }
            set
            {
                _totalWriteScore = value;
                OnPropertyChanged();
            }
        }

        protected string _totalReadScore;
        public string TotalReadScore
        {
            get { return _totalReadScore; }
            set
            {
                _totalReadScore = value;
                OnPropertyChanged();
            }
        }

        protected string _totalQuizzScore;
        public string TotalQuizzScore
        {
            get { return _totalQuizzScore; }
            set
            {
                _totalQuizzScore = value;
                OnPropertyChanged();
            }
        }

        protected string _totalScore;
        public string TotalScore
        {
            get { return _totalScore; }
            set
            {
                _totalScore = value;
                OnPropertyChanged();
            }
        }

        protected string _totalGameScore;
        public string TotalGameScore
        {
            get { return _totalGameScore; }
            set
            {
                _totalGameScore = value;
                OnPropertyChanged();
            }
        }
        public void GetTotalScore()
        {
            int s1 = 0;
            int s2 = 0;
            int s3 = 0;
            int s4 = 0;
            for (int i = 0; i <= 29; i++)
                s1 += UserData.score_1[i];
            TotalWriteScore = Convert.ToString(s1);
            for (int j = 0; j <= 29; j++)
                s3 += UserData.score_3[j];

            TotalReadScore = Convert.ToString(s3);
            for (int t = 0; t <= 14; t++)
                s4 += UserData.score_4[t];
            TotalQuizzScore = Convert.ToString(s4);
            for (int k = 0; k <= 3; k++)
                s2 += UserData.score_2[k];
            TotalGameScore = Convert.ToString(s2);
            TotalScore = Convert.ToString(s3 + s1 + s2 + s4);
        }

        /// <summary>
        /// 
        /// </summary>
        protected string _rankQuizzScore;
        public string RankQuizzScore
        {
            get { return "Đúng là thiên tài! Đã có " + _rankQuizzScore + " người đoán sai nhiều hơn bạn đấy"; }
            set
            {
                _rankQuizzScore = value;
                OnPropertyChanged();
            }
        }
        protected string _rankWriteScore;
        public string RankWriteScore
        {
            get { return "Thật tuyệt vời! Bạn viết khéo hơn " + _rankWriteScore + " người "; }
            set
            {
                _rankWriteScore = value;
                OnPropertyChanged();
            }
        }

        protected string _rankGameScore;
        public string RankGameScore
        {
            get { return "Trời ơi tin được không!? Bạn chơi giỏi hơn " + _rankGameScore + " người luôn đó "; }
            set
            {
                _rankGameScore = value;
                OnPropertyChanged();
            }
        }
        protected string _rankReadScore;
        public string RankReadScore
        {
            get { return "Bạn đã đọc tốt hơn " + _rankReadScore + " người rồi đấy!"; }
            set
            {
                _rankReadScore = value;
                OnPropertyChanged();
            }
        }

        async public void Ranking()
        {
            List<UserInfo> users = new List<UserInfo>();
            QuerySnapshot allUsers = await Firestore.db.Collection("user").GetSnapshotAsync();
            foreach (DocumentSnapshot user in allUsers.Documents)
                users.Add(user.ConvertTo<UserInfo>());



            List<int> totalScore1 = new List<int>();
            List<int> totalScore2 = new List<int>();
            List<int> totalScore3 = new List<int>();
            List<int> totalScore4 = new List<int>();


            users.ForEach(user =>
            {
                int s1 = 0;
                for (int i = 0; i < user.score_1.Length; i++)
                {
                    s1 += user.score_1[i];
                }
                totalScore1.Add(s1);

                int s2 = 0;
                for (int i = 0; i < user.score_2.Length; i++)
                {
                    s2 += user.score_2[i];
                }
                totalScore2.Add(s2);


                int s3 = 0;
                for (int i = 0; i < user.score_3.Length; i++)
                {
                    s3 += user.score_3[i];
                }
                totalScore3.Add(s3);


                int s4 = 0;
                for (int i = 0; i < user.score_4.Length; i++)
                {
                    s4 += user.score_4[i];
                }
                totalScore4.Add(s4);

            });
            totalScore1.Sort();
            totalScore2.Sort();
            totalScore3.Sort();
            totalScore4.Sort();
            GetTotalScore();
            for (int i = 0; i < totalScore1.Count; i++)
                if (Convert.ToInt32(TotalWriteScore) == totalScore1[i])
                    RankWriteScore = Convert.ToString(i);
            for (int i = 0; i < totalScore2.Count; i++)
                if (Convert.ToInt32(TotalGameScore) == totalScore2[i])
                    RankGameScore = Convert.ToString(i);
            for (int i = 0; i < totalScore1.Count; i++)
                if (Convert.ToInt32(TotalReadScore) == totalScore3[i])
                    RankReadScore = Convert.ToString(i);
            for (int i = 0; i < totalScore1.Count; i++)
                if (Convert.ToInt32(TotalQuizzScore) == totalScore4[i])
                    RankQuizzScore = Convert.ToString(i);
        }

        protected string _writeNumber;
        public string WriteNumber
        {
            get { return _writeNumber; }
            set
            {
                _writeNumber = value;
                OnPropertyChanged();
            }
        }

        protected string _readNumber;
        public string ReadNumber
        {
            get { return _readNumber; }
            set
            {
                _readNumber = value;
                OnPropertyChanged();
            }
        }

        protected string _quizzNumber;
        public string QuizzNumber
        {
            get { return _quizzNumber; }
            set
            {
                _quizzNumber = value;
                OnPropertyChanged();
            }
        }

        protected string _gameNumber;
        public string GameNumber
        {
            get { return _gameNumber; }
            set
            {
                _gameNumber = value;
                OnPropertyChanged();
            }
        }

        public void GetNumber()
        {
            for (int i = 0; i < UserData.score_1.Length; i++)
                if (UserData.score_1[i] == 0)
                {
                    WriteNumber = Convert.ToString(i);
                    break;
                }
            int dem2 = 0;
            int dem3 = 0;
            int dem4 = 0;
            for (int i = 0; i < UserData.score_2.Length; i++)
                if (UserData.score_2[i] != 0)
                    dem2++;
            GameNumber = Convert.ToString(dem2);

            for (int i = 0; i < UserData.score_3.Length; i++)
                if (UserData.score_3[i] != 0)
                    dem3++;
            ReadNumber = Convert.ToString(dem3);

            for (int i = 0; i < UserData.score_4.Length; i++)
                if (UserData.score_4[i] != 0)
                    dem4++;
            QuizzNumber = Convert.ToString(dem4);




        }
    }




}
