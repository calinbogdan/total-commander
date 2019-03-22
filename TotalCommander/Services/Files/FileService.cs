using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services.Files
{
    public class FileService : IFileService
    {

        public IEnumerable<FileSystemInfo> GetFileSystemEntries(string path)
        {
            var fileSystemEntries = new List<FileSystemInfo>();
            fileSystemEntries.AddRange(Directory.GetDirectories(path).Select(directory => new DirectoryInfo(directory)));
            fileSystemEntries.AddRange(Directory.GetFiles(path).Select(file => new FileInfo(file)));
            return fileSystemEntries;
        }
    }
}
