using System;

namespace ExamenReactNet.Core.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Doors { get; set; }
        public string Owner { get; set; }
    }
}
