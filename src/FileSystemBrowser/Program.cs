
using System;
using Starcounter;
using System.IO;

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
        }
    }
}