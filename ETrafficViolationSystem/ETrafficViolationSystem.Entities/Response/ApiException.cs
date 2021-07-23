using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Response
{
    public class ApiException
    {
        public string ExceptionMessage { get; set; }

        public string Details { get; set; }

        public string InnerException { get; set; }

        public string ReferenceDocumentLink { get; set; }

        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public ApiException(string message, string details, string innerException, string link)
        {
            ExceptionMessage = message;
            Details = details;
            InnerException = innerException;
            if (!string.IsNullOrEmpty(link))
                ReferenceDocumentLink = link;
        }

        public ApiException(string message, string details, string innerException, string link, IEnumerable<ValidationError> validationErrors)
            : this(message, details, innerException, link)
        {
            ValidationErrors = validationErrors;
        }
    }
}