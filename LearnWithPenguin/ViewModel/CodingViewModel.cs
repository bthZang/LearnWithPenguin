
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class CodingViewModel : BaseViewModel
    {
        public ICommand ReviewTransform { get; set; }
        public ICommand PlayTransform { get; set; }

        public CodingViewModel()
        {
            ReviewTransform = new RelayCommand<System.Windows.Controls.UserControl>((p) => {return true;},(p) => { });
            PlayTransform = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return true; }, (p) => { });
        }
    }
}
