namespace LongestCommonSubsequence
{
    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2) //Time and Space Complexity O(T*C)
        {
            var calculations = new int[text2.Length + 1][];

            for (int i = 0; i < calculations.Length; i++)
            {
                calculations[i] = new int[text1.Length + 1];
            }

            for (int row = calculations.Length - 2; row >= 0; row--)
            {
                for (int col = calculations[row].Length - 2; col >= 0; col--)
                {
                    if (text2[row] == text1[col])
                    {
                        calculations[row][col] = 1 + calculations[row + 1][col + 1];
                    }
                    else
                    {
                        calculations[row][col] = Math.Max(calculations[row + 1][col], calculations[row][col + 1]);
                    }
                }
            }

            return calculations[0][0];
        }
    }

}
