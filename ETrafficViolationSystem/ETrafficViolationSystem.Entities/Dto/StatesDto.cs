using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class StatesDto : BaseDto
    {
        public StatesDto()
        {
            //Cities = new HashSet<CityDto>();
        }

        public int StateId { get; set; }

        public string StateTitle { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<CityDto> Cities { get; set; }
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