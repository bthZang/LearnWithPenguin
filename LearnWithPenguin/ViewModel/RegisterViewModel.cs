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

        public ICommand Register { get; }

        public RegisterViewModel(FirebaseAuthProvider firebaseAuthProvider)
        {
            this.Email = "Email";
            this.Password = "Mật khẩu";
            this.UserName = "Tên người dùng";
            this.ConfirmPassword = "Xác nhận mật khẩu";
            Register = new RegisterCommand(this, firebaseAuthProvider);
        }




    }
}
