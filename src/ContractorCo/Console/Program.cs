using System.Diagnostics;
using Models;
using Models.Common;
using Models.Common.Pagination;
using static System.Console;

try
{
    // Linear sequence

    #region Shuffle

    // Workers.TestData.ToGrid(500, 2).WriteLines();
    //
    // using IEnumerator<Worker> shuffler = Workers.TestData.BeginShuffle();
    //
    // for (int i = 0; i < 5; i++)
    // {
    //     shuffler.Iterate(). Take(5).ToGrid(500, 2).WriteLines();
    //     shuffler.Reset();
    // }
    #endregion

    #region Pagination

    IPaginated<Worker> pages =
        Workers.TestData.Paginate(Worker.RateComparer, 5);

    Stopwatch pageTimer = Stopwatch.StartNew();
    IEnumerator<IPage<Worker>> enumerator = pages.GetEnumerator();

    while (enumerator.MoveNext())
    {
        IPage<Worker> page = enumerator.Current;
        PayRate rate = page.AveragePayRate();
        WriteLine($"Page #{page.Ordinal}: {page.Count}x{rate} [{pageTimer.Elapsed}]");
        pageTimer.Restart();
    }

    #endregion
}
catch (Exception e)
{
    WriteLine($"ERROR: {e.Message}");
}


