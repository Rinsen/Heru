using NModbus;
using NModbus.Device;
using NModbus.Logging;
using Rinsen.Heru.Modbus;
using System.Globalization;
using System.Net.Sockets;

namespace Rinsen.Heru;

public class FanUnit : IDisposable
{
    private readonly ModbusOptions _modbusOptions;
    private readonly CoilStatusHandler _coilStatusHandler;
    private readonly InputRegisterHandler _inputRegisterHandler;
    private readonly InputStatusHandler _inputStatusHandler;
    private TcpClient? _tcpClient = null;
    private IModbusMaster? _modbusMaster = null;
    private bool disposedValue;

    public FanUnit(ModbusOptions modbusOptions)
    {
        _modbusOptions = modbusOptions;
        _coilStatusHandler = new CoilStatusHandler();
        _inputRegisterHandler = new InputRegisterHandler();
        _inputStatusHandler = new InputStatusHandler();
    }

    /// <summary>
    /// Returns an object containing active unit modes and states.
    /// </summary>
    /// <returns><see cref="Status"/></returns>
    public async Task<Status> GetStatusAsync()
    {
        var coilStatuses = await _coilStatusHandler.ReadCoilsAsync(GetModbusMaster(), CoilStatus.UnitOn, 4);
        //var a = await _inputStatusHandler.ReadInputRegistersToDictionaryAsync(GetModbusMaster(), InputStatus.FireAlarmInput, 53);

        return new Status
        {
            UnitOn = coilStatuses[(int)CoilStatus.UnitOn - 1],
            BoostActive = coilStatuses[(int)CoilStatus.BoostMode - 1],
            OverpressureActive = coilStatuses[(int)CoilStatus.OverpressureMode - 1],
            AwayActive = coilStatuses[(int)CoilStatus.AwayMode - 1]
        };
    }

    /// <summary>
    /// Returns an object containing current temperatures.
    /// </summary>
    /// <returns><see cref="Temperature"/></returns>
    public async Task<Temperature> GetTemperaturesAsync()
    {
        var inputRegisters = await _inputRegisterHandler.ReadInputRegistersToDictionaryAsync(GetModbusMaster(), InputRegister.OutdoorTemperature, 7);

        return new Temperature
        {
            Exhaust = ParseUShortToDouble(inputRegisters[InputRegister.ExhaustAirTemperature]),
            Extract = ParseUShortToDouble(inputRegisters[InputRegister.ExtractAirTemperature]),
            Outdoor = ParseUShortToDouble(inputRegisters[InputRegister.OutdoorTemperature]),
            Room = inputRegisters[InputRegister.RoomTemperature] == 55546 ? null : ParseUShortToDouble(inputRegisters[InputRegister.RoomTemperature]),
            Supply = ParseUShortToDouble(inputRegisters[InputRegister.SupplyAirTemperature]),
            Rotor = ParseUShortToDouble(inputRegisters[InputRegister.HeatRecoveryTemperature])
        };
    }

    /// <summary>
    /// Returns and object containing current fan speeds in RPM and percentage
    /// </summary>
    /// <returns><see cref="FanSpeed"/></returns>
    public async Task<FanSpeed> GetFanSpeedAsync()
    {
        var inputRegisters = await new InputRegisterHandler().ReadInputRegistersToDictionaryAsync(GetModbusMaster(), InputRegister.CurrentSupplyFanPower, 4);

        return new FanSpeed
        {
            CurrentSupplyFanPower = inputRegisters[InputRegister.CurrentSupplyFanPower],
            CurrentExhaustFanPower = inputRegisters[InputRegister.CurrentExhaustFanPower],
            CurrentSupplyFanSpeed = inputRegisters[InputRegister.CurrentSupplyFanSpeed],
            CurrentExhaustFanSpeed = inputRegisters[InputRegister.CurrentExhaustFanSpeed]
        };
    }

    ///// <summary>
    ///// Returns raw values from holding registers
    ///// </summary>
    ///// <param name="startInputRegister">Parameter for selecting start register to read.</param>
    ///// <param name="count">Number of registers to read.</param>
    ///// <returns>Register data.</returns>
    //public async Task<ushort[]> GetRawHoldingRegister(InputRegister startInputRegister, int count)
    //{
    //    var inputRegisters = await new InputRegisterHandler().ReadInputRegistersAsync(_modbusOptions, startInputRegister, (ushort)count);

    //    return inputRegisters;
    //}

    /// <summary>
    /// Activate a setting
    /// </summary>
    /// <returns>Task</returns>
    public async Task ActivateSetting(Setting setting)
    {
        await ChangeSetting(GetModbusMaster(), setting, true);
    }

    /// <summary>
    /// Deactivate a setting
    /// </summary>
    /// <returns>Task</returns>
    public async Task DeactivateSetting(Setting setting)
    {
        await ChangeSetting(GetModbusMaster(), setting, false);
    }

    private async Task ChangeSetting(IModbusMaster modbusMaster, Setting setting, bool value)
    {
        CoilStatus coilStatus;
        switch (setting)
        {
            case Setting.BoostMode:
                coilStatus = CoilStatus.BoostMode;
                break;
            case Setting.OverpressureMode:
                coilStatus = CoilStatus.OverpressureMode;
                break;
            case Setting.AwayMode:
                coilStatus = CoilStatus.AwayMode;
                break;
            case Setting.UnitOn:
                coilStatus = CoilStatus.UnitOn;
                break;
            case Setting.ClearAlarms:
                coilStatus = CoilStatus.ClearAlarms;
                break;
            case Setting.ResetFilterTimer:
                coilStatus = CoilStatus.ResetFilterTimer;
                break;
            case Setting.ExtendOperation:
                coilStatus = CoilStatus.ExtendOperation;
                break;
            default:
                throw new Exception("Unknown setting");
        }

        await _coilStatusHandler.WriteSingleCoilAsync(modbusMaster, coilStatus, value);
    }

    private IModbusMaster GetModbusMaster()
    {
        if (_modbusMaster != null)
        {
            return _modbusMaster;
        }

        _tcpClient = new TcpClient(_modbusOptions.IpAddressOrHostName, _modbusOptions.PortNumber);

        var factory = new ModbusFactory(logger: new DebugModbusLogger(LoggingLevel.Trace));
        _modbusMaster = factory.CreateMaster(_tcpClient);

        return _modbusMaster;
    }

    private static double ParseUShortToDouble(ushort value)
    {
        string stringValue = value.ToString();
        if (value > 6000)
        {
            stringValue = (value - ushort.MaxValue).ToString();
        }

        char decimalChar = stringValue[^1];
        double decimalValue = double.Parse(decimalChar.ToString());
        stringValue = stringValue.Substring(0, stringValue.Length - 1) + "." + decimalValue;
        double result = double.Parse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture);
        return result;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _tcpClient?.Dispose();
                _tcpClient = null;
                _modbusMaster?.Dispose();
                _modbusMaster = null;
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~FanUnit()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
