using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LiveViz.Model;
using Microsoft.AspNetCore.Components;

namespace LiveViz.Pages
{
    public class IndexBase : ComponentBase
    {

        [Inject]
        public HttpClient httpClient { get; set; }

        protected Device Inverter { get; set; }
        public double GridPower { get; set; }

        protected override async Task OnInitializedAsync()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root), new XmlRootAttribute("Root"));
            var xmlString = await httpClient.GetStringAsync("http://192.168.178.46/measurements.xml");
            Console.WriteLine("Read completed");
            using (StringReader stringReader = new StringReader(xmlString))
            {
                var root = (Root)serializer.Deserialize(stringReader);
                Inverter = root.Device;
            }

            GridPower = Inverter.Measurements[10].Value;
        }
    }
}
