using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.Common.Configurations
{
    public class ResponseMessages
    {
        public Success Success { get; set; }
        public Error Error { get; set; }
    }

    public class Success
    {
        public string Insert { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
        public string BulkInsert { get; set; }
        public string BulkUpdate { get; set; }
        public string BulkDelete { get; set; }
        public string Get { get; set; }
        public string Authentication { get; set; }
    }

    public class Error
    {
        public string Insert { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
        public string BulkInsert { get; set; }
        public string BulkUpdate { get; set; }
        public string BulkDelete { get; set; }
        public string NotFound { get; set; }
        public string Authentication { get; set; }
        public string NotAcceptableId { get; set; }
    }
}
