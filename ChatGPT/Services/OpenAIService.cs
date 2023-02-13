using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using ChatGPT.Domain;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace ChatGPT.Services
{
	public class OpenAIService : IOpenAIService
	{
		
		JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
		private readonly AppSettings _settings;


		private readonly HttpClient _httpClient;

		public OpenAIService(HttpClient httpClient, IOptions<AppSettings> settings)
		{
			//client = new HttpClient();
			//client.BaseAddress = new Uri(APIConstants.OpenAIUrl);

			//_settings = settings;
			_httpClient = httpClient;

			_httpClient.BaseAddress = new Uri(settings.Value.ChatGPT.OpenAIUrl);

			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.Value.ChatGPT.OpenAIToken);// APIConstants.OpenAIToken);
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<string> AskQuestion(string query)
		{
			var completion = new CompletionRequest()
			{
				Prompt = query
			};

			var body = JsonSerializer.Serialize(completion);
			var content = new StringContent(body, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("v1/completions", content);

			if (response.IsSuccessStatusCode)
			{
				var data = await response.Content.ReadFromJsonAsync<CompletionResponse>(options);
				return data?.Choices?.FirstOrDefault().Text;
			}

			return default;
		}
	}
}