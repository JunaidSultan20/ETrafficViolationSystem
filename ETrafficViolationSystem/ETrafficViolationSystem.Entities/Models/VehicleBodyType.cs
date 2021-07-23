using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class VehicleBodyType : BaseEntity
    {
        public VehicleBodyType()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public byte BodyId { get; set; }

        public string BodyType { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}