namespace ETrafficViolationSystem.Entities.Dto
{
    public class VehicleDetailsDto : BaseDto
    {
        public int? VehicleDetailId { get; set; }

        public int? VehicleId { get; set; }

        public string RegistrationNo { get; set; }

        public int? RegistrationCityId { get; set; }

        public int? OwnerId { get; set; }

        public bool? ClearanceStatus { get; set; }
    }

    public class VehicleDetailsInsertDto
    {
        public int? VehicleId { get; set; }

        public string RegistrationNo { get; set; }

        public int? RegistrationCityId { get; set; }

        public int? OwnerId { get; set; }

        public bool? ClearanceStatus { get; set; }
    }

    public class VehicleDetailsUpdateDto : BaseUpdateDto
    {
        public int? VehicleId { get; set; }

        public string RegistrationNo { get; set; }

        public int? RegistrationCityId { get; set; }

        public int? OwnerId { get; set; }

        public bool? ClearanceStatus { get; set; }
    }
}