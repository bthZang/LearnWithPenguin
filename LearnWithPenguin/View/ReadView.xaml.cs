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
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        public int currentLevel = 1;
        public int currentIndex = 0;
        private Storyboard myStoryboard;

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
            lessonName.Text = "Bài " + currentLevel;

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

        // example read button

        private void ReadText(object sender, RoutedEventArgs e)
        {
            string path = "D:\\School\\testWPFfunc\\FullRecord\\" + currentLevel + ".wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
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
            srecog.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(recognizer_SpeechHypothesized);
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
                    KidRead.Content = "Stop";
                    srecog.RecognizeAsync(RecognizeMode.Multiple);
                    break;
                case State.Accepting:
                    RecogState = State.Off;
                    KidRead.Content = "Start";
                    srecog.RecognizeAsyncStop();
                    picName.Foreground = System.Windows.Media.Brushes.White;
                    break;
            }
        }
        // recognize words
        private int Hypothesized = 0;
        private void recognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Hypothesized++;
            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, picName.Text);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(picName.Text));
            picName.Loaded += new RoutedEventHandler(picNameloaded);
            

        }
        private void picNameloaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            if (RecogState == State.Off)
                return;
            float accuracy = (float)e.Result.Confidence;
            string phrase = e.Result.Text;
        }


    }
}
