using System.Windows;

namespace DirScanNet.ViewModels
{
    abstract class WindowVM : VMBase
    {
        WindowState windowState;
        public WindowState WindowState
        {
            get => windowState;
            set => Set(ref windowState, value);
        }

        double width;
        public double Width
        {
            get => width;
            set => Set(ref width, value);
        }

        double height;
        public double Height
        {
            get => height;
            set => Set(ref height, value);
        }

        double left;
        public double Left
        {
            get => left;
            set => Set(ref left, value);
        }

        double top;
        public double Top
        {
            get => top;
            set => Set(ref top, value);
        }

        string title;
        public string Title
        {
            get => title;
            protected set => Set(ref title, value);
        }
    }
}