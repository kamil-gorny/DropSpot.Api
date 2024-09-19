using System.Net;

namespace DropSpot.Application.DataModel;

public class ServiceResult
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
}

public class ServiceResult<T> where T : class
{
    public HttpStatusCode StatusCode { get; set; }
    public T Data { get; set; } 
}