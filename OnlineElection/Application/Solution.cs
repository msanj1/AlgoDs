namespace Application;

public class Solution
{
    private readonly Dictionary<int, int> candidateVotes = new(); // {0:0, 1:0}
    private readonly int[] times;
    private readonly int[] winners;

    public Solution(int[] persons, int[] times)
    {
        //persons = 0, 1, 1, 0, 0, 1, 0 
        //times = 0, 5, 10, 15, 20, 25, 30

        for (var i = 0; i < persons.Length; i++) // C = Candidates = O(C)
        {
            var currentCandidate = persons[i];
            candidateVotes.TryAdd(currentCandidate, 0);
        }

        winners = new int[times.Length];
        this.times = times;
        for (var i = 0; i < times.Length; i++) // T = Voting Times O(T)
        {
            //0, 5, 10, 15, 20, 25, 30
            var votingTime = times[i]; //5
            var personVoting = persons[i]; //1

            candidateVotes[personVoting]++;

            if (i == 0)
            {
                winners[i] = personVoting;
            }
            else
            {
                var previousWinner = winners[i - 1];
                var previousWinnerVoteCount = candidateVotes[previousWinner];
                if (previousWinnerVoteCount <= candidateVotes[personVoting])
                    winners[i] = personVoting;
                else
                    winners[i] = previousWinner;
            }
        }

        //O(T + C)
    }

    public int Q(int t) //O(Log(T))
    {
        var left = 0;
        var right = times.Length - 1;
        var index = -1;

        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (times[mid] == t)
            {
                index = mid;
                break;
            }

            if (times[mid] < t)
            {
                index = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        if (index == -1) return index;

        return winners[index];
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */