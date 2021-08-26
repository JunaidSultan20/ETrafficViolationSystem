namespace ETrafficViolationSystem.Entities.Dto
{
    public class VehicleColorTypeDto : BaseDto
    {
        public byte? ColorTypeId { get; set; }

        public string ColorTypeTitle { get; set; }
    }

    public class VehicleColorTypeInsertDto
    {
        public string ColorTypeTitle { get; set; }
    }

    public class VehicleColorTypeUpdateDto : BaseUpdateDto
    {
        public string ColorTypeTitle { get; set; }
    }
}