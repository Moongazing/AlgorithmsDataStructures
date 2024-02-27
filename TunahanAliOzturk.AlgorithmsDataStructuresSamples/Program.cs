using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace TunahanAliOzturk.AlgorithmsDataStructuresSamples;

public class Questions
{
    #region Contains Duplicate 
    /*Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.*/
    bool ContainsDuplicate(int[] nums)
    {
        if (nums == null || nums.Length < 2)
        {
            return false;
        }

        HashSet<int> seen = [];

        foreach (int num in nums)
        {
            if (!seen.Add(num))
            {
                return true;
            }
        }

        return false;
    }

    #endregion 
    #region Valid Anagram
    /*Given two strings s and t, return true if t is an anagram of s, and false otherwise. An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.*/

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        Dictionary<char, int> charCounts = [];

        foreach (char c in s)
        {
            if (charCounts.TryGetValue(c, out int value))
            {
                charCounts[c] = ++value;
            }
            else
            {
                charCounts[c] = 1;
            }
        }
        foreach (char c in t)
        {
            if (!charCounts.TryGetValue(c, out int value))
            {
                return false; 
            }
            charCounts[c] = --value;
            if (value < 0)
            {
                return false; 
            }
        }
        return true;
    }
    #endregion
    #region Two Sum
    /*Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    You may assume that each input would have exactly one solution, and you may not use the same element twice.
    You can return the answer in any order.*/


    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> indexMap = [];

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (indexMap.TryGetValue(complement, out int value))
            {
                return [value, i];
            }

            if (!indexMap.ContainsKey(nums[i]))
            {
                indexMap[nums[i]] = i;
            }
        }

        throw new ArgumentException("No two sum solution");
    }
}

    #endregion
