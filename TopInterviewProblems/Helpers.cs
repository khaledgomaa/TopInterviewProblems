namespace TopInterviewProblems
{
    public static class Helpers
    {
        static readonly char[] viowels = ['a', 'e', 'i', 'o', 'u'];

        public static bool IsVowel(this char ch)
            => Array.Exists(viowels, c => c == ch);
    }
}
