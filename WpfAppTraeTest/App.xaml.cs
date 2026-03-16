using System.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using WpfAppTraeTest.Views;

namespace WpfAppTraeTest
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return new LoginView();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册视图用于导航
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<CameraStatusView>();
            containerRegistry.RegisterForNavigation<CalibrationView>();
            containerRegistry.RegisterForNavigation<ParameterSettingsView>();
        }
    }
}