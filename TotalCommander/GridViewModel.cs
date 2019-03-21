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
    public class DriveData
    {
        public string Name { get; set; }
    }

    public class GridViewModel : ViewModelBase
    {
        private readonly IFileService _fileService;
        private string _path = "";

        public ChangePathCommand ChangePathCommand
        {
            get => new ChangePathCommand(ChangePath);
        }

        public DriveInfo SelectedDrive { get;set; }
        public ObservableCollection<DriveData> Drives { get; private set; }

        public ObservableCollection<FileInfo> Files { get; private set; }

        public string Path {
            get => _path;
            set {
                _path = value;
                UpdateFiles(_path);
                OnPropertyChanged("Path");
            }
        }

        public GridViewModel()
        {
            _fileService = new FileService();
            Files = new ObservableCollection<FileInfo>();
            Drives = new ObservableCollection<DriveData>();

            // init combo box items
            // DriveInfo.GetDrives().ToList().ForEach(Drives.Add);

            Enumerable.Range(5, 15).ToList().ForEach(index => Drives.Add(new DriveData() { Name = $"Drive #{index}" }));

            OnPropertyChanged("Drives");
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
