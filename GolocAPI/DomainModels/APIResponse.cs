namespace GolocAPI.Models;
public record APIResponse<T>
{
    public int Status { get; set; }
    public string Message { get; set; }
    public string MoreInfo { get; set; }
    public T Data { get; set; }
}
