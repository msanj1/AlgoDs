namespace ClimbingStairs
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int previousPreviousMax = 0;
            int previousMax = nums[0];
            for (int i = 1; i < nums.Length; i++)
            { //[1,1,3,*3]
                var currentMoneyInHouse = nums[i];

                var temp = previousMax;

                previousMax = Math.Max(currentMoneyInHouse + previousPreviousMax, previousMax);
                previousPreviousMax = temp;

            }

            return previousMax;
        }
    }
}
