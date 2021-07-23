using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class VehicleColors : BaseEntity
    {
        public VehicleColors()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public short ColorId { get; set; }

        public byte ColorTypeId { get; set; }

        public string ColorName { get; set; }

        public string ColorCode { get; set; }

        public virtual VehicleColorType VehicleColorType { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}