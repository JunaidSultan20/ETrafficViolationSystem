using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Banks : BaseEntity
    {
        public Banks()
        {
            BankBranches = new HashSet<BankBranch>();
        }

        public byte BankId { get; set; }

        public string Title { get; set; }

        public string ShortCode { get; set; }

        public virtual ICollection<BankBranch> BankBranches { get; set; }
    }
}