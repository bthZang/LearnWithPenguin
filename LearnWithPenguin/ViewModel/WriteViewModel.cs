using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace LearnWithPenguin.ViewModel
{
    public class WriteViewModel : BaseViewModel
    {
        protected string _isDisplayVideo;

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
        }
    }

}
