

//https://www.hackerrank.com/interview/interview-preparation-kit/warmup/challenges

using System.Diagnostics;
using HackerRankSolvings.Challenges.Abstraction;

namespace HackerRankSolvings.Challenges.WarmUp
{
    public class JumpingOnTheClouds : BaseChallenge
    {
        public const string Description =
            @"There is a new mobile game that starts with consecutively numbered clouds. Some of the clouds are thunderheads and others are cumulus. The player can jump on any cumulus cloud having a number that is equal to the number of the current cloud plus 1 or 2. The player must avoid the thunderheads. Determine the minimum number of jumps it will take to jump from the starting postion to the last cloud. It is always possible to win the game.

For each game, you will get an array of clouds numbered 0 if they are safe or 1 if they must be avoided.

Example

Index the array from 0....6. The number on each cloud is its index in the list so the player must avoid the clouds at indices 1 and 5. They could follow these two paths: 0=>2=>4=>6 or 0=>2=>3=>4=>6. The first path takes 3 jumps while the second takes 4. Return 3.

Function Description
Complete the jumpingOnClouds function in the editor below.
jumpingOnClouds has the following parameter(s):
int c[n]: an array of binary integers

Returns
int: the minimum number of jumps required

Input Format
The first line contains an integer n, the total number of clouds. The second line contains n space-separated binary integers describing clouds c[i] where 0 <= i < n.

Output Format
Print the minimum number of jumps needed to win the game.

Sample Input 0
7
0 0 1 0 0 1 0

Sample Output 0
4

Explanation 0:
The player must avoid c[2] and c[5]. The game can be won with a minimum of 4 jumps:

Sample Input 1
6
0 0 0 0 1 0

Sample Output 1
3

Explanation 1:
The only thundercloud to avoid is c[4]. The game can be won in 3 jumps:";

        public override void Main(string[] args)
        {
            Console.WriteLine(Description);
            Console.WriteLine();

            Console.WriteLine("\nInput an array of binary integers to represent cloud to jump or avoid(Ex: 0 1 0 0 1 0 1):");
            var c = Console.ReadLine()?.TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList() ?? new List<int>();

            var result = Result.JumpingOnClouds(c);

            Console.WriteLine($"\nThe minimum number of jumps required is : {result}");
        }

        class Result
        {
            public const int MaxJumpStepDistance = 2;
            public const int MustAvoidCloud = 1;

            /*
             * Complete the 'jumpingOnClouds' function below.
             *
             * The function is expected to return an INTEGER.
             * The function accepts INTEGER_ARRAY c as parameter.
             */
            public static int JumpingOnClouds(List<int> clouds)
            {
                var numberOfJumpsCounter = 0;
                int currentCloudIndexPositionIndicator = 0;

                while (currentCloudIndexPositionIndicator < clouds.Count - 1)
                {
                    var currentMaxJumpDistance = currentCloudIndexPositionIndicator + MaxJumpStepDistance < clouds.Count
                        ? MaxJumpStepDistance
                        : clouds.Count - currentCloudIndexPositionIndicator - 1;

                    var newTryJumpCloudIndexPosition = TryJump(clouds, currentMaxJumpDistance, currentCloudIndexPositionIndicator);

                    // If can't not jump anymore, stay at the same position
                    if (newTryJumpCloudIndexPosition == currentCloudIndexPositionIndicator)
                    {
                        break;
                    }
                    else
                    {
                        currentCloudIndexPositionIndicator = newTryJumpCloudIndexPosition;
                        numberOfJumpsCounter++;
                    }
                }


                return numberOfJumpsCounter;
            }

            private static int TryJump(List<int> clouds, int currentMaxJumpDistance, int currentCloudIndexPositionIndicator)
            {
                for (int testJumpDistance = currentMaxJumpDistance; testJumpDistance > 0; testJumpDistance--)
                {
                    var nextTestJumpCloudIndexPosition = currentCloudIndexPositionIndicator + testJumpDistance;

                    if (clouds[nextTestJumpCloudIndexPosition] != MustAvoidCloud)
                    {
                        return nextTestJumpCloudIndexPosition;
                    }
                }

                return currentCloudIndexPositionIndicator;
            }
        }
    }
}
