namespace HackerRankSolvings.Challenges.Abstraction
{
    public abstract class BaseChallenge
    {
        public string Name => GetType().Name;

        public abstract void Main(string[] args);
    }
}
