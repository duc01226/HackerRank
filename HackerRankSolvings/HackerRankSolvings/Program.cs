using HackerRankSolvings;
using HackerRankSolvings.Challenges;
using HackerRankSolvings.Challenges.WarmUp;

while (true)
{
    var allChallenges = ChallengesHelper.GetAllChallenges();

    Console.WriteLine("Choose Your HackerRank Challenge by typing the exact name of the Challenge below:");
    allChallenges.ForEach(challenge => Console.WriteLine(challenge.Name));

    Console.WriteLine("\nType your Challenge name you want to run:");

    var selectedChallengeName = Console.ReadLine();

    Console.WriteLine();
    try
    {
        var matchedChallenge = allChallenges.FirstOrDefault(p => p.Name == selectedChallengeName);

        if (matchedChallenge != null)
        {
            matchedChallenge.Main(args);
        }
        else
        {
            Console.WriteLine("The test name is invalid.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine();
        Console.WriteLine(e);
    }
    

    Console.WriteLine("\nDo you want to exit (y/n):");
    if (Console.ReadLine() == "y") 
        break;
    else
        Console.WriteLine();
}
