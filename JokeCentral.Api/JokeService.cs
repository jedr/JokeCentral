using System.Threading.Tasks;

namespace JokeCentral.Api
{
    public class JokeService : IJokeService
    {
        private IcndbCom icndbCom = new IcndbCom();

        public Task<Joke> GetJokeAsync()
        {
            return this.icndbCom.GetJokeAsync();
        }
    }
}
