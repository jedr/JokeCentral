namespace JokeCentral.Api
{
    public class JokeService
    {
        public Joke GetJoke()
        {
            return new Joke("You're not completely useless, you can always serve as a bad example.");
        }
    }
}
