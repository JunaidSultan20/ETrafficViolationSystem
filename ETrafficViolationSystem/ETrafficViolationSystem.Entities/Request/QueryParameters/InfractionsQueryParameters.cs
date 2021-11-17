namespace ETrafficViolationSystem.Entities.Request.QueryParameters
{
    public class InfractionsQueryParameters : BaseQueryParameters
    {
        public string Penalty { get; set; }
        public string Points { get; set; }
    }
}