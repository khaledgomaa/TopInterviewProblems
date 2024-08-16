using TopInterviewProblems;

Console.WriteLine(IsValidSudoku([['5', '3', '.', '.', '7', '.', '.', '.', '.']
,
    ['6', '.', '.', '1', '9', '5', '.', '.', '.']
,
    ['.', '9', '8', '.', '.', '.', '.', '6', '.']
,
    ['8', '.', '.', '.', '6', '.', '.', '.', '3']
,
    ['4', '.', '.', '8', '.', '3', '.', '.', '1']
,
    ['7', '.', '.', '.', '2', '.', '.', '.', '6']
,
    ['.', '6', '.', '.', '.', '.', '2', '8', '.']
,
    ['.', '.', '.', '4', '1', '9', '.', '.', '5']
,
    ['.', '.', '.', '.', '8', '.', '.', '7', '9']]));

static bool IsValidSudoku(char[][] board)
{
    HashSet<string> chars = new();

    for (int r = 0; r < board.Length; r++)
    {
        for (int c = 0; c < board.Length; c++)
        {
            if (char.IsDigit(board[r][c]))
            {
                if (!chars.Add(board[r][c] + " in row " + r) ||
                    !chars.Add(board[r][c] + " in column " + c) ||
                    !chars.Add(board[r][c] + " in box " + r / 3 + "-" + c / 3))
                {
                    return false;
                }
            }
        }

        chars.Clear();
    }

    return true;
}

static int MinSubArrayLen(int target, int[] nums)
{
    int count = 0;
    int min = int.MaxValue;
    int start = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        count += nums[i];

        while (count >= target)
        {
            min = Math.Min(min, i - start + 1);
            count -= nums[start];
            start++;
        }
    }

    return min == int.MaxValue ? 0 : min;
}

static int MaxVowels(string s, int k)
{
    int count = CountVowels(s, 0, k);
    int maxCount = count;

    for (int i = 0; i < s.Length - k; i++)
    {
        if (s[i].IsVowel())
        {
            count--;
        }

        if (s[i + k].IsVowel())
            count++;

        maxCount = Math.Max(maxCount, count);
    }

    return maxCount;
}

static int CountVowels(string s, int start, int k)
{
    int count = 0;
    for (int i = start; i < start + k; i++)
    {
        if (s[i].IsVowel())
            count++;
    }

    return count;
}

static bool IsPalindrome(string s)
{
    if (string.IsNullOrWhiteSpace(s))
    {
        return true;
    }

    int l = 0, h = s.Length - 1;

    while (l < h)
    {
        if (!char.IsLetterOrDigit(s[l]))
        {
            l++;
        }
        else if (!char.IsLetterOrDigit(s[h]))
        {
            h--;
        }
        else if (char.ToUpperInvariant(s[l++]) != char.ToUpperInvariant(s[h--]))
        {
            return false;
        }
    }

    return true;
}

static void Merge(int[] nums1, int m, int[] nums2, int n)
{
    int p1 = m - 1, p2 = n - 1, index = m + n - 1;

    while (p2 >= 0)
    {
        if (p1 >= 0 && nums1[p1] >= nums2[p2])
        {
            nums1[index--] = nums1[p1--];
        }
        else
        {
            nums1[index--] = nums2[p2--];
        }
    }
}

static void MergeWithQueue(int[] nums1, int m, int[] nums2, int n)
{
    int p1 = 0, p2 = 0, index = 0;
    Queue<int> temp = new();

    while (p1 < m && p2 < n)
    {
        if (nums1[p1] < nums2[p2])
        {
            p1++;
        }

        else if (nums1[p1] > nums2[p2])
        {
            temp.Enqueue(nums1[p1]);

            nums1[p1] = nums2[p2]; ;

            p1++;
            p2++;
        }

        index++;
    }

    while (temp.Count != 0)
    {
        nums1[index++] = temp.Dequeue();
    }

    while (p2 < n)
    {
        nums1[index++] = nums2[p2++];
    }
}