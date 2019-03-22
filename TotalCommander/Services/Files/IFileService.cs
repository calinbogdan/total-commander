using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services.Files
{
    public interface IFileService
    {
        IEnumerable<FileSystemInfo> GetFileSystemEntries(string path);
    }
}
