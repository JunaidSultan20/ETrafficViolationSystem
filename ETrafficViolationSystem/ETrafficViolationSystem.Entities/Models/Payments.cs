using System;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Payments : BaseEntity
    {
        public int ChallanNo { get; set; }

        public int TotalAmount { get; set; }

        public int PaidAmount { get; set; }

        public DateTime DateTime { get; set; }

        public byte PaymentModeId { get; set; }

        public int BankBranchId { get; set; }

        public virtual PaymentMode PaymentMode { get; set; }

        public virtual BankBranch BankBranch { get; set; }
    }
}