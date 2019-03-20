using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Services.Files;

namespace TotalCommander
{
    class MainViewModel : ViewModelBase
    {
        public GridViewModel LeftGridViewModel { get; set; }
        public GridViewModel RightGridViewModel { get; set; }
    }
}
