﻿using LearnWithPenguin.Utils;
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

namespace LearnWithPenguin.View
{
    /// <summary>
    /// Interaction logic for OnBoardingView.xaml
    /// </summary>
    public partial class OnBoardingView : System.Windows.Controls.Page
    {
        public OnBoardingView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Firestore.db == null)
                Firestore.initFireStore();
        }
    }
}
