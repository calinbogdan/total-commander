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
    class GridViewModel : ViewModelBase
    {
        private readonly IFileService _fileService;

        public GridViewModel(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        public ObservableCollection<FileInfo> Files { get; private set; }
        public string Path { get; set; }
    }
}
