using System;
using System.Windows.Input;

namespace TotalCommander
{
    public class DeleteCommand : ICommand
    {
        private readonly Action<object> _deleteAction;

        public DeleteCommand(Action<object> action) => _deleteAction = action;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _deleteAction(parameter);
        }
    }
}
