using System;
using System.Collections.Generic;
using System.IO;

namespace DirScanNet.Models
{
    abstract class FSItem
    {
        static public readonly string ComputerRootAlias = "<Компьютер>";

        static protected Dictionary<string, FSItem> ItemsCache { get; private set; }
            = new Dictionary<string, FSItem>();

        static public void ResetCache()
        {
            ItemsCache = new Dictionary<string, FSItem>();
        }

        public string Name { get; protected set; }
        public string FullPhysicalPath { get; protected set; }
        public long Weight { get; protected set; }

        protected FSItem(string path)
        {
            FullPhysicalPath = path;
            if (path == ComputerRootAlias)
                Name = ComputerRootAlias;
            else
            {
                Name = Path.GetFileName(path);
                if (Name == "") Name = FullPhysicalPath;
            }

            ItemsCache[path] = this;
        }

        public Folder GetParent()
        {
            if (FullPhysicalPath == ComputerRootAlias)
                throw new NotSupportedException($"Операция не поддерживается для {ComputerRootAlias}");
            string parentPath = Path.GetDirectoryName(FullPhysicalPath);
            if (parentPath == null)
                return ComputerRoot.GetComputerRoot();
            return Folder.GetFolder(parentPath);
        }
    }
}