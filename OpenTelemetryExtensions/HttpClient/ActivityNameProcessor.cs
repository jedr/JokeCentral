using System.Diagnostics;
using System.Net.Http;
using OpenTelemetry.Trace;

namespace OpenTelemetryExtensions.HttpClient
{
    public class ActivityNameProcessor : ActivityProcessor
    {
        public override void OnEnd(Activity activity)
        {
            var request = activity.GetCustomProperty("OTel.HttpHandler.Request") as HttpRequestMessage;
            if (request != null)
            {
                activity.DisplayName = request.RequestUri.AbsolutePath;
            }
        }
    }
}
