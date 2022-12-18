using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class GameWarnViewModel : BaseViewModel
    {
        public ICommand HideWarning { get; set; }
        public GameWarnViewModel()
        {
            HideWarning = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => {
                p.Visibility = System.Windows.Visibility.Hidden;
            });
        }
    }
}
