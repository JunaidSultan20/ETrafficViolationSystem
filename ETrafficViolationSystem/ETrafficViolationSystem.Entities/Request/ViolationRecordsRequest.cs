using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class ViolationRecordsRequest : BaseRequest
    {
        public ViolationRecordsDto ViolationRecordsDto { get; set; }
    }
}