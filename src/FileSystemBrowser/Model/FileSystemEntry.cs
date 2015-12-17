using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace FileSystemBrowser.Model {

    [Database] public abstract class FileSystemEntry {
        public TreeRoot Root;
        public FileSystemEntry ParentEntry;
        public string Path;
    }
}
