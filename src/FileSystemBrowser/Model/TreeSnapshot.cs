using Starcounter;
using System;

namespace FileSystemBrowser.Model {

    [Database] public class TreeSnapshot {
        public DateTime Created;
        public string Path;

        public QueryResultRows<FileSystemEntry> Items {
            get {
                return Db.SQL<FileSystemEntry>("SELECT e FROM FileSystemEntry e WHERE Root = ?", this);
            }
        }

        public long ItemCount {
            get {
                return Db.SlowSQL<long>("SELECT COUNT(*) FROM FileSystemEntry WHERE Root = ?", this).First;
            }
        }
    }
}