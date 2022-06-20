

//https://www.hackerrank.com/interview/interview-preparation-kit/warmup/challenges

using System.Diagnostics;
using HackerRankSolvings.Challenges.Abstraction;

namespace HackerRankSolvings.Challenges.WarmUp
{
    public class RepeatedString : BaseChallenge
    {
        public const string Description =
            @"There is a string, s, of lowercase English letters that is repeated infinitely many times. Given an integer, , find and print the number of letter a's in the first n letters of the infinite string.

Example
s = 'abcac'
n = 10

The substring we consider is abcacabcac, the first 10 characters of the infinite string. There are 4 occurrences of a in the substring.

Function Description

Complete the repeatedString function in the editor below.

repeatedString has the following parameter(s):

s: a string to repeat
n: the number of characters to consider
Returns

int: the frequency of a in the substring
Input Format

The first line contains a single string, s.
The second line contains an integer, n.


Sample Input 0
aba
10

Sample Output 0
7

Explanation 0
The first n=10 letters of the infinite string are abaabaabaa. Because there are 7 a's, we return 7.";

        public override void Main(string[] args)
        {
            Console.WriteLine(Description);
            Console.WriteLine();

            Console.WriteLine("Input a string to repeat:");
            var s = Console.ReadLine().Trim();

            Console.WriteLine("\nInput the number of characters to consider:");
            long n = Convert.ToInt64(Console.ReadLine().Trim());

            var result = Result.RepeatedString(s, n);

            Console.WriteLine($"\nThe frequency of 'a' in the substring is : {result}");
        }

        class Result
        {
            /*
             * Complete the 'repeatedString' function below.
             *
             * The function is expected to return a LONG_INTEGER.
             * The function accepts following parameters:
             *  1. STRING s
             *  2. LONG_INTEGER n
             */
            public static long RepeatedString(string repeatStr, long considerCharacterLength)
            {
                if (considerCharacterLength <= repeatStr.Length)
                    return repeatStr.Substring(0, (int)considerCharacterLength).Count(character => character == 'a');
                else
                {
                    var countOfAInRepeatStr = repeatStr.Count(character => character == 'a');

                    if (countOfAInRepeatStr == 0)
                        return 0;
                    else
                    {
                        var repeatStrTimes = considerCharacterLength / repeatStr.Length;
                        var remainStrAfterRepeatLength = considerCharacterLength % repeatStr.Length;

                        return countOfAInRepeatStr * repeatStrTimes +
                               repeatStr.Substring(0, (int)remainStrAfterRepeatLength).Count(character => character == 'a');
                    }
                }
            }
        }
    }
}
