namespace ShopAppAPI.Application;

public class BaseResponse<T>
{
    public BaseResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
        IsSuccess = false;
    }
    public BaseResponse(T data)
    {
        Data = data;
        IsSuccess = true;
    }
    public BaseResponse()
    {

    }

    public string? ErrorMessage { get; }
    public bool IsSuccess { get; }
    public T? Data { get; }

    public static BaseResponse<T> Success()
        => new();

    public static BaseResponse<T> Success(T data)
        => new(data);

    public static BaseResponse<T> Fail(string errorMessage)
        => new(errorMessage);
}
