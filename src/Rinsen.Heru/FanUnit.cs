using Rinsen.Heru.Modbus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinsen.Heru;

public class FanUnit
{
    private ModbusOptions _modbusOptions;

    public FanUnit(ModbusOptions modbusOptions)
    {
        _modbusOptions = modbusOptions;
    }

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

    public async Task<Temperature> GetTemperaturesAsync()
    {
        var inputRegisters = await new InputRegisterHandler().ReadInputRegistersAsync(_modbusOptions, InputRegister.OutdoorTemperature, 7);

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



    
    public async Task<int> GetFanSpeedAsync()
    {

        throw new NotImplementedException();
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
