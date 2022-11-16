using System.Diagnostics;
using System.Net.Http;

namespace OpenTelemetryExtensions.HttpClient
{
    public class ActivityNameEnricher
    {
        public static void Enrich(Activity activity, HttpRequestMessage request)
        {
            activity.DisplayName = request.RequestUri.AbsolutePath;
        }
    }
}
