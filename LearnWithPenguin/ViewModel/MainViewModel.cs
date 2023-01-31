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

namespace LearnWithPenguin.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        protected BaseViewModel _navigatetoHome;

        public bool isClosing = false;
        public bool isSound = true;

        public MainViewModel()
        {
            this.NavigatetoHome = new OnBoardingViewModel();
            ImageVolume = "/UserControls/Volume.png";
            ImageSound = "/UserControls/Sound.png";

            //MessageBox.Show(Convert.ToString(new Uri(@"../audio/y2mate.com - Wii Music  Gaming Background Music HD.mp3", UriKind.Relative)));
            _music.Open(new Uri("y2mate.com - Wii Music  Gaming Background Music HD.mp3", UriKind.Relative));
            _music.MediaEnded += ReplayMusic;
            _sound.Open(new Uri("y2mate.com - Video Game Beep  Sound Effect.mp3", UriKind.Relative));
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
                    NavigatetoHome = new PuzzleViewModel();
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

        public ICommand TransformOutRead
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    _music.Position = TimeSpan.Zero;
                    _music.Play();
                    NavigatetoHome = new HomeViewModel();
                });
            }

            set { }
        }
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
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        MessageBox.Show("Đăng ký thành công");

                      //  PartOnBoarding = new LoginViewModel();
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

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


        public ICommand TransformToUser
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
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
                    NavigatetoHome = new QuizzView2ViewModel();
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
    }

}
