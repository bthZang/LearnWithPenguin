using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class GameViewModel: BaseViewModel
    {
        protected BaseViewModel _navigatetoCoding;

        public BaseViewModel NavigatetoCoding
        {
            get
            {
                return _navigatetoCoding;
            }
            set
            {
                _navigatetoCoding = value;
                OnPropertyChanged();
            }
        }

        public ICommand TransformToCoding
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    NavigatetoCoding = new CodingViewModel();
                });
            }

            set { }
        }


    }
}
