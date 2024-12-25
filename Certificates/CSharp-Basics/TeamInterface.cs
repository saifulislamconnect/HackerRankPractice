namespace HackerRankPractice.Certificates.CSharp_Basics;

public class TeamInterface
{
    public class Team
    {
        public string teamName;
        public int noOfPlayers;
        
        public Team(string tName, int nPlayers)
        {
            teamName = tName;
            noOfPlayers = nPlayers;
        }

        public void AddPlayer(int count)
        {
            noOfPlayers += count;
        }
        public bool RemovePlayer(int count)
        {
            noOfPlayers -= count;
            return noOfPlayers >= 0;
        }
    }

    public class Subteam : Team
    {
        public Subteam(string tName, int nPlayers) : base(tName, nPlayers)
        {
            teamName = tName;
            noOfPlayers = nPlayers;
        }

        public void ChangeTeamName(string name)
        {
            teamName = name;
        }
    }

    public static void EntryMethod()
    {
        // Here goes all the main method contents and test cases
    }
}
