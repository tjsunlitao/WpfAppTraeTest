using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.DryIoc;
using Prism.Regions;
using WpfAppTraeTest.Views;

namespace WpfAppTraeTest.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IRegionManager _regionManager;

        [ObservableProperty]
        private string _username = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        public LoginViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        [RelayCommand]
        private void Login()
        {
            // 简单的登录验证
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "用户名和密码不能为空";
                return;
            }

            // 这里可以添加实际的登录逻辑，比如调用API验证用户
            // 暂时使用硬编码的验证
            if (Username == "admin" && Password == "admin")
            {
                ErrorMessage = string.Empty;
                // 登录成功，关闭当前窗口并打开MainWindow
                // 使用 Prism 容器解析 MainWindow
                var container = (System.Windows.Application.Current as PrismApplication)?.Container;
                if (container != null)
                {
                    var mainWindow = container.Resolve(typeof(MainWindow)) as MainWindow;
                    mainWindow?.Show();
                    System.Windows.Application.Current.Windows[0].Close();
                }
            }
            else
            {
                ErrorMessage = "用户名或密码错误";
            }
        }
    }
}