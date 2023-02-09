using Firebase.Auth;
using Google.Cloud.Firestore;
using LearnWithPenguin.Utils;
using LearnWithPenguin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : System.Windows.Controls.Page
    {

        public HomeView()
        {
            InitializeComponent();

        }

        async void getData()
        {
            DocumentReference documentReference = Firestore.db.Collection("user").Document(MainViewModel.userEmail);
            DocumentSnapshot snap = await documentReference.GetSnapshotAsync();
            if (snap.Exists)
            {
                //Dictionary<string, object> data = snap.ToDictionary();
                UserInfo user = snap.ConvertTo<UserInfo>();
                //MessageBox.Show(MainViewModel.userEmail);
                UserData.email = MainViewModel.userEmail;
                UserData.name = user.name;
                UserData.birthday = user.birthday;
                UserData.gender = user.gender;
                UserData.score_1 = user.score_1;
                UserData.score_2 = user.score_2;
                UserData.score_3 = user.score_3;
                UserData.score_4 = user.score_4;
                MessageBox.Show("Load dữ liệu thành công");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + @"test-firebase.json";
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            //db = FirestoreDb.Create("test-firebase-66cf9");
            //Firestore.initFireStore();
            getData();
        }
    }
}