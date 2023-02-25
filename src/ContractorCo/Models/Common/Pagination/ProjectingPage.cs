using System.Collections;

namespace Models.Common.Pagination;

public class ProjectingPage<T> : IPage<T>
{
    public int Ordinal { get; }
    public int PageSize { get; }
    private IReadOnlyList<T> Items { get; }
    
    public ProjectingPage(IReadOnlyList<T> items, int ordinal, int pageSize)
    {
        this.Items = items;
        this.Ordinal = ordinal;
        this.PageSize = pageSize;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Offset; i < this.EndOffset; i++)
        {
            yield return this.Items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    
    private int Offset => (this.Ordinal - 1) * this.PageSize;
    private int EndOffset => Math.Min(this.Offset + this.PageSize, this.Items.Count);
    public int Count  => Math.Max(this.EndOffset - this.Offset, 0);


    
}