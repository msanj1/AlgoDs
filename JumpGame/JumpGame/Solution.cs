using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JumpGame
{
    public class Solution
    {
        public bool CanJumpWithRecursion(int[] nums) //n = average size of steps available per floor, c = number of floor O(n ^ c)
        {
            return JumpWithRecursion(nums, 0, nums.Length - 1);
        }

        private bool JumpWithRecursion(int[] nums, int currentIndex, int indexToReach)
        {
            if (currentIndex == indexToReach)
            {
                return true;
            }

            var maxJumpsAvailable = nums[currentIndex];

            for (int i = 1; i <= maxJumpsAvailable; i++)
            {
                var potentialIndex = currentIndex + i;
                var reachedIndex = JumpWithRecursion(nums, potentialIndex, indexToReach);
                if (reachedIndex)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanJumpWithDP(int[] nums) //n = average size of steps available per floor, c = number of floor O(c ^ 2)
        {
            var cache = new Dictionary<int, bool>();
            return JumpWithDP(nums, 0, nums.Length - 1, cache);
        }

        private bool JumpWithDP(int[] nums, int currentIndex, int indexToReach, Dictionary<int, bool> cache)
        {
            if (cache.ContainsKey(currentIndex))
            {
                return cache[currentIndex];
            }

            if (currentIndex == indexToReach)
            {
                return true;
            }

            var maxJumpsAvailable = nums[currentIndex];

            for (int i = 1; i <= maxJumpsAvailable; i++)
            {
                var potentialIndex = currentIndex + i;
                var reachedIndex = JumpWithDP(nums, potentialIndex, indexToReach, cache);
                if (reachedIndex)
                {
                    cache[currentIndex] = true;
                    return true;
                }
            }

            cache[currentIndex] = false;
            return false;
        }

        public bool CanJumpGreedy(int[] nums) //n = average size of steps available per floor, c = number of floor O(n)
        {
            int goal = nums.Length - 1;

            for(int i= nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] + i >= goal)
                {
                    goal = i;
                }
            }

            return goal == 0;
        }
    }

}
