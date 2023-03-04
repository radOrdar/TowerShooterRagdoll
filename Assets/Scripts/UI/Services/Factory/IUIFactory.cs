using Services;

namespace UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateSomeUI();
        void CreateUIRoot();
    }
}