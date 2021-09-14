using ETrafficViolationSystem.Common.Enumerators;

namespace ETrafficViolationSystem.Entities.Request.QueryParameters
{
    public class QueryParameters
    {
        public string PageNumber { get; set; }
        
        public string PageSize { get; set; }

        public string OrderBy { get; set; }

        public SortingOrder? SortingOrder { get; set; }
    }
}