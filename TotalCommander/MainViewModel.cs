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

        public FileSystemInfo SelectedFile { get; set; }

        public DeleteCommand DeleteCommand
        {
            get => new DeleteCommand(() => DeleteFile(SelectedFile));
        }

        public MainViewModel()
        {
            LeftGridViewModel = new GridViewModel();
            RightGridViewModel = new GridViewModel();
        }

        private void DeleteFile(object fileData)
        {
            if (fileData is DirectoryInfo directory)
            {
                if (directory.EnumerateFileSystemInfos().Count() > 0)
                {
                    var dialogResult = MessageBox.Show("This directory is not empty. Do you still want to delete it?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    directory.Delete(recursive: dialogResult == MessageBoxResult.Yes);
                }
            }
            else if (fileData is FileInfo file)
            {
                file.Delete();
            }

            LeftGridViewModel.CurrentPath = LeftGridViewModel.CurrentPath;
            RightGridViewModel.CurrentPath = RightGridViewModel.CurrentPath;
        }
    }
}
