namespace ETrafficViolationSystem.Entities.Request
{
    public abstract class BaseRequest
    {
        public int UserId { get; set; }

        public string AccessToken { get; set; }

        public int StartPage { get; set; }

        public int PageLimit { get; set; }
    }
}