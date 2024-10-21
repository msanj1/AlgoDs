namespace UniquePaths
{
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            var uniquePath = new int[m][]; //m row, n column

            for (int i = 0; i < uniquePath.Length; i++)
            {
                uniquePath[i] = new int[n];
            }

            uniquePath[m - 1][n - 1] = 1;

            for (int row = m - 1; row >= 0; row--)
            {
                for (int col = n - 1; col >= 0; col--)
                {

                    if (row == m - 1 && col == n - 1)
                    {
                        continue;
                    }

                    var downPosition = new int[] { row + 1, col };
                    var rightPosition = new int[] { row, col + 1 };
                    var totalUniquepaths = 0;
                    if (downPosition[0] <= m - 1)
                    {
                        //we can to down
                        totalUniquepaths += uniquePath[downPosition[0]][downPosition[1]];
                    }

                    if (rightPosition[1] <= n - 1)
                    {
                        //we can go right
                        totalUniquepaths += uniquePath[rightPosition[0]][rightPosition[1]];
                    }

                    uniquePath[row][col] = totalUniquepaths;
                }
            }

            return uniquePath[0][0];
        }
    }

}
