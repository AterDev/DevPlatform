namespace Share.Models;

/// <summary>
/// 带分页的结果
/// </summary>
/// <typeparam name="T"></typeparam>
public class PageResult<T>
{
    public int Count { get; set; }
    public List<T>? Data { get; set; }
    public int PageIndex { get; set; }
}
