using mda_take_2.Models;

public interface IConverterService
{
    // State
    ConverterState CurrentState { get; }
    event EventHandler<ConverterState> StateChanged;

    // PWM
    Task SetPwmParametersAsync(int channelIndex, PwmChannel parameters);
    Task<PwmChannel> GetPwmParametersAsync(int channelIndex);

    // ADC
    event EventHandler<IReadOnlyList<AdcChannel>> AdcUpdated;

    // GPIO
    Task SetGpioPinAsync(int pinIndex, bool value);
    Task<IReadOnlyList<GpioPin>> GetGpioStatesAsync();

    // Connection lifecycle
    Task ConnectAsync();
    Task DisconnectAsync();
    bool IsConnected { get; }
}