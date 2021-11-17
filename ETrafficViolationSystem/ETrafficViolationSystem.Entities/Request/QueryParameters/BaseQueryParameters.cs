using ETrafficViolationSystem.Common.Enumerators;

namespace ETrafficViolationSystem.Entities.Request.QueryParameters
{
    public class BaseQueryParameters
    {
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }

        public string OrderBy { get; set; }
    }
}