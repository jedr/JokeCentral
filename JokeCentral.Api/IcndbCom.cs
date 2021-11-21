using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeCentral.Api
{
    public class IcndbCom : IJokeService
    {
        private HttpClient httpClient;

        public IcndbCom()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<Joke> GetJokeAsync()
        {
            var responseString = await this.httpClient.GetStringAsync("http://api.icndb.com/jokes/random");
            using (var responseJson = JsonDocument.Parse(responseString))
            {
                string jokeText = responseJson.RootElement.GetProperty("value").GetProperty("joke").GetString();
                return new Joke(jokeText);
            }
        }
    }
}
