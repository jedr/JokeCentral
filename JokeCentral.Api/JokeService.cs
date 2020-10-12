using System.Threading.Tasks;

namespace JokeCentral.Api
{
    public class JokeService : IJokeService
    {
        private ChuckNorrisIo chuckNorrisIo = new ChuckNorrisIo();

        public Task<Joke> GetJokeAsync()
        {
            return this.chuckNorrisIo.GetJokeAsync();
        }
    }
}
