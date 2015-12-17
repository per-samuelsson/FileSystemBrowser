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

        public int ItemCount {
            get {
                return Db.SQL<int>("SELECT COUNT(*) FROM FileSystemEntry WHERE Root = ?", this).First;
            }
        }
    }
}