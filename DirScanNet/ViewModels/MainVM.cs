﻿using DirScanNet.Models;
using DirScanNet.SettingsHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirScanNet.ViewModels
{
    class MainVM : WindowVM
    {
        string currentPath;
        public string CurrentPath
        {
            get => currentPath;
            set => Set(ref currentPath, value);
        }

        Folder currentFolder;
        public Folder CurrentFolder
        {
            get => currentFolder;
            set
            {
                Set(ref currentFolder, value);
                NotifyPropertyChanged(nameof(Items));
                NotifyPropertyChanged(nameof(MaxWeight));
            }
        }

        public IEnumerable<FSItem> Items
        {
            get => CurrentFolder?.ChildElements.OrderByDescending(item => item.Weight);
        }

        public long? MaxWeight => Items?.FirstOrDefault()?.Weight;

        bool isProcess;
        public bool IsProcess
        {
            get => isProcess;
            protected set => Set(ref isProcess, value);
        }

        DelegateCommand scanFolderCommand;
        public ICommand ScanFolderCommand
        {
            get
            {
                if (scanFolderCommand == null)
                    scanFolderCommand = new DelegateCommand(async o => await ScanFolderAsync());
                return scanFolderCommand;
            }
        }

        DelegateCommand openFolderCommand;
        public ICommand OpenFolderCommand
        {
            get
            {
                if (openFolderCommand == null)
                    openFolderCommand = new DelegateCommand(o => OpenFolder((FSItem)o));
                return openFolderCommand;
            }
        }

        DelegateCommand upLevelCommand;
        public ICommand UpLevelCommand
        {
            get
            {
                if (upLevelCommand == null)
                    upLevelCommand = new DelegateCommand(o => GoToUpLevel());
                return upLevelCommand;
            }
        }

        DelegateCommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegateCommand(o => SaveSettings());
                return saveCommand;
            }
        }

        protected async Task ScanFolderAsync()
        {
            IsProcess = true;
            CurrentFolder = await new FSScanner().GetFolderAsync(CurrentPath);
            IsProcess = false;
        }

        protected void OpenFolder(FSItem item)
        {
            var folder = item as Folder;
            if (folder == null) return;
            CurrentFolder = folder;
            CurrentPath = CurrentFolder.FullPhysicalPath;
        }

        protected void GoToUpLevel()
        {
            CurrentPath = Path.GetDirectoryName(CurrentPath);
        }

        public MainVM()
        {
            Title = "DirScanNet 1.0.0";
            LoadSettings();
        }

        void LoadSettings()
        {
            var settings = Settings.Instance.MainWindowSettings;
            WindowState = settings.WindowState;
            Width = settings.Width;
            Height = settings.Height;
            Left = settings.Left;
            Top = settings.Top;
            CurrentPath = settings.CurrentPath;
        }

        void SaveSettings()
        {
            var settings = Settings.Instance.MainWindowSettings;
            settings.WindowState = WindowState;
            settings.Width = Width;
            settings.Height = Height;
            settings.Left = Left;
            settings.Top = Top;
            settings.CurrentPath = CurrentPath;
            Settings.Save();
        }
    }
}