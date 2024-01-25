using ChatGpt.Model;
using Newtonsoft.Json;
using System.Text;

public class ChatGptService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public ChatGptService(HttpClient httpClient, ChatGptConfig config)
    {
        _httpClient = httpClient;
        _apiKey = config.ApiKey;
    }
    public async Task<string> GetResponseAsync(string prompt)
    {
        try
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.openai.com/v1/engines/davinci-codex/completions"),
                Headers = { { "Authorization", $"Bearer {_apiKey}" } },
                Content = new StringContent(JsonConvert.SerializeObject(new { prompt = prompt }), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

            return result.choices[0].text;
        }
        catch (HttpRequestException ex)
        {
            // Log detailed error information
            // For example, log ex.Message and any relevant response details
            throw;
        }
    }

}
