namespace Application;

public class Solution
{
    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        var result = Search(nums, 0, target, new List<int>());
        return result;
    }

    private List<List<int>> Search(int[] nums, int index, int target, List<int> progress)
    {
        var totalCount = progress.Sum();
        var output = new List<List<int>>();

        if (totalCount == target)
        {
            output.Add(new List<int>(progress));
            return output;
        }

        if (totalCount > target) return output;

        for (var i = index; i < nums.Length; i++)
        {
            var currentNumber = nums[i];
            progress.Add(currentNumber);
            var result = Search(nums, i, target, progress);

            if (result.Count > 0) output.AddRange(result);

            progress.RemoveAt(progress.Count - 1);
        }

        return output;
    }
}