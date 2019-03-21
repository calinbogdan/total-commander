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
        private string _path;

        public GridViewModel(IFileService fileService)
        {
            _fileService = fileService;
            PropertyChanged += GridViewModel_PropertyChanged;
            Path = Directory.GetCurrentDirectory();
        }

        private void GridViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var senderz = sender;
        }

        public ObservableCollection<FileInfo> Files { get; private set; }
        public string Path {
            get => _path;
            set {
                _path = value;
                OnPropertyChanged("Files");
            }
        }
    }
}
