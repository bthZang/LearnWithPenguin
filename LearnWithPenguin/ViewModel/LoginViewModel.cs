using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public string _display = "";
        public string Display 
        {
            get {
                string a = DisplayOnScreen(_display);
                Console.WriteLine(a);
                return a;
            }
            set
            {
                Console.WriteLine(value);
                _display = value;
                OnPropertyChanged();
            }
        }

        public string  DisplayOnScreen(string dis)
        {
            string scr="";
            for (int i = 0; i < dis.Length; i++)
            {
                scr += "˙";
            }
            return scr;
        }

        //public string _emailLogin = "";
        //public string EmailLogin
        //{
        //    get
        //    {
        //        string a = DisplayOnScreen(_display);
        //        Console.WriteLine(a);
        //        return a;
        //    }
        //    set
        //    {
        //        Console.WriteLine(value);
        //        _display = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public string DisplayOnScreen(string dis)
        //{
        //    string scr = "";
        //    for (int i = 0; i < dis.Length; i++)
        //    {
        //        scr += "˙";
        //    }
        //    return scr;
        //}
    }
}
