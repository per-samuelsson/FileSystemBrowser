# FileSystemBrowser
Sample Starcounter application illustration reusage of parials.

### How it works
The FileSystemBrowser take snapshots of the file system tree, starting from a certain root directory. You specify the root directory as an argument, like `star FileSystemBrowser c:\capture\this\tree`. Specify `.` to capture the current working directory.

### Try it
Clone it. Open the solution. Build it. Then run it, giving it a path.

Then either browse to `localhost:8080\filesystemwatcher` to see the latest snapshot, or go to `localhost:8181\sql` and do this

```sql
SELECT * FROM FileSystemBrowser.Model.FileSystemEntry fse WHERE fse.Root.Path = 'C:\path\to\where\you\cloned\it\FileSystemBrowser\src\FileSystemBrowser'
```
