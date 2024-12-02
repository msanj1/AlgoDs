namespace MaximumSubArray
{
    public class Solution
    {
        //Kadane's Algorithm
        public int MaxSubArray(int[] nums)
        { //[-1]
            int maxValue = int.MinValue;

            int currentValue = 0;
            for (int i = 0; i < nums.Length; i++)
            {

                if (currentValue < 0)
                {
                    currentValue = 0;
                }

                currentValue += nums[i];

                maxValue = Math.Max(currentValue, maxValue);
            }

            return maxValue;
        }
    }
}