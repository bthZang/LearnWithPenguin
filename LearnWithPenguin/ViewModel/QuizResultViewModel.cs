using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.ViewModel
{
    public class QuizResultViewModel : BaseViewModel
    {
        protected string _greenTick;
        protected string _redCross;

        public QuizResultViewModel()
        {
            
        }

        public string ConcatGreen
        {
            get
            {
                return "/images/greenTick.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }
        public string ConcatRed
        {
            get
            {
                return "/images/redCross.png";
            }
            set
            { 
                OnPropertyChanged(); 
            }
        }


    }

}
