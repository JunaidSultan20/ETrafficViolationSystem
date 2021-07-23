using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class LicenseRecordsRequest : BaseRequest
    {
        public LicenseRecordsDto LicenseRecordsDto { get; set; }
    }
}