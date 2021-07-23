using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class VehicleClass : BaseEntity
    {
        public VehicleClass()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public byte ClassId { get; set; }

        public string ClassTitle { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}