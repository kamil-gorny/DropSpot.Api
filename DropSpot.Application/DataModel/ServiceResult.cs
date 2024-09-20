using System.Net;
using System.Text;

namespace DropSpot.Application.DataModel;

public class ServiceResult
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message;
    
    public static ServiceResult Success()
    {
        return new ServiceResult
        {
            StatusCode = HttpStatusCode.OK
        };
    }
    public static ServiceResult NotFound(EntityType entityType, Guid id)
    {
        return new ServiceResult
        {
            StatusCode = HttpStatusCode.NotFound,
            Message = $"{entityType.ToString()} {id} not found"
        };
    }
    
    
    public static ServiceResult BadRequest(IEnumerable<string> missingValues)
    {
        var sb = new StringBuilder().Append("You can't perform this action, missing values: ").AppendJoin('/', missingValues);
        
        return new ServiceResult
        {
            StatusCode = HttpStatusCode.BadRequest,
            Message = sb.ToString()
        };
    }
    
    public static ServiceResult InternalServerError(string errorMessage)
    {
        return new ServiceResult
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Message = errorMessage
        };
    }
}

public class ServiceResult<T> : ServiceResult
{
    public T Data;
}