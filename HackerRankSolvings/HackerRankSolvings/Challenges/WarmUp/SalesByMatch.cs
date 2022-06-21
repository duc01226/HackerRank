

//https://www.hackerrank.com/interview/interview-preparation-kit/warmup/challenges

using HackerRankSolvings.Challenges.Abstraction;

namespace HackerRankSolvings.Challenges.WarmUp
{
    public class SalesByMatch : BaseChallenge
    {
        public const string Description =
            @"There is a large pile of socks that must be paired by color. Given an array of integers representing the color of each sock, determine how many pairs of socks with matching colors there are.

Example
n = 7
ar = [1,2,1,2,1,3,2]

There is one pair of color 1 and one of color 2. There are three odd socks left, one of each color. The number of pairs is 2.

Function Description

Complete the sockMerchant function in the editor below.

sockMerchant has the following parameter(s):

int n: the number of socks in the pile
int ar[n]: the colors of each sock
Returns

int: the number of pairs
Input Format

The first line contains an integer n, the number of socks represented in ar.
The second line contains n space-separated integers, ar[i], the colors of the socks in the pile.";

        public override void Main(string[] args)
        {
            Console.WriteLine(Description);
            Console.WriteLine();

            Console.WriteLine("Input the number of socks in the pile:");
            int n = Convert.ToInt32(Console.ReadLine()?.Trim());

            Console.WriteLine("\nInput the colors of each sock (Example: 1 2 2 1 3 4 3):");
            var ar = Console.ReadLine()?.Trim().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList() ?? new List<int>();

            int result = Result.SockMerchant(n, ar);

            Console.WriteLine($"\nThe number of sock pairs result is : {result}");
        }

        class Result
        {
            public const int InititalAccumulatedSockPairsCounter = 0;

            /*
             * Complete the 'sockMerchant' function below.
             *
             * The function is expected to return an INTEGER.
             * The function accepts following parameters:
             *  1. INTEGER n
             *  2. INTEGER_ARRAY ar
             */

            public static int SockMerchant(int n, List<int> ar)
            {
                return ar
                    .GroupBy(sockType => sockType)
                    .Select(p => new
                    {
                        SockType = p.Key,
                        PairsCount = p.Count() / 2
                    })
                    .Aggregate(
                        seed: InititalAccumulatedSockPairsCounter,
                        (currentAccumulatedSockPairsCounter, sockTypeToPairsCount) => currentAccumulatedSockPairsCounter + sockTypeToPairsCount.PairsCount);
            }

        }
    }
}
