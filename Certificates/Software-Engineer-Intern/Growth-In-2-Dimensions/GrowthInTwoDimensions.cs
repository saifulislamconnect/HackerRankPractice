namespace HackerRankPractice.Certificates.Software_Engineer_Intern.Growth_In_2_Dimensions;

public class GrowthInTwoDimensions
{
    /*
     * Complete the 'countMax' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts STRING_ARRAY upRight as parameter.
     */

    public static long countMax(List<string> upRight)
    {
        var minRow = long.MaxValue;
        var minCol = long.MaxValue;

        // Find the minimum row and column values
        foreach (var coordinate in upRight)
        {
            var parts = coordinate.Split(' ');
            var r = long.Parse(parts[0]);
            var c = long.Parse(parts[1]);

            minRow = Math.Min(minRow, r);
            minCol = Math.Min(minCol, c);
        }

        // The maximal value will occur at the intersection of minRow and minCol
        return minRow * minCol;
    }
    
    public static void EntryMethod()
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int upRightCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> upRight = new List<string>();

        for (int i = 0; i < upRightCount; i++)
        {
            string upRightItem = Console.ReadLine();
            upRight.Add(upRightItem);
        }

        long result = countMax(upRight);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}