using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class BankBranch : BaseEntity
    {
        public BankBranch()
        {
            Payments = new HashSet<Payments>();
        }

        public int BankBranchId { get; set; }

        public int BranchCode { get; set; }

        public string BranchTitle { get; set; }

        public byte BankId { get; set; }

        public int CityId { get; set; }

        public virtual Banks Bank { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
