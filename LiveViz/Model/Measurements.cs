using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveViz.Model
{

    public class Root
    {
        public Device Device { get; set; }
    }

    public class Device
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int NominalPower { get; set; }
        public string IpAdress { get; set; }
        public DateTime DateAndTime { get; set; }
        public int Milliseconds { get; set; }
        public Measurement[] Measurements { get; set; }
    }

    public class Measurement
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public MeasurementType Type { get; set; }
    }

    public enum MeasurementType
    {
        AC_Voltage,
        AC_Current,
        AC_Power,
        AC_Power_fast,
        AC_Frequency,
        DC_Voltage1,
        DC_Voltage2,
        DC_Current1,
        DC_Current2,
        LINK_Voltage,
        GridPower,
        GridConsumedPower,
        GridInjectedPower,
        OwnConsumedPower,
        Derating
    }
}
