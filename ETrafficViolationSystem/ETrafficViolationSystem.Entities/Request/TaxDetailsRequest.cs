using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class TaxDetailsRequest : BaseRequest
    {
        public TaxDetailsDto TaxDetailsDto { get; set; }
    }
}