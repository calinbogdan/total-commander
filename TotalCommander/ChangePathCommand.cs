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
    public class ChangeDirectoryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<string> _changePathAction;

        public ChangeDirectoryCommand(Action<string> changePathAction)
        {
            _changePathAction = changePathAction;
        }

        public bool CanExecute(object parameter)
        {
            return (parameter.GetType() == typeof(DirectoryInfo));
        }

        public void Execute(object parameter)
        {
            var fileInfo = parameter as DirectoryInfo;
            var fullName = fileInfo.FullName;

            _changePathAction(fullName);
        }
    }
}
