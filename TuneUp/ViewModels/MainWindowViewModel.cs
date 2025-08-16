using System.Collections.ObjectModel;
using NAudio.CoreAudioApi; // Add this using directive
using TuneUp.Models;

namespace TuneUp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    private ObservableCollection<AudioDevice> _audioDevices = [];

    public ObservableCollection<AudioDevice> AudioDevices
    {
        get => _audioDevices;
        set => SetProperty(ref _audioDevices, value);
    }

    public MainWindowViewModel()
    {
        AudioDevices = new ObservableCollection<AudioDevice>();
        RetrieveAudioDevices();
    }

    private void RetrieveAudioDevices()
    {
        var enumerator = new MMDeviceEnumerator();

        // Playback devices
        foreach (
            var device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)
        )
        {
            AudioDevices.Add(
                new AudioDevice
                {
                    Id = device.ID,
                    Name = device.FriendlyName,
                    Manufacturer = device.DeviceFriendlyName,
                    IsDefault =
                        device.ID
                        == enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia).ID,
                    DeviceType = AudioDeviceType.Playback,
                }
            );
        }

        // Recording devices
        foreach (
            var device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)
        )
        {
            AudioDevices.Add(
                new AudioDevice
                {
                    Id = device.ID,
                    Name = device.FriendlyName,
                    Manufacturer = device.DeviceFriendlyName,
                    IsDefault =
                        device.ID
                        == enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia).ID,
                    DeviceType = AudioDeviceType.Recording,
                }
            );
        }
    }
}
