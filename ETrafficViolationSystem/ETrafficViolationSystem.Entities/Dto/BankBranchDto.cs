namespace ETrafficViolationSystem.Entities.Dto
{
    public class BankBranchDto : BaseDto
    {
        public int? BankBranchId { get; set; }

        public int? BranchCode { get; set; }

        public string BranchTitle { get; set; }

        public byte? BankId { get; set; }

        public int? CityId { get; set; }
    }

    public class BankBranchInsertDto : BaseInsertDto
    {
        public int BranchCode { get; set; }

        public string BranchTitle { get; set; }

        public byte BankId { get; set; }

        public int CityId { get; set; }
    }

    public class BankBranchUpdateDto : BaseUpdateDto
    {
        public int? BranchCode { get; set; }

        public string BranchTitle { get; set; }

        public byte? BankId { get; set; }

        public int? CityId { get; set; }
    }
}