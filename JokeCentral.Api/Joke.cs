namespace JokeCentral.Api
{
    public class Joke
    {
        public string Text { get; set; }

        public Joke(string text)
        {
            this.Text = text;
        }
    }
}