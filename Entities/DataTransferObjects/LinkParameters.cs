using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects;

public record LinkParameters
{
    public BookParameters BookParameters { get; init; } // immutable
    public HttpContext HttpContext { get; set; }
}
