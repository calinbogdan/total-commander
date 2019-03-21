using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TotalCommander
{
    public class ChangePathCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<string> _changePathAction;

        public ChangePathCommand(Action<string> changePathAction)
        {
            _changePathAction = changePathAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var fileInfo = parameter as FileInfo;
            var fullName = fileInfo.FullName;

            _changePathAction(fullName);
        }
    }
}
