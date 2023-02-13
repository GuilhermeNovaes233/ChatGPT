namespace ChatGPT.Services
{
	public interface IOpenAIService
	{
		Task<string> AskQuestion(string query);
	}
}