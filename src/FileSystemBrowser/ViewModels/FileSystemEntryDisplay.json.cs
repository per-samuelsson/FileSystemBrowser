using Starcounter;
using FileSystemBrowser.Model;

namespace FileSystemBrowser.ViewModels {

    partial class FileSystemEntryDisplay : Partial, IBound<FileSystemEntry> {
        public string UriBinding {
            get {
                var t = this.Data;
                return string.Format("/filesystembrowser/entries/{0}", t.GetObjectID());
            }
        }
    }

    [FileSystemEntryDisplay_json.ParentEntry]
    partial class FileSystemEntryParentDisplay : Partial, IBound<FileSystemEntry> {
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