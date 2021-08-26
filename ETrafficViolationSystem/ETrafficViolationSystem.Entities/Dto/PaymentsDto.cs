using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class PaymentsDto : BaseDto
    {
        public int ChallanNo { get; set; }

        public int TotalAmount { get; set; }

        public int PaidAmount { get; set; }

        public DateTime DateTime { get; set; }

        public byte PaymentModeId { get; set; }

        public int BankBranchId { get; set; }
    }

    public class PaymentsInsertDto
    {
        public int? TotalAmount { get; set; }

        public int? PaidAmount { get; set; }

        public DateTime? DateTime { get; set; }

        public byte? PaymentModeId { get; set; }

        public int? BankBranchId { get; set; }
    }

    public class PaymentsUpdateDto : BaseUpdateDto
    {
        public int? TotalAmount { get; set; }

        public int? PaidAmount { get; set; }

        public DateTime? DateTime { get; set; }

        public byte? PaymentModeId { get; set; }

        public int? BankBranchId { get; set; }
    }
}