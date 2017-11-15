using RajeshWebApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Linq;

namespace RajeshWebApplication3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GetDevicesList();
        }
        private void GetDevicesList()
        {
            string path = Server.MapPath("~/App_Data/Devices.xml");
            XDocument doc = XDocument.Load(path);
            DeviceHelper.DeviceList = new List<DeviceData>();
            foreach (var item in doc.Root.Elements())
            {

                PopulateData(item.Element("Type").Value, item);

                var abc = 123;
            }

        }

        private void PopulateData(string typeName, XElement item)
        {
            DeviceData d = null;
            if (typeName == "Desktop")
            {
                d = new Desktop();
            }
            if (typeName == "Laptop")
            {
                d = new Laptop();
            }
            if (typeName == "Mobile")
            {
                d = new Mobile();
            }

            d.Name = item.Element("Name").Value;
            d.Model = item.Element("Model").Value;
            d.SerialNum = item.Element("SerialNum").Value;
            d.Type = typeName;
            DeviceHelper.DeviceList.Add(d);
        }
    }
}

