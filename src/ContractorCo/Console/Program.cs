using Console;
using Models;
using Models.Common;
using static System.Console;

try
{
    // Linear sequence
    Workers.TestData.ToGrid(500, 2).WriteLines();
    
    
} catch(Exception e)
{
    WriteLine($"ERROR: {e.Message}");
}


