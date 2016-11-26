using System;
using System.IO;

namespace Delete
{
    public class FileWatcher
    {
        private FileSystemWatcher _watcher;
        const string dir = "C:\\Users\\cberman\\AppData\\Local\\Tecnomatix";

        public FileWatcher(string path)
        {
            _watcher = new FileSystemWatcher(path);
            _watcher.IncludeSubdirectories = true;
            _watcher.Filter = "*.*";
            _watcher.Changed += _watcher_Changed;
            _watcher.Renamed += _watcher_Renamed;
            _watcher.EnableRaisingEvents = true;
            
        }
        public FileWatcher()
        {
            _watcher = new FileSystemWatcher(dir);
            _watcher.IncludeSubdirectories = true;
            _watcher.Filter = "*.*";
            _watcher.Changed += _watcher_Changed;
            _watcher.Renamed += _watcher_Renamed;
            _watcher.Error += _watcher_Error;
            _watcher.Created += _watcher_Created;
            _watcher.EnableRaisingEvents = true;
        }

        void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("{0} File Created: " + e.FullPath + " " + e.ChangeType, DateTime.Now.TimeOfDay);
        }

        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
            _watcher = null;
        }
        void _watcher_Error(object sender, ErrorEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("FileError: {0} ", e.GetException() );
        }

        void _watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (e.FullPath.Contains("Google"))
                return;

            // Specify what is done when a file is renamed.
            Console.WriteLine("{2} File: {0} renamed to {1}", e.OldFullPath, e.FullPath,DateTime.Now.TimeOfDay);
        }

        void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.Contains("Google"))
                return;
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("{0} File: {1} {2}",DateTime.Now.TimeOfDay, e.FullPath,e.ChangeType);
        }
    }
}
