using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;

namespace JokeCentral.Tests
{
    public class ApiControllerTest : IClassFixture<WebApplicationFactory<JokeCentral.Startup>>
    {
        private readonly WebApplicationFactory<JokeCentral.Startup> factory;

        public ApiControllerTest(WebApplicationFactory<JokeCentral.Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async void GetJoke()
        {
            var client = this.factory.CreateClient();

            var response = await client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            var responseText = await response.Content.ReadAsStringAsync();
            Assert.Contains("Chuck", responseText);
        }
    }
}
