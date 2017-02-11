public static async Task Run(TimerInfo myTimer, TraceWriter log)
{
    using (var client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync("http://jotto.seanhokanson.org/api/games/latest/");
        if (response.IsSuccessStatusCode)
        {
            log.Info("ping successful");
        }
        else
        {
            log.Error($"ping failed with status code {response.StatusCode}");
        }
    }    
}