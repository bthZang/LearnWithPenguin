using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace LearnWithPenguin.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public string _imageVolume;

        protected MediaPlayer _sound = new MediaPlayer();
        protected MediaPlayer _music = new MediaPlayer();

        readonly Version version = Assembly.GetExecutingAssembly().GetName().Version;
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


        public MenuViewModel()
        {
            ImageVolume = "/UserControls/Volume.png";
            ImageSound = "/UserControls/Sound.png";
            _music.Open(new Uri(string.Format("D:\\Zangg\\Penguin\\UIT\\HK3-II\\LTTQ\\y2mate.com - Wii Music  Gaming Background Music HD.mp3")));
            _sound.Open(new Uri(string.Format("D:\\Zangg\\Penguin\\UIT\\HK3-II\\LTTQ\\y2mate.com - Video Game Beep  Sound Effect.mp3")));
            
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
                        _music.Position = TimeSpan.Zero;
                        _music.Play();
                        if (_music.Position == TimeSpan.MaxValue)
                        {
                            _music.Position = TimeSpan.Zero;
                            _music.Play();
                        }
                    }

                });
            }

            set { }
        }
    }
}
