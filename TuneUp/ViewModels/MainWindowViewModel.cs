using System.Collections.ObjectModel;
using TuneUp.Models;

namespace TuneUp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    private ObservableCollection<AudioDevice> _audioDevices;

    public ObservableCollection<AudioDevice> AudioDevices
    {
        get => _audioDevices;
        set => SetProperty(ref _audioDevices, value);
    }

    public MainWindowViewModel()
    {
        AudioDevices =
        [
            new AudioDevice()
            {
                Id = "1",
                Name = "Default Playback Device",
                Manufacturer = "Generic Audio",
                IsDefault = true,
                DeviceType = "Playback",
            },
            new AudioDevice()
            {
                Id = "2",
                Name = "Default Recording Device",
                Manufacturer = "Generic Audio",
                IsDefault = true,
                DeviceType = "Recording",
            },
        ];
    }
}
