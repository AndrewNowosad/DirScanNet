using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirScanNet.Models
{
    class Folder : FSItem
    {
        static public Folder GetFolder(string path)
        {
            if (ItemsCache.ContainsKey(path)) return (Folder)ItemsCache[path];
            return new Folder(path);
        }

        protected Folder(string path) : base(path)
        {
            RescanPath();
        }

        protected List<FSItem> childElements;
        public IReadOnlyList<FSItem> ChildElements => childElements;

        protected virtual void RescanPath()
        {
            childElements = new List<FSItem>();
            IEnumerable<string> dirs;
            try
            {
                dirs = Directory.EnumerateDirectories(FullPhysicalPath);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            foreach (var dir in dirs)
                childElements.Add(GetFolder(dir));
            foreach (var file in Directory.EnumerateFiles(FullPhysicalPath))
                childElements.Add(File.GetFile(file));
            Weight = childElements.Sum(item => item.Weight);
        }

        public override string ToString()
        {
            if (Name == "") return $"Drive: {FullPhysicalPath}";
            return $"Folder: {Name}";
        }
    }
}