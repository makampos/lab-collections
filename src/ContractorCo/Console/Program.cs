using Console;
using Models;
using Models.Common;
using static System.Console;

try
{
    // Linear sequence
    Workers.TestData.ToGrid(500, 2).WriteLines();
    
    using IEnumerator<Worker> shuffler = Workers.TestData.BeginShuffle();
    
    for (int i = 0; i < 5; i++)
    {
        shuffler.Iterate(). Take(5).ToGrid(500, 2).WriteLines();
        shuffler.Reset();
    }


} catch(Exception e)
{
    WriteLine($"ERROR: {e.Message}");
}


