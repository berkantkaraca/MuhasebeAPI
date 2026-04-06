namespace MuhasebeAPI.Application.Wrappers;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public IEnumerable<string>? Errors { get; set; }

    // Başarılı durum
    public ApiResponse(T data, string message = "İşlem başarılı.")
    {
        Success = true;
        Data = data;
        Message = message;
    }

    // Başarısız durum
    public ApiResponse(string message, List<string>? errors = null)
    {
        Success = false;
        Message = message;
        Errors = errors ?? new List<string>();
    }

    public ApiResponse() { }
}
