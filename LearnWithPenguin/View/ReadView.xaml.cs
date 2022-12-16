using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for ReadView.xaml
    /// </summary>
    public partial class ReadView : System.Windows.Controls.Page
    {
        public ReadView()
        {
            InitializeComponent();
        }
        public int currentLevel = 1;

        private void NextLesson(object sender, RoutedEventArgs e)
        {
            if (currentLevel == 50)
            {
                currentLevel = 1;
            }
            else
            {
                currentLevel = currentLevel + 1;
            }
            //lesson nanme
            lessonName.Text = "Bai " + currentLevel;

            //picture name
            string pathText = "D:\\School\\testWPFfunc\\FullText\\" + currentLevel + ".txt";
            string text = System.IO.File.ReadAllText(pathText);
            picName.Text = text;

            //image
            string pathImage = "D:\\School\\testWPFfunc\\FullImg\\" + currentLevel + ".jpeg";
            Uri uri = new Uri(pathImage);
            ImgChange.Source = new BitmapImage(uri);

        }

        private void PrevLesson(object sender, RoutedEventArgs e)
        {
            if (currentLevel == 1)
            {
                currentLevel = 50;
            }
            else
            {
                currentLevel = currentLevel - 1;
            }
            //lessson name
            lessonName.Text = "Bai " + currentLevel;

            //picture name
            string pathText = "D:\\School\\testWPFfunc\\FullText\\" + currentLevel + ".txt";
            string text = System.IO.File.ReadAllText(pathText);
            picName.Text = text;

            //picture
            string path = "D:\\School\\testWPFfunc\\FullImg\\" + currentLevel + ".jpeg";
            Uri uri = new Uri(path);
            ImgChange.Source = new BitmapImage(uri);
        }

        private void ReadText(object sender, RoutedEventArgs e)
        {
            string path = "D:\\School\\testWPFfunc\\FullRecord\\" + currentLevel + ".wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
        }
    }
}
