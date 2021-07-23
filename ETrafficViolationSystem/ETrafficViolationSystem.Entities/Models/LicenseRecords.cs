using System;
using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class LicenseRecords : BaseEntity
    {
        public LicenseRecords()
        {
            ViolationRecords = new HashSet<ViolationRecords>();
        }

        public int LicenseNo { get; set; }

        public int DriverId { get; set; }

        public byte LicenseTypeId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int? PdlNo { get; set; }

        public int Points { get; set; }

        public bool Suspended { get; set; }

        public DateTime? SuspensionEndDate { get; set; }

        public bool Terminated { get; set; }

        public string LicenseImageFront { get; set; }

        public string LicenseImageBack { get; set; }

        public virtual DriverDetails Driver { get; set; }

        public virtual LicenseTypes LicenseType { get; set; }

        public virtual ICollection<ViolationRecords> ViolationRecords { get; set; }
    }
}