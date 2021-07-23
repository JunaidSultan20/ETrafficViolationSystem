using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Vehicles : BaseEntity
    {
        public Vehicles()
        {
            TaxDetails = new HashSet<TaxDetails>();
            VehicleDetails = new HashSet<VehicleDetails>();
        }

        public int VehicleId { get; set; }

        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public string FrameNo { get; set; }

        public short MakeId { get; set; }

        public short Year { get; set; }

        public string CategoryId { get; set; }

        public byte BodyTypeId { get; set; }

        public byte ClassId { get; set; }

        public byte Capacity { get; set; }

        public short HorsePower { get; set; }

        public byte Cylinders { get; set; }

        public short ColorId { get; set; }

        public virtual VehicleBodyType VehicleBodyType { get; set; }

        public virtual VehicleClass VehicleClass { get; set; }

        public virtual VehicleColors VehicleColor { get; set; }

        public virtual CarMake CarMake { get; set; }

        public virtual ICollection<TaxDetails> TaxDetails { get; set; }

        public virtual ICollection<VehicleDetails> VehicleDetails { get; set; }
    }
}