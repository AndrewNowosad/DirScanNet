﻿using System.Collections.Generic;
using System.IO;

namespace DirScanNet.Models
{
    abstract class FSItem
    {
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
            Name = Path.GetFileName(path);

            ItemsCache[path] = this;
        }
    }
}