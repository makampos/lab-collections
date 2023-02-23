namespace Models.Common.Pagination;

public interface IPaginated<T> : IEnumerable<IPage<T>>
{
    int PagesCount { get; }
    IPage<T> this[int offSet] { get; }
}