using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
using FileSystemBrowser.Model;
using System.IO;

namespace FileSystemBrowser {

    public class TreeBuilder {
        public string RootPath;
        public DateTime Time;
        public bool IncludeFiles = true;

        public static TreeBuilder From(string rootPath) {
            return new TreeBuilder() {
                RootPath = rootPath,
                Time = DateTime.Now
            };
        }

        public void Build() {
            Db.Transact(() => {
                var root = new TreeRoot() {
                    Path = RootPath,
                    Created = Time
                };
                BuildTree(root, null, root.Path);
            });
        }

        void BuildTree(TreeRoot root, DirectoryEntry parent, string fromDirectory) {
            var entry = new DirectoryEntry() {
                Root = root,
                ParentEntry = parent,
                Path = fromDirectory
            };

            var entries = Directory.GetFileSystemEntries(fromDirectory);
            foreach (var child in entries) {
                if (Directory.Exists(child)) {
                    BuildTree(root, entry, child);
                }
                else if (IncludeFiles) {
                    new FileEntry() {
                        Path = child,
                        Root = root,
                        ParentEntry = entry
                    };
                }
            }
        }
    }
}
