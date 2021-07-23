using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class BankBranchRequest : BaseRequest
    {
        public BankBranchDto BankBranchDto { get; set; }
    }

    public class BankBranchInsertRequest : BaseRequest
    {
        public BankBranchDto BankBranchDto { get; set; }
    }

    public class BankBranchUpdateRequest : BaseRequest
    {
        public BankBranchDto BankBranchDto { get; set; }
    }
}