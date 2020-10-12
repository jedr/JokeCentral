using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeCentral.Api
{
    public class ChuckNorrisIo : IJokeService
    {
        private HttpClient httpClient;

        public ChuckNorrisIo()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<Joke> GetJokeAsync()
        {
            var responseString = await this.httpClient.GetStringAsync("https://api.chucknorris.io/jokes/random");
            using (var responseJson = JsonDocument.Parse(responseString))
            {
                string jokeText = responseJson.RootElement.GetProperty("value").GetString();
                return new Joke(jokeText);
            }
        }
    }
}
