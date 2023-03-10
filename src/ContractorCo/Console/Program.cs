using Console;
using Models;
using Models.Collections;
using Models.Common;
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

    // IPaginated<Worker> pages =
    //     Workers.TestData.Replicate(50_000, .05F).Paginate(Worker.RateComparer, 112_000);
    //
    // Stopwatch pageTimer = Stopwatch.StartNew();
    // IEnumerator<IPage<Worker>> enumerator = pages.GetEnumerator();
    //
    // while (enumerator.MoveNext())
    // {
    //     IPage<Worker> page = enumerator.Current;
    //     PayRate rate = page.AveragePayRate();
    //     WriteLine($"Page #{page.Ordinal}: {page.Count}x{rate} [{pageTimer.Elapsed}]");
    //     pageTimer.Restart();
    //     break;
    // }

    #endregion

    #region Generics

    Workers.GetWorkers(40)
        .ToFullySortedList(worker => worker.HourlyRate)
        .ToGrid(120, 2)
        .WriteLines();

    #endregion
}
catch (Exception e)
{
    WriteLine($"ERROR: {e.Message}");
}


