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
    }

}
