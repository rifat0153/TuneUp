using CommunityToolkit.Mvvm.ComponentModel;

namespace TuneUp.Models;

public class AudioDevice : ObservableObject
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Manufacturer { get; set; }
    public bool IsDefault { get; set; }
    public required string DeviceType { get; set; } // e.g. Playback, Recording
}
