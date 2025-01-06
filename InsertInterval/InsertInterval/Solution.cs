namespace InsertInterval
{
    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var output = new List<int[]>();
            var newIntervalAdded = false;

            for (int i = 0; i < intervals.Length; i++)
            {
                var currentInterval = intervals[i];

                if (newInterval[0] > currentInterval[1] || newInterval[1] < currentInterval[0])
                {
                    // no merge is required

                    if (!newIntervalAdded && newInterval[1] < currentInterval[0])
                    {
                        output.Add(newInterval);
                        newIntervalAdded = true;
                    }

                    output.Add(currentInterval);
                }
                else
                {
                    newInterval[0] = Math.Min(newInterval[0], currentInterval[0]);
                    newInterval[1] = Math.Max(newInterval[1], currentInterval[1]);
                }
            }

            if (!newIntervalAdded)
            {
                output.Add(newInterval);
            }

            return output.ToArray();
        }
    }

}
