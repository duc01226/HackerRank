using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankSolvings.Challenges.Abstraction;
using HackerRankSolvings.Challenges.WarmUp;

namespace HackerRankSolvings.Challenges
{
    public static class ChallengesHelper
    {
        public static List<BaseChallenge> GetAllChallenges()
        {
            return new List<BaseChallenge>()
            {
                new SalesByMatch(),
                new CountingValleys()
            };
        }
    }
}
