namespace HackerRankPractice.Certificates.Problem_Solving_Basic.Usernames_Changes;

class UsernamesChanges
{
    public static List<string> possibleChanges(List<string> usernames)
    {
        var result = new List<string>();
        foreach (var username in usernames)
        {
            var canChange = false;
            var maxChar = username[0];

            foreach (var letter in username)
            {
                if (maxChar > letter)
                {
                    canChange = true;
                    break;
                }

                maxChar = letter;
            }

            result.Add(canChange ? "YES" : "NO");
        }

        return result;
    }

    public static void EntryMethod()
    {
        // Here goes all the main method contents and test cases
        possibleChanges(new List<string>());
    }
}