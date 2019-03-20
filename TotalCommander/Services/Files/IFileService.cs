using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services.Files
{
    interface IFileService
    {
        IEnumerable<FileInfo> GetFiles(string path);
    }
}
