using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenReactNet.Api.DataTransferObjects
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string LicensePlate { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Doors { get; set; }
        public string OwnerEmail { get; set; }
    }
}
