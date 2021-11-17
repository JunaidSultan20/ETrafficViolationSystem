namespace ETrafficViolationSystem.Entities.Dto
{
    public class InfractionsDto : BaseDto
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public int Penalty { get; set; }

        public byte Points { get; set; }
    }

    public class InfractionsInsertDto
    {
        public string Description { get; set; }

        public int? Penalty { get; set; }

        public byte? Points { get; set; }
    }

    public class InfractionsUpdateDto : BaseUpdateDto
    {
        public string Description { get; set; }

        public int? Penalty { get; set; }

        public byte? Points { get; set; }
    }
}