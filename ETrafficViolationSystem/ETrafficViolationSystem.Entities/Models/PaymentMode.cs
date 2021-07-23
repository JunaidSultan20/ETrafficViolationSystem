using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class PaymentMode : BaseEntity
    {
        public PaymentMode()
        {
            Payments = new HashSet<Payments>();
        }

        public byte PaymentModeId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}