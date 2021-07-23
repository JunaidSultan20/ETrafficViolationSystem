using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class StatesRequest : BaseRequest
    {
        public StatesDto StatesDto { get; set; }
    }

    public class StateInsertRequest : BaseRequest
    {
        public StatesInsertDto State { get; set; }
    }

    public class StateUpdateRequest : BaseRequest
    {
        public StatesUpdateDto State { get; set; }
    }
}