using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class PaymentsRequest : BaseRequest
    {
        public PaymentsDto PaymentsDto { get; set; }
    }
}