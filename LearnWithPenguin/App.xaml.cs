using Firebase.Auth;
using LearnWithPenguin.View;
using LearnWithPenguin.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWithPenguin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host
                .CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    //string firebaseApikey = context.Configuration.GetValue<string>("FIREBASE_API_KEY");
                    //MessageBox.Show(firebaseApikey);
                    string firebaseApikey = "AIzaSyASQNYYKfeSJWHfbYiw4KDlxNrQk9qFQqA";

                    service.AddSingleton(new FirebaseAuthProvider(new FirebaseConfig(firebaseApikey)));

                    service.AddSingleton<OnBoardingView>((services) => new OnBoardingView()
                    {
                        DataContext = new RegisterViewModel()
                    }
                    );
                    
                })
                .Build();
        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //}

        private async void Application_Startup(object sender, StartupEventArgs e)
        {



            //FirebaseAuthProvider firebaseAuthProvider = _host.Services.GetRequiredService<FirebaseAuthProvider>();
            //var t = firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync("hyhygiang@gmail.com", "J@nhbgvfc").Result;

            //string firebaseApikey = "AIzaSyASQNYYKfeSJWHfbYiw4KDlxNrQk9qFQqA";

            //FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(firebaseApikey));
            //var b = await firebaseAuthProvider.SignInAnonymouslyAsync();
            //await firebaseAuthProvider.ChangeUserEmail("CYmXVdn2s7bQYtzahWbIOr92fo62", "hyhy@gmail.com");
            //var a = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync("hoanghy01122003@gmail.com", "J@nhbgvfc", "jkljkj");
            //base.OnStartup(e);
        }
    }
}
