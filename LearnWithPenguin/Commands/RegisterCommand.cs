using Firebase.Auth;
using LearnWithPenguin.ViewModel;
using LearnWithPenguin.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly OnBoardingViewModel _registerViewmodel;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        public override async Task ExecuteAsync(object parameter)
        {
            string password = _registerViewmodel.Password;
            string confirmPassword = _registerViewmodel.ConfirmPassword;

            if (password != confirmPassword)
            {
                return;
            }

            try
            {
                await _firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(_registerViewmodel.Email, password, _registerViewmodel.UserName);
            }
            catch (Exception)
            { throw; }


        }

        public RegisterCommand(OnBoardingViewModel onBoardingViewmodel, FirebaseAuthProvider firebaseAuthProvider)
        {
            _registerViewmodel = onBoardingViewmodel;
            _firebaseAuthProvider = firebaseAuthProvider;
        }
    }
}
