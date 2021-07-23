using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class TaxDetailsDto : BaseDto
    {
        public int TaxId { get; set; }

        public int VehicleId { get; set; }

        public int OwnerId { get; set; }

        public byte TaxFilerType { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime PaidUpToDate { get; set; }
    }

    public class TaxDetailsInsertDto : BaseInsertDto
    {
        public int? VehicleId { get; set; }

        public int? OwnerId { get; set; }

        public byte? TaxFilerType { get; set; }

        public decimal? AmountPaid { get; set; }

        public DateTime? PaidDate { get; set; }

        public DateTime? PaidUpToDate { get; set; }
    }

    public class TaxDetailsUpdateDto : BaseUpdateDto
    {
        public int? VehicleId { get; set; }

        public int? OwnerId { get; set; }

        public byte? TaxFilerType { get; set; }

        public decimal? AmountPaid { get; set; }

        public DateTime? PaidDate { get; set; }

        public DateTime? PaidUpToDate { get; set; }
    }
}