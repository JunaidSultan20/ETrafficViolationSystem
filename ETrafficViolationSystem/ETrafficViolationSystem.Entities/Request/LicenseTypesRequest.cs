using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class LicenseTypesRequest : BaseRequest
    {
        public LicenseTypesDto LicenseTypesDto { get; set; }
    }
}