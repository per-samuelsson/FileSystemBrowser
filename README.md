# FileSystemBrowser
Sample Starcounter application illustration reusage of parials.

### How it works
Every time it run, it takes a snapshot of the file system tree, starting from a certain root directory. You specify the root directory as an argument, like `star FileSystemBrowser c:\capture\this\tree`. If nothing is specified, it capture the current working directory.

### Try it
Open the solution. Build it. Then run it.

Now go to `localhost:8181\sql` and do this

```sql
SELECT * FROM FileSystemBrowser.Model.FileSystemEntry fse WHERE fse.Root.Path = 'C:\Users\Per\Git\per-samuelsson\FileSystemBrowser\src\FileSystemBrowser'
```
