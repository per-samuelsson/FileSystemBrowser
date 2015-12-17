﻿
using Starcounter;

namespace FileSystemBrowser.Model {

    [Database] public abstract class FileSystemEntry {
        public TreeRoot Root;
        public FileSystemEntry ParentEntry;
        public string Path;

        public string Name {
            get {
                return System.IO.Path.GetFileName(Path);
            }
        }
    }
}