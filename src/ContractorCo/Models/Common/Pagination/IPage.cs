namespace Models.Common.Pagination;

public interface IPage<T> : IEnumerable<T>
{
    int Ordinal { get; }
    int Count { get; }
    int PageSize { get; }
}