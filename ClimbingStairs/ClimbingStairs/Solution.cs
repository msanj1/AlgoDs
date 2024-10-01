namespace ClimbingStairs
{
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            var steps = new int[n + 1];
            steps[steps.Length - 1] = 1;

            for (int i = n - 1; i >= 0; i--)
            {
                var distinctWaysToClimb = 0;
                var currentStep = i;

                var next1Step = currentStep + 1;

                var next2Steps = currentStep + 2;

                if (next1Step <= n)
                {
                    distinctWaysToClimb += steps[next1Step];
                }

                if (next2Steps <= n)
                {
                    distinctWaysToClimb += steps[next2Steps];
                }

                steps[i] = distinctWaysToClimb;
            }

            return steps[0];
        }
    }

}
