using Rinsen.Heru.Modbus;
using System.Globalization;

namespace Rinsen.Heru;

public class FanUnit
{
    private ModbusOptions _modbusOptions;

    public FanUnit(ModbusOptions modbusOptions)
    {
        _modbusOptions = modbusOptions;
    }

    /// <summary>
    /// Returns an object containing active unit modes and states.
    /// </summary>
    /// <returns><see cref="Status"/></returns>
    public async Task<Status> GetStatusAsync()
    {
        var coilStatuses = await new CoilStatusHandler().ReadCoilsAsync(_modbusOptions, CoilStatus.UnitOn, 4);

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
        var inputRegisters = await new InputRegisterHandler().ReadInputRegistersToDictionaryAsync(_modbusOptions, InputRegister.OutdoorTemperature, 7);

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
        var inputRegisters = await new InputRegisterHandler().ReadInputRegistersToDictionaryAsync(_modbusOptions, InputRegister.CurrentSupplyFanPower, 7);

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
                coilStatus = CoilStatus.BoostMode;
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

        await new CoilStatusHandler().WriteSingleCoilAsync(_modbusOptions, coilStatus, true);
    }

    /// <summary>
    /// Deactivate a setting
    /// </summary>
    /// <returns>Task</returns>
    public async Task DeactivateSetting(Setting setting)
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
                coilStatus = CoilStatus.BoostMode;
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

        await new CoilStatusHandler().WriteSingleCoilAsync(_modbusOptions, coilStatus, false);
    }

    private static double ParseUShortToDouble(ushort value)
    {
        string stringValue = value.ToString();
        char decimalChar = stringValue[stringValue.Length - 1];
        double decimalValue = double.Parse(decimalChar.ToString());
        stringValue = stringValue.Substring(0, stringValue.Length - 1) + "." + decimalValue;
        double result = double.Parse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture);
        return result;
    }




}
