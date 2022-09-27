using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeCentral.Api
{
    public class JokeService : IJokeService
    {
        private ChuckNorrisIo chuckNorrisIo = new ChuckNorrisIo();
        private IcndbCom icndbCom = new IcndbCom();

        public async Task<Joke> GetJokeAsync()
        {
            var jokeServices = new List<IJokeService>();
            jokeServices.Add(chuckNorrisIo);
            jokeServices.Add(icndbCom);

            var jokeCallsLinq = from jokeService in jokeServices select jokeService.GetJokeAsync();
            var jokeCalls = jokeCallsLinq.ToList();

            var jokes = new List<Joke>();
            var errors = new List<Exception>();

            while (jokeCalls.Any()) {
                var completedCall = await Task.WhenAny(jokeCalls);
                jokeCalls.Remove(completedCall);

                if (completedCall.Exception != null) {
                    errors.Add(completedCall.Exception);
                } else {
                    return completedCall.Result;
                }
            }
        
            if (errors.Any()) {
                throw errors.First();
            } else {
                throw new Exception("This is awkward. Couldn't retrieve any joke, but didn't get any errors either.");
            }
        }
    }
}
