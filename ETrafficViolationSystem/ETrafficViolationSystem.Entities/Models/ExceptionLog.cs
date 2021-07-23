namespace ETrafficViolationSystem.Entities.Models
{
    public class ExceptionLog : BaseEntity
    {
        public int Id { get; set; }

        public string ExceptionMessage { get; set; }

        public string InnerException { get; set; }

        public string Url { get; set; }

        public string RemoteIp { get; set; }
    }
}