namespace ETrafficViolationSystem.Entities.Dto
{
    public class StatesDto : BaseDto
    {
        public int StateId { get; set; }

        public string StateTitle { get; set; }

        public int CountryId { get; set; }
    }

    public class StatesInsertDto
    {
        public string StateTitle { get; set; }

        public int? CountryId { get; set; }
    }

    public class StatesUpdateDto : BaseUpdateDto
    {
        public string StateTitle { get; set; }

        public int? CountryId { get; set; }
    }
}