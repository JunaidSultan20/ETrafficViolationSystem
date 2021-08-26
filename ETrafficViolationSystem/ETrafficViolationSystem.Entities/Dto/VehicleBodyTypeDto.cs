namespace ETrafficViolationSystem.Entities.Dto
{
    public class VehicleBodyTypeDto : BaseDto
    {
        public byte? BodyId { get; set; }

        public string BodyType { get; set; }
    }

    public class VehicleBodyTypeInsertDto
    {
        public string BodyType { get; set; }
    }

    public class VehicleBodyTypeUpdateDto : BaseUpdateDto
    {
        public string BodyType { get; set; }
    }
}