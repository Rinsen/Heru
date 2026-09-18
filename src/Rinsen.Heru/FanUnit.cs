using Rinsen.Heru.Modbus;
using System.Globalization;

namespace Rinsen.Heru;

public class FanUnit : IDisposable
{
    private readonly ApplicationControlCoilStatusRegistersHandler _applicationControlCoilStatusRegistersHandler;
    private readonly ApplicationControlInputRegistersHandler _applicationControlInputRegistersHandler;
    private readonly DateTimeHandler _dateTimeHandler;
    private bool disposedValue;
    private static ModbusMasterFactory? _modbusClient = null;

    internal FanUnit(
        ApplicationControlCoilStatusRegistersHandler applicationControlCoilStatusRegistersHandler,
        ApplicationControlInputRegistersHandler applicationControlInputRegistersHandler,
        ApplicationControlHoldingRegisterHandler applicationControlHoldingRegisterHandler,
        DateTimeHandler dateTimeHandler)
    {
        _applicationControlCoilStatusRegistersHandler = applicationControlCoilStatusRegistersHandler;
        _applicationControlInputRegistersHandler = applicationControlInputRegistersHandler;
        _dateTimeHandler = dateTimeHandler;
    }

    /// <summary>
    /// Returns an object containing active unit modes and states.
    /// </summary>
    /// <returns><see cref="Status"/></returns>
    public async Task<Status> GetStatusAsync()
    {
        var coilStatuses = await _applicationControlCoilStatusRegistersHandler.ReadApplicationControlStatisRegisters(ApplicationControlCoilStatusRegisters.UnitOn, 4);

        return new Status
        {
            UnitOn = coilStatuses[(int)ApplicationControlCoilStatusRegisters.UnitOn - 1],
            BoostActive = coilStatuses[(int)ApplicationControlCoilStatusRegisters.BoostMode - 1],
            OverpressureActive = coilStatuses[(int)ApplicationControlCoilStatusRegisters.OverpressureMode - 1],
            AwayActive = coilStatuses[(int)ApplicationControlCoilStatusRegisters.AwayMode - 1]
        };
    }

    /// <summary>
    /// Returns an object containing current temperatures.
    /// </summary>
    /// <returns><see cref="Temperature"/></returns>
    public async Task<Temperature> GetTemperaturesAsync()
    {
        var inputRegisters = await _applicationControlInputRegistersHandler.ReadApplicationControlInputs(ApplicationControlInputRegisters.OutdoorTemperature, 7);

        return new Temperature
        {
            Exhaust = ParseUShortToDouble(inputRegisters[ApplicationControlInputRegisters.ExhaustAirTemperature]),
            Extract = ParseUShortToDouble(inputRegisters[ApplicationControlInputRegisters.ExtractAirTemperature]),
            Outdoor = ParseUShortToDouble(inputRegisters[ApplicationControlInputRegisters.OutdoorTemperature]),
            Room = inputRegisters[ApplicationControlInputRegisters.RoomTemperature] == 55546 ? null : ParseUShortToDouble(inputRegisters[ApplicationControlInputRegisters.RoomTemperature]),
            Supply = ParseUShortToDouble(inputRegisters[ApplicationControlInputRegisters.SupplyAirTemperature]),
            Rotor = ParseUShortToDouble(inputRegisters[ApplicationControlInputRegisters.HeatRecoveryTemperature])
        };
    }

    /// <summary>
    /// Returns and object containing current fan speeds in RPM and percentage
    /// </summary>
    /// <returns><see cref="FanSpeed"/></returns>
    public async Task<FanSpeed> GetFanSpeedAsync()
    {
        var inputRegisters = await _applicationControlInputRegistersHandler.ReadApplicationControlInputs(ApplicationControlInputRegisters.CurrentSupplyFanPower, 4);

        return new FanSpeed
        {
            CurrentSupplyFanPower = inputRegisters[ApplicationControlInputRegisters.CurrentSupplyFanPower],
            CurrentExhaustFanPower = inputRegisters[ApplicationControlInputRegisters.CurrentExhaustFanPower],
            CurrentSupplyFanSpeed = inputRegisters[ApplicationControlInputRegisters.CurrentSupplyFanSpeed],
            CurrentExhaustFanSpeed = inputRegisters[ApplicationControlInputRegisters.CurrentExhaustFanSpeed]
        };
    }

    /// <summary>
    /// Activate a setting
    /// </summary>
    /// <returns>Task</returns>
    public async Task ActivateSetting(Setting setting)
    {
        await ChangeSetting(setting, true);
    }

    /// <summary>
    /// Deactivate a setting
    /// </summary>
    /// <returns>Task</returns>
    public async Task DeactivateSetting(Setting setting)
    {
        await ChangeSetting(setting, false);
    }

    private async Task ChangeSetting(Setting setting, bool value)
    {
        ApplicationControlCoilStatusRegisters coilStatus;
        switch (setting)
        {
            case Setting.BoostMode:
                coilStatus = ApplicationControlCoilStatusRegisters.BoostMode;
                break;
            case Setting.OverpressureMode:
                coilStatus = ApplicationControlCoilStatusRegisters.OverpressureMode;
                break;
            case Setting.AwayMode:
                coilStatus = ApplicationControlCoilStatusRegisters.AwayMode;
                break;
            case Setting.UnitOn:
                coilStatus = ApplicationControlCoilStatusRegisters.UnitOn;
                break;
            case Setting.ClearAlarms:
                coilStatus = ApplicationControlCoilStatusRegisters.ClearAlarms;
                break;
            case Setting.ResetFilterTimer:
                coilStatus = ApplicationControlCoilStatusRegisters.ResetFilterTimer;
                break;
            case Setting.ExtendOperation:
                coilStatus = ApplicationControlCoilStatusRegisters.ExtendOperation;
                break;
            default:
                throw new Exception("Unknown setting");
        }

        await _applicationControlCoilStatusRegistersHandler.WriteSingleCoilAsync(coilStatus, value);
    }

    public async Task SetTime()
    {
        await _dateTimeHandler.SetDateTimeNowAsync();
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

    public static FanUnit Create(ModbusOptions modbusOptions)
    {
        if (_modbusClient == null)
        {
            _modbusClient = new ModbusMasterFactory(modbusOptions);
        }

        var applicationControlCoilStatusRegistersHandler = new ApplicationControlCoilStatusRegistersHandler(_modbusClient);
        var applicationControlInputRegistersHandler = new ApplicationControlInputRegistersHandler(_modbusClient);
        var applicationControlHoldingRegisterHandler = new ApplicationControlHoldingRegisterHandler(_modbusClient);
        var dateTimeHandler = new DateTimeHandler(applicationControlHoldingRegisterHandler);

        return new FanUnit(applicationControlCoilStatusRegistersHandler, applicationControlInputRegistersHandler, applicationControlHoldingRegisterHandler, dateTimeHandler);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (_modbusClient != null)
                {
                    _modbusClient.Dispose();
                    _modbusClient = null;
                }
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
