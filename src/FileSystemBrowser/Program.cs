
using System;
using Starcounter;
using System.IO;
using FileSystemBrowser.Model;
using FileSystemBrowser.ViewModels;

namespace FileSystemBrowser {

    // Example query to use in web admin to see the tree snapshot based on a
    // given root directory:
    //
    // SELECT * FROM FileSystemBrowser.Model.FileSystemEntry fse WHERE fse.Root.Path = 'C:\Users\Per\Git\per-samuelsson\FileSystemBrowser\src\FileSystemBrowser'

    class Program {

        static void Usage() {
            Console.WriteLine("star FileSystemBrowser [rootDirectory]");
        }

        static void Main(string[] args) {
            var given = args.Length > 0 ? args[0] : null;
            var rootDir = given ?? Application.Current.WorkingDirectory;
            if (!Directory.Exists(rootDir)) {
                Usage();
                return;
            }

            Console.WriteLine("Creating new tree from {0}", rootDir);
            TreeBuilder.From(rootDir).Build();

            Handle.GET("/filesystembrowser/entries/{?}", (string id) => {
                var oid = DbHelper.Base64DecodeObjectID(id);
                var entry = DbHelper.FromID(oid) as FileSystemEntry;

                var display = new FileSystemEntryDisplay();
                display.Data = entry;
                display.Html = "/FileSystemBrowser/FileSystemEntryDisplay.html";
                return display;
            });

            Handle.GET("/filesystembrowser", () => {
                var root = Db.SQL<TreeRoot>("SELECT r FROM TreeRoot r ORDER BY r.Created DESC").First;
                
                var list = new FileSystemEntryList();
                list.Entries = Db.SQL<FileSystemEntry>("SELECT e FROM FileSystemEntry e WHERE e.Root = ?", root);
                list.Html = "/FileSystemBrowser/FileSystemEntryList.html";

                return list;
            });
        }
    }
}