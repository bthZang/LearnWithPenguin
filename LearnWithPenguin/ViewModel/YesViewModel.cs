using LearnWithPenguin.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class YesViewModel : BaseViewModel
    {
        public ICommand GoToYesResult { get; set; }
        private System.Windows.Controls.UserControl _GameResult;
        public System.Windows.Controls.UserControl GameResult { get { return _GameResult; } set { _GameResult = value; OnPropertyChanged(); } }
        public YesViewModel()
        {
            GoToYesResult = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => {
                p.Visibility = System.Windows.Visibility.Hidden;
                GameResult = new GoodResult();
            });
        }
    }
}
