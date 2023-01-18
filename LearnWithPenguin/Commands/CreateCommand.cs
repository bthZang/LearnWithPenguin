using LearnWithPenguin.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LearnWithPenguin.Commands
{
        public delegate ICommand CreateCommand<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;
}
