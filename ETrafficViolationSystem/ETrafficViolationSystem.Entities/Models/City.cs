using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class City : BaseEntity
    {
        public City()
        {
            BankBranches = new HashSet<BankBranch>();
            DriverDetails = new HashSet<DriverDetails>();
            Officers = new HashSet<Officers>();
            OwnerDetails = new HashSet<OwnerDetails>();
            VehicleDetails = new HashSet<VehicleDetails>();
            ViolationRecords = new HashSet<ViolationRecords>();
        }

        public int CityId { get; set; }

        public string CityTitle { get; set; }

        public int PostalCode { get; set; }

        public int? StateId { get; set; }

        public virtual States State { get; set; }

        public virtual ICollection<BankBranch> BankBranches { get; set; }

        public virtual ICollection<DriverDetails> DriverDetails { get; set; }

        public virtual ICollection<Officers> Officers { get; set; }

        public virtual ICollection<OwnerDetails> OwnerDetails { get; set; }

        public virtual ICollection<VehicleDetails> VehicleDetails { get; set; }

        public virtual ICollection<ViolationRecords> ViolationRecords { get; set; }
    }
}