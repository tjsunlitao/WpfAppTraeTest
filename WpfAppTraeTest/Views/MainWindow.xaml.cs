using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Regions;
using WpfAppTraeTest.ViewModels;

namespace WpfAppTraeTest.Views
{
    public partial class MainWindow : Window
    {
        private bool _isNavCollapsed = false;
        private readonly IRegionManager _regionManager;

        public MainWindow(MainWindowViewModel viewModel, IRegionManager regionManager)
        {
            InitializeComponent();
            DataContext = viewModel;
            _regionManager = regionManager;
            
            // 窗口加载时导航到主界面
            Loaded += (s, e) =>
            {
                _regionManager.RequestNavigate("MainContentRegion", "HomeView");
            };
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void HeaderPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            // 重置所有导航按钮样式
            btnHome.Style = (Style)FindResource("NavButton");
            btnCameraStatus.Style = (Style)FindResource("NavButton");
            btnCalibration.Style = (Style)FindResource("NavButton");
            btnParameters.Style = (Style)FindResource("NavButton");

            // 设置当前按钮为选中样式
            if (sender is System.Windows.Controls.Button btn)
            {
                btn.Style = (Style)FindResource("NavButtonSelected");

                // 根据Tag执行导航
                string tag = btn.Tag?.ToString();
                switch (tag)
                {
                    case "Home":
                        _regionManager.RequestNavigate("MainContentRegion", "HomeView");
                        break;
                    case "CameraStatus":
                        _regionManager.RequestNavigate("MainContentRegion", "CameraStatusView");
                        break;
                    case "Calibration":
                        _regionManager.RequestNavigate("MainContentRegion", "CalibrationView");
                        break;
                    case "Parameters":
                        _regionManager.RequestNavigate("MainContentRegion", "ParameterSettingsView");
                        break;
                }
            }
        }

        private void CollapseNavButton_Click(object sender, RoutedEventArgs e)
        {
            _isNavCollapsed = true;
            NavPanel.Visibility = Visibility.Collapsed;
            btnExpandNav.Visibility = Visibility.Visible;
        }

        private void ExpandNavButton_Click(object sender, RoutedEventArgs e)
        {
            _isNavCollapsed = false;
            NavPanel.Visibility = Visibility.Visible;
            btnExpandNav.Visibility = Visibility.Collapsed;
        }
    }
}