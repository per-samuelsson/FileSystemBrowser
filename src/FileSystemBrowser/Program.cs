
using FileSystemBrowser.Model;
using FileSystemBrowser.ViewModels;
using Starcounter;
using System;
using System.IO;

namespace FileSystemBrowser {
    
    class Program {

        static void Usage() {
            Console.WriteLine("star FileSystemBrowser [rootDirectory]");
        }

        static void Main(string[] args) {
            if (args.Length > 0) {
                var rootDir = Path.GetFullPath(Path.Combine(Application.Current.WorkingDirectory, args[0]));
                if (!Directory.Exists(rootDir)) {
                    Usage();
                    return;
                }

                Console.WriteLine("Creating new tree from {0}", rootDir);
                TreeBuilder.From(rootDir).Build();
            }

            Handle.GET("/filesystembrowser", () => {
                return Self.GET("/filesystembrowser/latest");
            });

            Handle.GET("/filesystembrowser/latest", () => {
                var root = Db.SQL<TreeSnapshot>("SELECT r FROM TreeSnapshot r ORDER BY r.Created DESC").First;
                if (root == null) {
                    return "No snapshots found to browse. Please create at least one";
                }

                return Self.GET(string.Format("/filesystembrowser/snapshots/{0}", root.GetObjectID()));
            });

            Handle.GET("/filesystembrowser/snapshots/{?}", (string id) => {
                var oid = DbHelper.Base64DecodeObjectID(id);
                var snapshot = DbHelper.FromID(oid) as TreeSnapshot;

                if (snapshot == null) {
                    return 404;
                }

                var list = new FileSystemEntryList();
                list.Entries = snapshot.Items;
                list.Html = "/FileSystemBrowser/FileSystemEntryList.html";

                return list;
            });

            Handle.GET("/filesystembrowser/entries/{?}", (string id) => {
                var oid = DbHelper.Base64DecodeObjectID(id);
                var entry = DbHelper.FromID(oid) as FileSystemEntry;

                var display = new FileSystemEntryDisplay();
                display.Data = entry;
                display.Html = "/FileSystemBrowser/FileSystemEntryDisplay.html";

                return display;
            });
        }
    }
}