using System.Windows;

namespace DirScanNet.ViewModels
{
    abstract class WindowVM : VMBase
    {
        WindowState windowState;
        public WindowState WindowState
        {
            get
            {
                return windowState;
            }
            set
            {
                Set(ref windowState, value);
            }
        }

        double width;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                Set(ref width, value);
            }
        }

        double height;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                Set(ref height, value);
            }
        }

        double left;
        public double Left
        {
            get
            {
                return left;
            }
            set
            {
                Set(ref left, value);
            }
        }

        double top;
        public double Top
        {
            get
            {
                return top;
            }
            set
            {
                Set(ref top, value);
            }
        }

        string title;
        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                Set(ref title, value);
            }
        }
    }
}