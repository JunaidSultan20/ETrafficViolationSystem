namespace ETrafficViolationSystem.Entities.Models
{
    public class LicenseSubTypes : BaseEntity
    {
        public byte LicenseSubTypeId { get; set; }

        public byte LicenseTypeId { get; set; }

        public string Title { get; set; }

        public string SubTypeClass { get; set; }

        public virtual LicenseTypes LicenseTypes { get; set; }
    }
}