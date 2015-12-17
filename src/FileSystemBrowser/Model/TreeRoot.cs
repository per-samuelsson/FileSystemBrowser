using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace FileSystemBrowser.Model {

    [Database] public class TreeRoot {
        public DateTime Created;
        public string Path;
    }
}