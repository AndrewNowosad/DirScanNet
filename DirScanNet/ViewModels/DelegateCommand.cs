using System;
using System.Windows.Input;

namespace DirScanNet.ViewModels
{
    class DelegateCommand : ICommand
    {
        protected readonly Predicate<object> _canExecute;
        protected readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new NullReferenceException();
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}