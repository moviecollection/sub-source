using System.Net;

namespace MovieCollection.SubSource.Models;

public class HttpResponse<T>
{
    public T? Response { get; set; }

    public bool IsSuccess { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}
