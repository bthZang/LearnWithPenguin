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
using LearnWithPenguin.HelperClasses;

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
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    string email = Email;
                    string password = Password;
                    string confirmPassword = ConfirmPassword;
                    string userName = UserName;


                    if (password != confirmPassword)
                    {
                        MessageBox.Show("Xác nhận mật khẩu sai");
                        return;
                    }

                    if (password.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu tối thiểu 6 ký tự");
                        return;
                    }

                    try
                    {
                        string firebaseApikey = "AIzaSyASQNYYKfeSJWHfbYiw4KDlxNrQk9qFQqA";

                        var f = new FirebaseAuthProvider(new FirebaseConfig(firebaseApikey));
                        var a = await f.CreateUserWithEmailAndPasswordAsync(email, password, userName);
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

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

        ////SNIPPING

        //private BaseViewModel _snipping;

        //public BaseViewModel Snipping
        //{
        //    get
        //    {
        //        return _snipping;
        //    }
        //    set
        //    {
        //        _snipping = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public ICommand ShowSnipping
        //{
        //    get
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            Snipping = new LoadingPanelViewModel();
        //        });
        //    }

        //    set { }
        //}


        //public ICommand HideSnipping
        //{
        //    get
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            Snipping = null;
        //        });
        //    }

        //    set { }
        //}

        ////snipping

        //private bool _panelLoading;
        //private string _panelMainMessage = "Main Loading Message";
        //private string _panelSubMessage = "Sub Loading Message";

        ///// <summary>
        ///// Occurs when a property value changes.
        ///// </summary>
        //public event PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// Gets or sets a value indicating whether [panel loading].
        ///// </summary>
        ///// <value>
        ///// <c>true</c> if [panel loading]; otherwise, <c>false</c>.
        ///// </value>
        //public bool PanelLoading
        //{
        //    get
        //    {
        //        return _panelLoading;
        //    }
        //    set
        //    {
        //        _panelLoading = value;
        //        RaisePropertyChanged("PanelLoading");
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the panel main message.
        ///// </summary>
        ///// <value>The panel main message.</value>
        //public string PanelMainMessage
        //{
        //    get
        //    {
        //        return _panelMainMessage;
        //    }
        //    set
        //    {
        //        _panelMainMessage = value;
        //        RaisePropertyChanged("PanelMainMessage");
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the panel sub message.
        ///// </summary>
        ///// <value>The panel sub message.</value>
        //public string PanelSubMessage
        //{
        //    get
        //    {
        //        return _panelSubMessage;
        //    }
        //    set
        //    {
        //        _panelSubMessage = value;
        //        RaisePropertyChanged("PanelSubMessage");
        //    }
        //}

        ///// <summary>
        ///// Gets the panel close command.
        ///// </summary>
        //public ICommand PanelCloseCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            // Your code here.
        //            // You may want to terminate the running thread etc.
        //            PanelLoading = false;
        //        });
        //    }
        //}

        ///// <summary>
        ///// Gets the show panel command.
        ///// </summary>
        //public ICommand ShowPanelCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            PanelLoading = true;
        //        });
        //    }
        //}

        ///// <summary>
        ///// Gets the hide panel command.
        ///// </summary>
        //public ICommand HidePanelCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            PanelLoading = false;
        //        });
        //    }
        //}

        ///// <summary>
        ///// Gets the change sub message command.
        ///// </summary>
        //public ICommand ChangeSubMessageCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            PanelSubMessage = string.Format("Message: {0}", DateTime.Now);
        //        });
        //    }
        //}

        ///// <summary>
        ///// Raises the property changed.
        ///// </summary>
        ///// <param name="propertyName">Name of the property.</param>
        //protected void RaisePropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }

}
