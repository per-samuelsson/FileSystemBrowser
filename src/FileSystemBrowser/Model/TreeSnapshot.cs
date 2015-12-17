using Starcounter;
using System;

namespace FileSystemBrowser.Model {

    [Database] public class TreeSnapshot {
        public DateTime Created;
        public string Path;
        public int Items {
            get {
                return Db.SQL<int>("SELECT COUNT(*) FROM FileSystemEntry WHERE Root = ?", this).First;
            }
        }
    }
}