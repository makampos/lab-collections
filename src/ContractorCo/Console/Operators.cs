namespace Console;
using static System.Console;

internal static class Operators
{
    public static void WriteLines(this IEnumerable<string> lines)
    {
        foreach (string line in lines)
        {
            WriteLine(line);
        }
    }
}