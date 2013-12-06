using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Model.Entities
{
    public class VirtualVehicle
    {
        public string Serial {get; set;}
        public string OriginId { get; set; }
        public string OriginName { get; set; }
        public string CurrentId { get; set; }
        public string CurrentName { get; set; }
        public string VehicleType { get; set; }
        public string License { get; set; }
        public string Brand { get; set; }
    }
}
