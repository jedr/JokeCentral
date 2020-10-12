using System.Threading.Tasks;

namespace JokeCentral.Api
{
    public interface IJokeService
    {
        Task<Joke> GetJokeAsync();
    }
}
