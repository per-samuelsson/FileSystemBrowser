using Starcounter;
using System;

namespace FileSystemBrowser.Model {

    [Database] public class TreeRoot {
        public DateTime Created;
        public string Path;
    }
}