using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class ViolationRecordsDto : BaseDto
    {
        public int? ViolationId { get; set; }

        public int LicenseNo { get; set; }

        public int VehicleDetailId { get; set; }

        public int CityId { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public DateTime DateTime { get; set; }

        public int PointsDeducted { get; set; }

        public int ChallanNo { get; set; }

        public string BookedBy { get; set; }
    }

    public class ViolationRecordsInsertDto : BaseInsertDto
    {
        public int? LicenseNo { get; set; }

        public int? VehicleDetailId { get; set; }

        public int? CityId { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public DateTime? DateTime { get; set; }

        public int? PointsDeducted { get; set; }

        public int? ChallanNo { get; set; }

        public string BookedBy { get; set; }
    }

    public class ViolationRecorsUpdateDto : BaseUpdateDto
    {
        public int? LicenseNo { get; set; }

        public int? VehicleDetailId { get; set; }

        public int? CityId { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public DateTime? DateTime { get; set; }

        public int? PointsDeducted { get; set; }

        public int? ChallanNo { get; set; }

        public string BookedBy { get; set; }
    }
}