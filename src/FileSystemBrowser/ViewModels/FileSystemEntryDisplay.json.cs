using Starcounter;
using FileSystemBrowser.Model;

namespace FileSystemBrowser.ViewModels {

    partial class FileSystemEntryDisplay : Page, IBound<FileSystemEntry> {
        public string UriBinding {
            get {
                var t = this.Data;
                return string.Format("/filesystembrowser/entries/{0}", t.GetObjectID());
            }
        }

        protected override void OnData() {
            base.OnData();
            IsDirectory = Data is DirectoryEntry;
            SnapshotUri = string.Format("/filesystembrowser/snapshots/{0}", Data.Root.GetObjectID());
        }
    }

    [FileSystemEntryDisplay_json.ParentEntry]
    partial class FileSystemEntryParentDisplay : Page, IBound<FileSystemEntry> {
        public string UriBinding {
            get {
                var t = this.Parent.Data as FileSystemEntry;
                t = t.ParentEntry;
                if (t == null) {
                    return "";
                }

                return string.Format("/filesystembrowser/entries/{0}", t.GetObjectID());
            }
        }
    }
}