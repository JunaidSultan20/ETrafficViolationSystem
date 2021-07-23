using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class LicenseRecordsDto : BaseDto
    {
        public int? LicenseNo { get; set; }

        public int DriverId { get; set; }

        public byte LicenseTypeId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int? PdlNo { get; set; }

        public int Points { get; set; }

        public bool Suspended { get; set; }

        public DateTime? SuspensionEndDate { get; set; }

        public bool Terminated { get; set; }

        public string LicenseImageFront { get; set; }

        public string LicenseImageBack { get; set; }
    }

    public class LicenseRecordsInsertDto : BaseInsertDto
    {
        public int? DriverId { get; set; }

        public byte? LicenseTypeId { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int? PdlNo { get; set; }

        public int? Points { get; set; }

        public bool? Suspended { get; set; }

        public DateTime? SuspensionEndDate { get; set; }

        public bool? Terminated { get; set; }

        public string LicenseImageFront { get; set; }

        public string LicenseImageBack { get; set; }
    }

    public class LicenseRecordsUpdateDto : BaseUpdateDto
    {
        public int? DriverId { get; set; }

        public byte? LicenseTypeId { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int? PdlNo { get; set; }

        public int? Points { get; set; }

        public bool? Suspended { get; set; }

        public DateTime? SuspensionEndDate { get; set; }

        public bool? Terminated { get; set; }

        public string LicenseImageFront { get; set; }

        public string LicenseImageBack { get; set; }
    }
}