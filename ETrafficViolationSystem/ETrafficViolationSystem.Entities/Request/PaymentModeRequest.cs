using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class PaymentModeRequest : BaseRequest
    {
        public PaymentModeDto PaymentModeDto { get; set; }
    }
}