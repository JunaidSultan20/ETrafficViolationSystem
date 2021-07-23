using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class ViolationRecordDetailsRequest : BaseRequest
    {
        public ViolationRecordDetailsDto ViolationRecordDetailsDto { get; set; }
    }
}