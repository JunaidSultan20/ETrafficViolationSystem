using System;

namespace ETrafficViolationSystem.Entities.Models
{
    public class TaxDetails : BaseEntity
    {
        public int TaxId { get; set; }

        public int VehicleId { get; set; }

        public int OwnerId { get; set; }

        public byte TaxFilerType { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime PaidUpToDate { get; set; }

        public virtual OwnerDetails Owner { get; set; }

        public virtual Vehicles Vehicle { get; set; }
    }
}