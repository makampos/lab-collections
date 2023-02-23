using System.Collections;

namespace Models.Common.Pagination;

internal class SortedListPaginator<T> : IPaginated<T>
{
    public int PageSize { get; set; }
    private Lazy<List<T>> SortedData { get; }
    private List<T> Items => this.SortedData.Value;
    public IPage<T> this[int offset] =>
        new ProjectingPage<T>(this.Items, this.Ordinal(offset), this.PageSize);
    
    public SortedListPaginator(IEnumerable<T> sequence, IComparer<T> comparer, int pageSize)
    {
        List<T> unsorted = new(sequence);
        this.SortedData = new(() => EnsureSorted(unsorted, comparer));
        this.PageSize = pageSize;
    }
    public IEnumerator<IPage<T>> GetEnumerator()
    {
        for (int i = 0; i < this.PagesCount; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    public int PagesCount => (this.Items.Count + this.PageSize - 1) / this.PageSize;
   
    private static List<T> EnsureSorted(List<T> data, IComparer<T> comparer)
    {
        data.Sort(comparer);
        return data;
    }
    private int Ordinal(int offset) => offset.InRange(0, this.PagesCount, nameof(offset)) + 1;
    
}
