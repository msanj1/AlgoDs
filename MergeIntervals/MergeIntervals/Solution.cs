namespace MergeIntervals
{
    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            var output = new List<int[]>();
            var orderedIntervals = intervals.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList(); //O(nlog(n))

            if (intervals.Length == 0 || intervals.Length == 1)
            {
                return intervals;
            }

            var currentInterval = orderedIntervals[0];
            for (int i = 1; i < orderedIntervals.Count; i++) // O(n)
            { //[[1,3],[1,5],[6,7]]

                var interval = orderedIntervals[i]; //[1,3]

                if (currentInterval[0] > interval[1] || currentInterval[1] < interval[0])
                {
                    // no overlap
                    output.Add(currentInterval);
                    currentInterval = interval;
                }
                else
                {
                    currentInterval[0] = Math.Min(currentInterval[0], interval[0]);
                    currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
                }
            }

            output.Add(currentInterval);

            return output.ToArray();
        }
    }

}
