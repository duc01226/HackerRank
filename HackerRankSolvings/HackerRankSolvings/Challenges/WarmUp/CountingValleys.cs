

//https://www.hackerrank.com/interview/interview-preparation-kit/warmup/challenges

using System.Diagnostics;
using HackerRankSolvings.Challenges.Abstraction;

namespace HackerRankSolvings.Challenges.WarmUp
{
    public class CountingValleys : BaseChallenge
    {
        public const string Description =
            @"An avid hiker keeps meticulous records of their hikes. During the last hike that took exactly  steps, for every step it was noted if it was an uphill, U, or a downhill, D step. Hikes always start and end at sea level, and each step up or down represents a  unit change in altitude. We define the following terms:

A mountain is a sequence of consecutive steps above sea level, starting with a step up from sea level and ending with a step down to sea level.
A valley is a sequence of consecutive steps below sea level, starting with a step down from sea level and ending with a step up to sea level.
Given the sequence of up and down steps during a hike, find and print the number of valleys walked through.

Example

 steps = 8 path = [DDUUUUDD]

The hiker first enters a valley 2 units deep. Then they climb out and up onto a mountain 2 units high. Finally, the hiker returns to sea level and ends the hike.

Function Description

Complete the countingValleys function in the editor below.

countingValleys has the following parameter(s):

int steps: the number of steps on the hike
string path: a string describing the path

Returns

int: the number of valleys traversed
Input Format

The first line contains an integer steps, the number of steps in the hike.
The second line contains a single string path, of steps characters that describe the path.

Sample Input
8
UDDDUDUU

Sample Output
1";

        public override void Main(string[] args)
        {
            Console.WriteLine(Description);
            Console.WriteLine();

            Console.WriteLine("Input the number of steps:");
            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("\nInput the path (Example: UDDDUDUU):");
            string path = Console.ReadLine();

            int result = Result.CountingValleys(steps, path);

            Console.WriteLine($"\nThe number of valleys traversed is : {result}");
        }

        class Result
        {
            public const char StepUp = 'U';
            public const char StepDown = 'D';

            /*
             * Complete the 'countingValleys' function below.
             *
             * The function is expected to return an INTEGER.
             * The function accepts following parameters:
             *  1. INTEGER steps
             *  2. STRING path
             */
            public static int CountingValleys(int stepsCount, string path)
            {
                var traversedValleysCounter = 0;
                var seaLevelIndicator = 0;

                foreach (var newStep in path)
                {
                    seaLevelIndicator = CalculateNewStepSeaLevel(newStep, previousStepSeaLevel: seaLevelIndicator);

                    if (IsJustStepUpToTheSeaLevelGround(newStepSeaLevel: seaLevelIndicator, newStep))
                    {
                        traversedValleysCounter += 1;
                    }
                }

                return traversedValleysCounter;
            }

            private static int CalculateNewStepSeaLevel(char newStep, int previousStepSeaLevel)
            {
                return newStep switch
                {
                    StepUp => previousStepSeaLevel - 1,
                    StepDown => previousStepSeaLevel + 1,
                    _ => throw new ArgumentException($"Step {newStep} is invalid. Must be {StepUp} or {StepDown}")
                };
            }

            private static bool IsJustStepUpToTheSeaLevelGround(int newStepSeaLevel, char newStep)
            {
                return newStepSeaLevel == 0 && newStep == StepUp;
            }
        }
    }
}
