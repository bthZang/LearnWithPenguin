using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LearnWithPenguin.UserControls;

namespace LearnWithPenguin.ViewModel
{
    public class NoViewModel : BaseViewModel
    {
        public ICommand GoToBadResult { get; set; }
        private System.Windows.Controls.UserControl _GameResult;
        public System.Windows.Controls.UserControl GameResult { get { return _GameResult; } set { _GameResult = value; OnPropertyChanged(); } }
        public NoViewModel()
        {
            GoToBadResult = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => {
                p.Visibility= System.Windows.Visibility.Hidden;
                GameResult = new BadResult();
            });
        }
    }
}
