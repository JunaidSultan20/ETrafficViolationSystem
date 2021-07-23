using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class CarMakeRequest : BaseRequest
    {
        public CarMakeDto CarMakeDto { get; set; }
    }
}