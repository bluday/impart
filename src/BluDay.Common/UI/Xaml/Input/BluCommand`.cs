using System;

namespace BluDay.Common.UI.Xaml.Input
{
    public class BluCommand<T> : System.Windows.Input.ICommand
    {
        private readonly Action<T> _execute;

        private readonly Predicate<T> _canExecute;

        public event EventHandler CanExecuteChanged;

        public BluCommand(Action<T> execute) : this(execute, null) { }

        public BluCommand(Action<T> execute, Predicate<T> canExecute)
        {
            BluValidator.NotNull(execute, nameof(execute));

            _execute    = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}