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
        public IEnumerable<FileInfo> GetFiles(string path)
        {
            return Directory.GetFiles(path, "*").Select(file => new FileInfo(file));
        }
    }
}
