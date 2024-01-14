using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.Entities.Utilities;
public sealed class Response<T>
    where T : class
{
    public Response()
    {
    }

    public Response(T data)
    {
        Data = data;
    }

    public Response(string errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }
    public T? Data { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string? ErrorMessage { get; set; }
}
