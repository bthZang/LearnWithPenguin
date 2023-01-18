using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LearnWithPenguin.UserControl;
using LearnWithPenguin.UserControls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Firebase.Auth;
using LearnWithPenguin.Commands;
using LearnWithPenguin.ViewModel;

namespace LearnWithPenguin.ViewModel
{
    public class OnBoardingViewModel : BaseViewModel
    {
        private BaseViewModel _PartOnBoarding;

        private bool _next;
        public bool Next
        {
            get { return _next; }
            set
            {
                _next = value;
                if (_next == true)
                    obacity = "/UserControls/next.png";
                else
                {

                    obacity = "/UserControls/BlurNext.png";
                }
                OnPropertyChanged();
            }
        }

        private string _obacity;

        public string obacity
        {
            get
            {
                return _obacity;

            }
            set
            {

                _obacity = value;
                OnPropertyChanged();
            }
        }

    

        public BaseViewModel PartOnBoarding
        {
            get
            {
                return _PartOnBoarding;
            }
            set
            {
                _PartOnBoarding = value;
                OnPropertyChanged();
            }
        }

        public ICommand Show
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new LoginViewModel();
                });
            }

            set { }
        }

        public ICommand TransformToRegester
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new RegisterViewModel();
                });
            }

            set { }
        }

        public OnBoardingViewModel()
        {
            this.PartOnBoarding = new TextOnBoardingViewModel();
            this.PartOnBoardingTerm = new TermAndConditionViewModel();
            this.obacity = "/UserControls/BlurNext.png";



        }

        private BaseViewModel _partOnBoardingTerm;

        public BaseViewModel PartOnBoardingTerm
        {
            get
            {
                return _partOnBoardingTerm;
            }
            set
            {
                _partOnBoardingTerm = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowTerm
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new TermAndConditionViewModel();
                });
            }

            set { }
        }
        public ICommand HideTerm
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    PartOnBoarding = new TextOnBoardingViewModel();
                });
            }

            set { }
        }


        //register

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand Register
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, async (p) =>
                {

                    string email = Email;
                    string password = Password;
                    string confirmPassword = ConfirmPassword;
                    string userName = UserName;

                    if (password != confirmPassword)
                    {
                        return;
                    }

                    try
                    {
                        string firebaseApikey = "AIzaSyASQNYYKfeSJWHfbYiw4KDlxNrQk9qFQqA";

                        var f = new FirebaseAuthProvider(new FirebaseConfig(firebaseApikey));
                        var a = await f.CreateUserWithEmailAndPasswordAsync(email, password, userName);

                        PartOnBoarding = new LoginViewModel();

                    }
                    catch (Exception e)
                    {
                        //throw;
                    }


                });
            }
            set { }
        }

    }
}
