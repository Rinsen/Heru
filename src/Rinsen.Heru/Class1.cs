using System.Drawing;
using System.Reflection.Emit;
using System;
using System.Security.Claims;
using System.Threading;
using System.Timers;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using NModbus;
using System.Net.Sockets;
using NModbus.Extensions.Enron;
using Rinsen.Heru.Modbus;

namespace Rinsen.Heru;

public class Class1
{
    public void ReadValues()
    {

        using TcpClient client = new TcpClient("192.168.1.190", 502);

        var factory = new ModbusFactory();
        IModbusMaster master = factory.CreateMaster(client);

        var coilStatus = master.ReadCoils(0, (ushort)CoilStatus.UnitOn - 1, 4);
        master.WriteSingleCoil(0, (ushort)CoilStatus.BoostMode - 1, true);
        var newCoilStatus = master.ReadCoils(0, (ushort)CoilStatus.UnitOn - 1, 4);
        var result = master.ReadInputRegisters(0, (ushort)InputRegister.ComponentId - 1, 10);
        var result2 = master.ReadHoldingRegisters(0, (ushort)HoldingRegister.TemperatureSetpointEconomy - 1, 30);
        // read five input values
    }
    

}