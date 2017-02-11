#r "System.Net.Http"

using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;

public static async Task Run(TimerInfo myTimer, TraceWriter log)
{
    using (var client = new HttpClient())
    {
        var watch = new Stopwatch();
        watch.Start();
        HttpResponseMessage response = await client.GetAsync("http://jotto.seanhokanson.org/api/games/latest/");
        watch.Stop();
        if (response.IsSuccessStatusCode)
        {
            log.Info($"ping successful ({watch.ElapsedMilliseconds} ms)");
        }
        else
        {
            log.Error($"ping failed with status code {response.StatusCode} after {watch.ElapsedMilliseconds} ms");
        }
    }    
}