using Felix.Tools.Logger;

namespace Felix.Tools.Jobs
{
    class KeepGlowWorking : IJob
    {
        readonly ILogger logger;
        const string url = "https://localhost/Glow/dev/login";

        public KeepGlowWorking()
        {
            logger = AppContext.CreateLogger(typeof(KeepGlowWorking));
        }
        public Task OnStart(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(async () =>
            {
                await KeepVisitGlow(cancellationToken);
            }, TaskCreationOptions.LongRunning);
        }

        async Task KeepVisitGlow(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                VisitGlow(cancellationToken);
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        async void VisitGlow(CancellationToken cancellationToken)
        {
            try
            {
                using (var hc = new HttpClient())
                {
                    var req = new HttpRequestMessage(HttpMethod.Get, url);
                    await hc.SendAsync(req, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                logger.Append($"Exception when visiting {url}: {ex.ToString()}");
            }
        }
    }
}
