using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class VehicleDetails : BaseEntity
    {
        public VehicleDetails()
        {
            ViolationRecords = new HashSet<ViolationRecords>();
        }

        public int VehicleDetailId { get; set; }

        public int VehicleId { get; set; }

        public string RegistrationNo { get; set; }

        public int RegistrationCityId { get; set; }

        public int OwnerId { get; set; }

        public bool ClearanceStatus { get; set; }

        public virtual OwnerDetails Owner { get; set; }

        public virtual City City { get; set; }

        public virtual Vehicles Vehicle { get; set; }

        public virtual ICollection<ViolationRecords> ViolationRecords { get; set; }
    }
}