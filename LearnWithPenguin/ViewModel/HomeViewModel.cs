﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LearnWithPenguin.UserControl;
using LearnWithPenguin.UserControls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnWithPenguin.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        protected BaseViewModel _navigatetoRead;
        protected BaseViewModel _navigatetoWrite;
        protected BaseViewModel _navigatetoPuzzle;
        protected BaseViewModel _navigatetoEvaluate;

     

        public BaseViewModel NavigatetoRead
        {
            get
            {
                return _navigatetoRead;
            }
            set
            {
                _navigatetoRead = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel NavigatetoWrite
        {
            get
            {
                return _navigatetoWrite;
            }
            set
            {
                _navigatetoWrite= value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel NavigatetoEvaluate
        {
            get
            {
                return _navigatetoEvaluate;
            }
            set
            {
                _navigatetoEvaluate = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel NavigatetoPuzzle
        {
            get
            {
                return _navigatetoPuzzle;
            }
            set
            {
                _navigatetoPuzzle = value;
                OnPropertyChanged();
            }
        }


    }
}

