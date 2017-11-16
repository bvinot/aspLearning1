using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RajeshWebApplication3.Models
{
    public class DeviceData
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNum { get; set; }
        public string Type { get; set; }

        internal static string First(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
    public class Desktop : DeviceData
    {

    }
    public class Laptop : DeviceData
    {

    }
    public class Mobile : DeviceData
    {

    }
    public class DeviceHelper
    {
        public static List<DeviceData> DeviceList { get; set; }

    }
}