using UI.Services.Factory;

namespace UI.Services.Windows
{
    class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowId windowId)
        {
            switch (windowId) 
            {
                case WindowId.SomeUI:
                    _uiFactory.CreateSomeUI();
                    break;
            }
        }
    }
}