using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Services.Files;

namespace TotalCommander.Modules
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileService>().To<FileService>();
        }
    }
}
