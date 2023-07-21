using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleBrand { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleKm { get; set; }
        public string VehicleStatus { get; set; }
    }
}
