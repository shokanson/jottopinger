//#r "System.Net.Http"

using System.Diagnostics;
//using System.Threading.Tasks;
//using System.Net.Http;

public static async Task Run(TimerInfo myTimer, TraceWriter log)
{
    var watch = Stopwatch.StartNew();
    using (var client = new HttpClient())
    {
        long preRequest = watch.ElapsedMilliseconds;
        HttpResponseMessage response = await client.GetAsync("http://jotto.seanhokanson.org/api/games/latest/");
        long postRequest = watch.ElapsedMilliseconds;
        if (response.IsSuccessStatusCode)
        {
            log.Info($"ping successful ({postRequest-preRequest} ms)");
        }
        else
        {
            log.Error($"ping failed with status code {response.StatusCode} after {postRequest-preRequest} ms");
        }
    }
    log.Info($"total time: {watch.ElapsedMilliseconds} ms");
}