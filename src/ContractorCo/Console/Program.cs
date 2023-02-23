using Console;
using Models;
using Models.Common;
using Models.Common.Pagination;
using static System.Console;

try
{
    // Linear sequence

    #region Shuffle
    Workers.TestData.ToGrid(500, 2).WriteLines();
    
    using IEnumerator<Worker> shuffler = Workers.TestData.BeginShuffle();
    
    for (int i = 0; i < 5; i++)
    {
        shuffler.Iterate(). Take(5).ToGrid(500, 2).WriteLines();
        shuffler.Reset();
    }
    #endregion

   

} catch(Exception e)
{
    WriteLine($"ERROR: {e.Message}");
}


