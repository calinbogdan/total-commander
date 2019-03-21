using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Services.Files;

namespace TotalCommander
{
    public class GridViewModel : ViewModelBase
    {
        private readonly IFileService _fileService;
        private string _path = "";

        public ChangePathCommand ChangePathCommand
        {
            get => new ChangePathCommand(ChangePath);
        }

        public ObservableCollection<FileInfo> Files { get; private set; }

        public string Path {
            get => _path;
            set {
                _path = value;
                UpdateFiles(_path);
                OnPropertyChanged("Files");
            }
        }

        public GridViewModel()
        {
            _fileService = new FileService();
            Files = new ObservableCollection<FileInfo>();
        }

        private void UpdateFiles(string newPath)
        {
            Files.Clear();
            _fileService.GetFiles(newPath).ToList().ForEach(Files.Add);
            OnPropertyChanged("Files");
        }

        private void ChangePath()
        {
            Path = Directory.GetCurrentDirectory();
        }
    }
}
