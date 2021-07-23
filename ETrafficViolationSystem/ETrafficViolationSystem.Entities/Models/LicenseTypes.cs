using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class LicenseTypes : BaseEntity
    {
        public LicenseTypes()
        {
            LicenseRecords = new HashSet<LicenseRecords>();
            LicenseSubTypes = new HashSet<LicenseSubTypes>();
        }
        public byte LicenseTypeId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<LicenseRecords> LicenseRecords { get; set; }

        public virtual ICollection<LicenseSubTypes> LicenseSubTypes { get; set; }
    }
}