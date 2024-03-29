﻿using System;
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
    /// Interaction logic for GoodResult.xaml
    /// </summary>
    public partial class GoodResult : System.Windows.Controls.UserControl
    {
        public GoodResult()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ReplayProperty =
            DependencyProperty.Register("Replay", typeof(ICommand), typeof(GoodResult), new UIPropertyMetadata());

        public static readonly DependencyProperty NextProperty =
            DependencyProperty.Register("Next", typeof(ICommand), typeof(GoodResult), new UIPropertyMetadata());

        public ICommand Replay
        {
            get { return (ICommand)GetValue(ReplayProperty); }
            set { SetValue(ReplayProperty, value); }
        }
        public ICommand Next
        {
            get { return (ICommand)GetValue(NextProperty); }
            set { SetValue(NextProperty, value); }
        }
    }
}
