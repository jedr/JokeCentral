using System.Diagnostics;
using System.Net.Http;

namespace OpenTelemetryExtensions.HttpClient
{
    public class ActivityNameEnricher
    {
        public static void Enrich(Activity activity, string eventName, object rawObject)
        {
            if (eventName == "OnStartActivity")
            {
                if (rawObject is HttpRequestMessage request)
                {
                    activity.DisplayName = request.RequestUri.AbsolutePath;
                }
            }
        }
    }
}
