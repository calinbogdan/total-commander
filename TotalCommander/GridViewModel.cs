﻿using System;
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
        private DriveInfo _selectedDrive;

        public ChangePathCommand ChangePathCommand
        {
            get => new ChangePathCommand(newPath => CurrentPath = newPath);
        }

        public DriveInfo SelectedDrive 
        {
            get => _selectedDrive;
            set {
                _selectedDrive = value;
                OnPropertyChanged("SelectedDrive");
                CurrentPath = value.RootDirectory.FullName;
            }
        }

        public ObservableCollection<DriveInfo> Drives { get; private set; }

        public ObservableCollection<FileSystemInfo> Files { get; private set; }

        public string CurrentPath {
            get => _path;
            set {
                _path = value;
                UpdateFiles(_path);
                OnPropertyChanged("CurrentPath");
            }
        }

        public GridViewModel()
        {
            _fileService = new FileService();
            Files = new ObservableCollection<FileSystemInfo>();
            Drives = new ObservableCollection<DriveInfo>();

            // init combo box items
            DriveInfo.GetDrives().ToList().ForEach(Drives.Add);
            OnPropertyChanged("Drives");
        }

        private void UpdateFiles(string newPath)
        {
            Files.Clear();
            _fileService.GetFileSystemEntries(newPath).ToList().ForEach(Files.Add);
            OnPropertyChanged("Files");
        }
    }
}
