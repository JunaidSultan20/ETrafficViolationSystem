using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class VehicleColorType : BaseEntity
    {
        public VehicleColorType()
        {
            VehicleColors = new HashSet<VehicleColors>();
        }

        public byte ColorTypeId { get; set; }

        public string ColorTypeTitle { get; set; }

        public virtual ICollection<VehicleColors> VehicleColors { get; set; }
    }
}