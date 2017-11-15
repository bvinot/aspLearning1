﻿using RajeshWebApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace RajeshWebApplication3.Controllers
{
    public class DeviceController : Controller
    {

        // GET: Device
        public ActionResult Index()
        {

            return View(DeviceHelper.DeviceList);


        }
        public ActionResult CreateNew()
        {
            var qqq = new DeviceData();
            qqq.Model = "SAMPLE MODEL";
            return View(qqq);
        }

        [HttpPost]
        public ActionResult CreateNew(DeviceData d)
        {
            DeviceHelper.DeviceList.Add(d);

            ConvertToXml(DeviceHelper.DeviceList);

            return RedirectToAction("Index");
        }

        public ActionResult Details(DeviceData d)
        {
            return View(d);
        }

        private void ConvertToXml(List<DeviceData> deviceList)
        {
            XDocument d = new XDocument();
          List<XElement> elements =  new List<XElement>();
            foreach (var item in deviceList)
            {
                XElement x = new XElement("Device",
                    new XElement("Type", item.Type),
                    new XElement("Name", item.Name),
                    new XElement("Model", item.Model),
                    new XElement("SerialNum", item.SerialNum));

                elements.Add(x);
            }

            d.Add(new XElement("Devices", elements.Select(x => x)));

            string path = Server.MapPath("~/App_Data/Devices.xml");

            d.Save(path);

        }
    }
}