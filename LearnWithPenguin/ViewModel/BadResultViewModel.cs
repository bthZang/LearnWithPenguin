using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class BadResultViewModel : BaseViewModel
    {
        public string _star;

        public BadResultViewModel()
        { 
            this.Star = "white";

        }

        Random random = new Random();
        string[] color = new string[2] { "yellow", "white" };
        public string Star
        {
            get
            {
                return _star;
            }
            set
            {
                
                _star = color[random.Next(color.Length)];
                ChangeColor = "";

                OnPropertyChanged();
            }
        }


        public string ChangeColor
        {
            get
            {
                return "/UserControls/" + _star + "Star.png";
            }
            set
            {
                OnPropertyChanged();
            }
        }
    }
}
