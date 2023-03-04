using System;
using UI.Services.Windows;
using UI.Windows;

namespace StaticData.WIndows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Template;
    }
}