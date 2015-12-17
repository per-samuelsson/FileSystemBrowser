using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace FileSystemBrowser.Model {

    public class DirectoryEntry : FileSystemEntry {

        public QueryResultRows<FileSystemEntry> Children {
            get {
                return Db.SQL<FileSystemEntry>(
                    "SELECT fse FROM FileSystemEntry fse WHERE fse.ParentEntry = ?", this);
            }
        }
    }
}