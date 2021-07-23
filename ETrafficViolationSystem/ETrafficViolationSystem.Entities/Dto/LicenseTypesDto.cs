namespace ETrafficViolationSystem.Entities.Dto
{
    public class LicenseTypesDto : BaseDto
    {
        public byte? LicenseTypeId { get; set; }

        public string Title { get; set; }
    }

    public class LicenseTypesInsertDto : BaseInsertDto
    {
        public string Title { get; set; }
    }

    public class LicenseTypesUpdateDto : BaseUpdateDto
    {
        public string Title { get; set; }
    }
}