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
using static System.Windows.Forms.AxHost;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Windows.Media.Animation;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for ReadView.xaml
    /// </summary>
    
    public partial class ReadView : System.Windows.Controls.Page
    {
        public int currentLevel = 1;
        public string read_Result = "";
        public ReadView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            loadStartData();
        }
        void loadStartData ()
        {
            //load start img
            string pathImage = "/TapDoc/img/1.png";
            Uri uri = new Uri(pathImage, UriKind.Relative);
            ImgChange.Source = new BitmapImage(uri);
        }
        
        private void NextLesson(object sender, RoutedEventArgs e)
        {
            if (currentLevel == 26)
            {
                currentLevel = 1;
            }
            else
            {
                currentLevel = currentLevel + 1;
            }
            //lesson nanme
            lessonName.Text = "Lesson " + currentLevel;

            //picture name
            picName.Text = Convert.ToString(Convert.ToChar(currentLevel - 1 + (int)'A'));

            //image
            string pathImage = "/TapDoc/img/" + currentLevel + ".png";
            Uri uri = new Uri(pathImage, UriKind.Relative);
            ImgChange.Source = new BitmapImage(uri);
            //close bad and good
            goodResult.Visibility = Visibility.Collapsed;
            badResult.Visibility = Visibility.Collapsed;

            // set color
            picName.Foreground = System.Windows.Media.Brushes.White;

            //opacity
            mainScreen.Opacity = 1;
        }

        private void PrevLesson(object sender, RoutedEventArgs e)
        {
            if (currentLevel == 1)
            {
                currentLevel = 26;
            }
            else
            {
                currentLevel = currentLevel - 1;
            }
            //lessson name
            lessonName.Text = "Lesson " + currentLevel;

            //picture name
            picName.Text = Convert.ToString(Convert.ToChar(currentLevel - 1 + (int)'A'));

            //picture
            string path = "/TapDoc/img/" + currentLevel + ".png";
            Uri uri = new Uri(path, UriKind.Relative);
            ImgChange.Source = new BitmapImage(uri);

            //set color
            picName.Foreground = System.Windows.Media.Brushes.White;
        }

        // example read button

        private void ReadText(object sender, RoutedEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            string path = "./TapDoc/voicemp3/" + currentLevel + ".mp3";
            Uri uri = new Uri(path,UriKind.Relative);
            mplayer.Open(uri);
            mplayer.Play();

        }

        //kid read button
        private enum State
        {
            Accepting = 1,
            Off = 2,
        }

        private State RecogState = State.Off;
        private SpeechRecognitionEngine srecog;
        private SpeechSynthesizer synth = null;

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeRecognizerSynthesizer();

            if (SelectInputDevice())
            {
                LoadDictationGrammar();
            }
        }

        private void InitializeRecognizerSynthesizer()
        {
            var selectedRecognizer = (from o in SpeechRecognitionEngine.InstalledRecognizers()
                                      where o.Culture.Equals(Thread.CurrentThread.CurrentCulture)
                                      select o).FirstOrDefault();
            srecog = new SpeechRecognitionEngine(selectedRecognizer);
            srecog.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            
            synth = new SpeechSynthesizer();
        }
        
        private bool SelectInputDevice()
        {
            bool proceedLoading = true;
            if (IsOscompatible())
            {
                try
                {
                    srecog.SetInputToDefaultAudioDevice();
                }
                catch
                {
                    proceedLoading = false;
                }
            }
            else
                ThreadPool.QueueUserWorkItem(InitSpeechRecogniser);
            return proceedLoading;
        }

        private bool IsOscompatible()
        {
            OperatingSystem osInfo = Environment.OSVersion;
            if (osInfo.Version > new Version("6.0"))
                return true;
            else
                return false;
        }

        private void InitSpeechRecogniser(object o)
        {
            srecog.SetInputToDefaultAudioDevice();
        }

        private void LoadDictationGrammar()
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(new Choices("End Dictate"));
            Grammar commandGrammar = new Grammar(grammarBuilder);
            commandGrammar.Name = "main command grammar";
            srecog.LoadGrammar(commandGrammar);

            DictationGrammar dictationGrammar = new DictationGrammar();
            dictationGrammar.Name = "dictation";
            srecog.LoadGrammar(dictationGrammar);
        }

        // change stage button
        private void KidRead_Click(object sender, RoutedEventArgs e)
        {
            switch (RecogState)
            {
                case State.Off:
                    RecogState = State.Accepting;
                    picName.Foreground = System.Windows.Media.Brushes.White;
                    srecog.RecognizeAsync(RecognizeMode.Multiple);
                    read_Result = "";
                    micImg.Source = new BitmapImage(new Uri("/images/readOff.png", UriKind.Relative));
                    break;
                case State.Accepting:
                    RecogState = State.Off;
                    srecog.RecognizeAsyncStop();
                    micImg.Source = new BitmapImage(new Uri("/images/readOn.png",UriKind.Relative));
                    break;
            }
        }
        // recognize words
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            if (RecogState == State.Off)
                return;
            picName.Foreground = System.Windows.Media.Brushes.Red;
            float accuracy = (float)e.Result.Confidence;
            read_Result = e.Result.Text;
        }

        private void stayStage (object sender, RoutedEventArgs e)
        {
            goodResult.Visibility = Visibility.Collapsed;
            badResult.Visibility = Visibility.Collapsed;
            picName.Foreground = System.Windows.Media.Brushes.White;
            mainScreen.Opacity = 1;

        }

        private void Check_Click (object sender, RoutedEventArgs e)
        {
            if (read_Result == picName.Text)
            {
                mainScreen.Opacity = 0.2;
                layoutScreen.Background = System.Windows.Media.Brushes.Black;
                goodResult.Visibility = Visibility.Visible;
                MediaPlayer mp = new MediaPlayer();
                mp.Open(new Uri("./TapDoc/voicemp3/congrats.mp3",UriKind.Relative));
                mp.Play();

            }
            else
            {
                mainScreen.Opacity = 0.2;
                layoutScreen.Background = System.Windows.Media.Brushes.Black;
                badResult.Visibility = Visibility.Visible;
                MediaPlayer mp = new MediaPlayer();
                mp.Open(new Uri("./TapDoc/voicemp3/ohno.mp3", UriKind.Relative));
                mp.Play();
            }
        }


    }
}
