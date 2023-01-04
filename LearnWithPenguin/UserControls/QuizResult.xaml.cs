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
    /// Interaction logic for QuizResult.xaml
    /// </summary>
    public partial class QuizResult : System.Windows.Controls.UserControl
    {
        public QuizResult()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty NextProperty =
          DependencyProperty.Register("NextLevel", typeof(ICommand), typeof(QuizResult), new UIPropertyMetadata());

        public ICommand NextLevel
        {
            get { return (ICommand)GetValue(NextProperty); }
            set { SetValue(NextProperty, value); }
        }
    }
}
