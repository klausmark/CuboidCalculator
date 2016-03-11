using System;
using System.Windows.Input;

namespace VP.CuboidCalculator.ViewModels
{
    public class SimpleDelegateCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged;

        public SimpleDelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public SimpleDelegateCommand(Action execute) : this(execute, () => true )
        {
            
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}