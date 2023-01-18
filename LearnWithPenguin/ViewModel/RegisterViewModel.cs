using Firebase.Auth;
using LearnWithPenguin.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWithPenguin.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
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
                        var a = await f.CreateUserWithEmailAndPasswordAsync(Email, password, UserName);
                    }
                    catch (Exception)
                    { 
                        throw; 
                    }


                });
            }
            set { }
        }

        public RegisterViewModel()
        {
        }




    }
}
