namespace ETrafficViolationSystem.Entities.Dto
{
    public class VehiclesDto : BaseDto
    {
        public int? VehicleId { get; set; }

        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public string FrameNo { get; set; }

        public short MakeId { get; set; }

        public short Year { get; set; }

        public string CategoryId { get; set; }

        public byte BodyTypeId { get; set; }

        public byte ClassId { get; set; }

        public byte Capacity { get; set; }

        public short HorsePower { get; set; }

        public byte Cylinders { get; set; }

        public short ColorId { get; set; }
    }

    public class VehiclesInsertDto
    {
        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public string FrameNo { get; set; }

        public short? MakeId { get; set; }

        public short? Year { get; set; }

        public string CategoryId { get; set; }

        public byte? BodyTypeId { get; set; }

        public byte? ClassId { get; set; }

        public byte? Capacity { get; set; }

        public short? HorsePower { get; set; }

        public byte? Cylinders { get; set; }

        public short? ColorId { get; set; }
    }

    public class VehiclesUpdateDto : BaseUpdateDto
    {
        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public string FrameNo { get; set; }

        public short MakeId { get; set; }

        public short Year { get; set; }

        public string CategoryId { get; set; }

        public byte BodyTypeId { get; set; }

        public byte ClassId { get; set; }

        public byte Capacity { get; set; }

        public short HorsePower { get; set; }

        public byte Cylinders { get; set; }

        public short ColorId { get; set; }
    }
}