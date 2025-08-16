using CommunityToolkit.Mvvm.ComponentModel;

namespace TuneUp.Models;

public enum AudioDeviceType
{
    Playback,
    Recording,
}

public class AudioDevice : ObservableObject
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Manufacturer { get; set; }
    public bool IsDefault { get; set; }
    public required AudioDeviceType DeviceType { get; set; }
}
