using Google.Cloud.Firestore;
using LearnWithPenguin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DocumentReference = Google.Cloud.Firestore.DocumentReference;

namespace LearnWithPenguin.UserControls
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : System.Windows.Controls.UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            switch (cb.SelectedIndex)
            {
                case 0:
                    UserData.gender = true;
                    break;
                case 1:
                    UserData.gender = false;
                    break;
            }
            Dictionary<string, object> data = new Dictionary<string, object> {
                {"gender", UserData.gender }
            };
            DocumentReference doc = Firestore.db.Collection("user").Document(UserData.email);
            DocumentSnapshot snap = await doc.GetSnapshotAsync();
            if (snap.Exists)
            {
                await doc.UpdateAsync(data);
                //MessageBox.Show("Cập nhật thành công");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            datePicker.Text = UserData.birthday;
            if (UserData.gender)
                genderComboBox.SelectedIndex = 0;
            else
                genderComboBox.SelectedIndex = 1;
        }

        private async void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UserData.birthday = datePicker.Text;
            Dictionary<string, object> data = new Dictionary<string, object> {
                {"birthday", UserData.birthday }
            };
            DocumentReference doc = Firestore.db.Collection("user").Document(UserData.email);
            DocumentSnapshot snap = await doc.GetSnapshotAsync();
            if (snap.Exists)
            {
                await doc.UpdateAsync(data);
                //MessageBox.Show("Cập nhật thành công");
            }
        }
    }
}
