using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TotalCommander
{
    public class DeleteCommand : ICommand
    {
        private readonly Action _deleteAction;

        public DeleteCommand(Action action) => _deleteAction = action;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {                                
            _deleteAction();
        }
    }
}
