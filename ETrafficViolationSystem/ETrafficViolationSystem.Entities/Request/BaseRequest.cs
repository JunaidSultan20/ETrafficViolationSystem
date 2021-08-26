namespace ETrafficViolationSystem.Entities.Request
{
    public abstract class BaseRequest
    {
        public int StartPage { get; set; }

        public int PageLimit { get; set; }
    }
}