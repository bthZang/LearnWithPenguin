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

namespace LearnWithPenguin.UserControls
{
    /// <summary>
    /// Interaction logic for GRforGame.xaml
    /// </summary>
    public partial class GRforGame : System.Windows.Controls.UserControl
    {
        public GRforGame()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ReplayGameProperty =
    DependencyProperty.Register("ReplayGame", typeof(ICommand), typeof(GRforGame), new UIPropertyMetadata());

        public static readonly DependencyProperty NextGameProperty =
            DependencyProperty.Register("NextGame", typeof(ICommand), typeof(GRforGame), new UIPropertyMetadata());

        public ICommand ReplayGame
        {
            get { return (ICommand)GetValue(ReplayGameProperty); }
            set { SetValue(ReplayGameProperty, value); }
        }
        public ICommand NextGame
        {
            get { return (ICommand)GetValue(NextGameProperty); }
            set { SetValue(NextGameProperty, value); }
        }
    }
}
