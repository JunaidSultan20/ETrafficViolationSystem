using System;
using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class ViolationRecords : BaseEntity
    {
        public ViolationRecords()
        {
            ViolationRecordDetails = new HashSet<ViolationRecordDetails>();
        }

        public int ViolationId { get; set; }

        public int LicenseNo { get; set; }

        public int VehicleDetailId { get; set; }

        public int CityId { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public DateTime DateTime { get; set; }

        public int PointsDeducted { get; set; }

        public int ChallanNo { get; set; }

        public string BookedBy { get; set; }

        public virtual City City { get; set; }

        public virtual LicenseRecords LicenseRecords { get; set; }

        public virtual VehicleDetails VehicleDetail { get; set; }

        public virtual ICollection<ViolationRecordDetails> ViolationRecordDetails { get; set; }
    }
}