namespace HackerRankPractice.Certificates.Problem_Solving_Basic.Nearly_Similar_Rectangles;

class NearlySimilarRectanglesSolution
{
    // Helper method to calculate GCD
    private static long Gcd(long a, long b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }

    public static long nearlySimilarRectangles(List<List<long>> sides)
    {
        // Dictionary to store the normalized ratios and their counts
        var ratioCounts = new Dictionary<(long, long), long>();

        foreach (var side in sides)
        {
            var width = side[0];
            var height = side[1];

            // Normalize the ratio by dividing both dimensions by their GCD
            var gcd = Gcd(width, height);
            
            // Tuples for storing width:height ratio
            var normalizedRatio = (width / gcd, height / gcd); 

            // Increment the count of this ratio in the dictionary
            ratioCounts[normalizedRatio] = ratioCounts.GetValueOrDefault(normalizedRatio) + 1;
        }

        // Calculate the number of nearly similar rectangle pairs
        return ratioCounts.Values.Sum(count => count * (count - 1) / 2);
    }

    public static void EntryMethod()
    {
        // Here goes all the main method contents and test cases
        nearlySimilarRectangles(new List<List<long>>());
    }
}