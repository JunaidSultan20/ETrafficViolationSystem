namespace ETrafficViolationSystem.Entities.Dto
{
    public class LicenseSubTypesDto : BaseDto
    {
        public byte? LicenseSubTypeId { get; set; }

        public byte LicenseTypeId { get; set; }

        public string Title { get; set; }

        public string SubTypeClass { get; set; }
    }

    public class LicenseSubTypesInsertDto
    {
        public byte? LicenseTypeId { get; set; }

        public string Title { get; set; }

        public string SubTypeClass { get; set; }
    }

    public class LicenseSubTypesUpdateDto : BaseUpdateDto
    {
        public byte? LicenseTypeId { get; set; }

        public string Title { get; set; }

        public string SubTypeClass { get; set; }
    }
}