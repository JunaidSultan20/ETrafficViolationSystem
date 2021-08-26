namespace ETrafficViolationSystem.Entities.Dto
{
    public class DesignationDto : BaseDto
    {
        public byte? DesignationId { get; set; }

        public string Title { get; set; }

        public byte? ReportsTo { get; set; }
    }

    public class DesignationInsertDto
    {
        public string Title { get; set; }

        public byte? ReportsTo { get; set; }
    }

    public class DesignationUpdateDto : BaseUpdateDto
    {
        public string Title { get; set; }

        public byte? ReportsTo { get; set; }
    }
}