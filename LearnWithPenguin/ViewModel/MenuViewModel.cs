using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public string _imageVolume;

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

        }

        public ICommand VolumeButtom
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    if (ImageVolume == "/UserControls/Volume.png")
                        ImageVolume = "/UserControls/Mute.png";
                    else if (ImageVolume == "/UserControls/Mute.png")
                        ImageVolume = "/UserControls/Volume.png";

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
                        ImageSound = "/UserControls/noSound.png";
                    else if (ImageSound == "/UserControls/noSound.png")
                        ImageSound = "/UserControls/Sound.png";

                });
            }

            set { }
        }
    }
}
