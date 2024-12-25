namespace HackerRankPractice.Certificates.Problem_Solving_Intermediate.Task_Of_Pairing;

public class TaskOfPairing
{
    /*
     * Complete the 'taskOfPairing' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER_ARRAY freq as parameter.
     */
    public static long taskOfPairing(List<long> frequencies)
    {
        long numberOfPairs = 0;
        long remaining = 0;

        foreach (var currentFrequency in frequencies)
        {
            if (currentFrequency != 0)
            {
                // Calculate pairs from the current frequency and the remaining one
                if (remaining != 0)
                {
                    numberOfPairs += (currentFrequency + remaining) / 2;
                }
                else
                {
                    numberOfPairs += currentFrequency / 2;
                }

                // Update the remaining value if the sum is odd
                if ((currentFrequency + remaining) % 2 != 0)
                {
                    remaining = 1;
                }
                else
                {
                    remaining = 0;
                }
            }
            else
            {
                remaining = 0; // Reset remaining if current frequency is zero
            }
        }

        return numberOfPairs;
    }

    public static void EntryMethod()
    {
        // Here goes all the main method contents and test cases
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int freqCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> freq = new List<long>();

        for (int i = 0; i < freqCount; i++)
        {
            long freqItem = Convert.ToInt64(Console.ReadLine().Trim());
            freq.Add(freqItem);
        }

        long result = taskOfPairing(freq);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}