using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace ETrafficViolationSystem.Entities.Response
{
    public class BaseResponse<TEntity> where TEntity : class
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccessful { get; set; }

        public TEntity Result { get; set; }

        public int? TotalRecords { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ApiException ApiException { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> Errors { get; set; }

        public BaseResponse(HttpStatusCode statusCode, string message, TEntity result = null, int? totalRecords = null)
        {
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    StatusCode = HttpStatusCode.OK;
                    Message = message ?? "Records Retrieved Successfully.";
                    IsSuccessful = true;
                    Result = result;
                    TotalRecords = totalRecords;
                    break;
                case HttpStatusCode.Created:
                    StatusCode = HttpStatusCode.Created;
                    Message = message ?? "Record Added Successfully.";
                    IsSuccessful = true;
                    Result = result;
                    TotalRecords = totalRecords;
                    break;
                case HttpStatusCode.NoContent:
                    StatusCode = HttpStatusCode.NoContent;
                    Message = message ?? "Resource Deleted Successfully.";
                    IsSuccessful = true;
                    break;
                case HttpStatusCode.BadRequest:
                    StatusCode = HttpStatusCode.BadRequest;
                    Message = message ?? "Invalid Resource Requested.";
                    IsSuccessful = false;
                    Result = result;
                    break;
                case HttpStatusCode.Unauthorized:
                    StatusCode = HttpStatusCode.Unauthorized;
                    Message = message ?? "Invalid Authentication Request.";
                    IsSuccessful = false;
                    break;
                case HttpStatusCode.NotFound:
                    StatusCode = HttpStatusCode.NotFound;
                    Message = message ?? "No Records Found.";
                    IsSuccessful = false;
                    break;
                case HttpStatusCode.MethodNotAllowed:
                    StatusCode = HttpStatusCode.MethodNotAllowed;
                    Message = message ?? "Method Not Allowed.";
                    IsSuccessful = false;
                    break;
                case HttpStatusCode.Conflict:
                    StatusCode = HttpStatusCode.Conflict;
                    Message = message ?? "Request Conflict.";
                    IsSuccessful = false;
                    break;
                case HttpStatusCode.UnsupportedMediaType:
                    StatusCode = HttpStatusCode.UnsupportedMediaType;
                    Message = message ?? "Media Type Not Supported.";
                    IsSuccessful = false;
                    break;
                case HttpStatusCode.InternalServerError:
                    StatusCode = HttpStatusCode.InternalServerError;
                    Message = message ?? "Internal Server Occurred.";
                    IsSuccessful = false;
                    break;
                case HttpStatusCode.NotAcceptable:
                    StatusCode = HttpStatusCode.NotAcceptable;
                    Message = message ?? "Request Body Not Acceptable.";
                    IsSuccessful = false;
                    break;
                default:
                    return;
            }
        }
    }
}