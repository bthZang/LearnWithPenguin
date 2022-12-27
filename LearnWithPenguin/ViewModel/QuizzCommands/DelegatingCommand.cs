//using System;
//using System.Windows.Input;

//namespace LearnWithPenguin.ViewModel.QuizzCommands
//{
//    class DelegatingCommand : ICommand
//    {
//        private readonly Action<object> action;
//        private readonly Func<object, bool> canExecute;

//        public DelegatingCommand(Action action)
//           : this((o) => action())
//        { }
//        public DelegatingCommand(Action<object> action)
//            : this(action, (o) => true)
//        { }


//        public DelegatingCommand(Action<object> actionArg, Func<object, bool> canExecuteArg)
//        {
//            action = actionArg;
//            this.canExecute = canExecuteArg;
//        }
//        public bool CanExecute(object parameter)
//        {
//            return canExecute(parameter);
//        }
//        public void Execute(object parameter)
//        {
//            this.action(parameter);
//        }
//        public event EventHandler CanExecuteChanged
//        {
//            add { CommandManager.RequerySuggested += value; }
//            remove { CommandManager.RequerySuggested -= value; }
//        }
//    }
//}
