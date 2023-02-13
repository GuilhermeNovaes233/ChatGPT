using Microsoft.AspNetCore.Mvc;
using ChatGPT.Services;
using ChatGPT.Domain;

namespace ChatGPT.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ChatGptController : ControllerBase
	{
		private readonly ILogger<ChatGptController> _logger;
		private readonly IOpenAIService _openAIService;

		public ChatGptController(ILogger<ChatGptController> logger, IOpenAIService openAIService)
		{
			_logger = logger;
			_openAIService = openAIService;
		}

		[HttpPost]
		public async Task<string> Post([FromBody] ChatGPTRequesModel requesModel)
		{
			var response = await _openAIService.AskQuestion(requesModel.Message);

			return response;
		}
	}
}