using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace WpfAppTraeTest.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "VisionPro 5-Camera Alignment System";

        [ObservableProperty]
        private string _systemStatus = "Ready";

        [ObservableProperty]
        private System.Windows.Media.Brush _statusBrush = System.Windows.Media.Brushes.Green;

        [ObservableProperty]
        private ObservableCollection<CameraInfo> _cameras = new();

        [ObservableProperty]
        private ObservableCollection<string> _logs = new();

        public MainWindowViewModel()
        {
            // Initialize 5 cameras
            for (int i = 1; i <= 5; i++)
            {
                Cameras.Add(new CameraInfo 
                { 
                    Name = $"Camera {i}", 
                    Status = "Online", 
                    ResultX = 0.0, 
                    ResultY = 0.0, 
                    ResultR = 0.0,
                    IsPass = true
                });
            }

            // Dummy logs
            Logs.Add($"{DateTime.Now:HH:mm:ss} - System initialized.");
            Logs.Add($"{DateTime.Now:HH:mm:ss} - VisionPro SDK loaded.");
            Logs.Add($"{DateTime.Now:HH:mm:ss} - All cameras online.");
        }
    }

    public partial class CameraInfo : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _status = "Offline";

        [ObservableProperty]
        private double _resultX;

        [ObservableProperty]
        private double _resultY;

        [ObservableProperty]
        private double _resultR;

        [ObservableProperty]
        private bool _isPass;

        public Brush StatusColor => IsPass ? Brushes.LimeGreen : Brushes.Red;
    }
}
