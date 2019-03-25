using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TotalCommander.Services.Files;

namespace TotalCommander
{
    public class MainViewModel : ViewModelBase
    {
        public GridViewModel LeftGridViewModel { get; private set; }
        public GridViewModel RightGridViewModel { get; private set; }

        public DeleteCommand DeleteCommand
        {
            get => new DeleteCommand(file => DeleteFile(file));
        }

        public MainViewModel()
        {
            LeftGridViewModel = new GridViewModel();
            RightGridViewModel = new GridViewModel();
        }

        private void DeleteFile(object file)
        {
            MessageBox.Show($"{file.ToString()} deleted");
        }
    }
}
