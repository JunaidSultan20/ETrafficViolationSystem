using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class CarModelRequest : BaseRequest
    {
        public CarModelDto CarModelDto { get; set; }
    }
}