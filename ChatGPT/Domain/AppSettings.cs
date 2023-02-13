namespace ChatGPT.Domain
{
	public class AppSettings
	{
		public ChatGPTSettings ChatGPT { get; set; }
	}

	public class ChatGPTSettings
	{
		public string OpenAIUrl { get; set; }
		public string OpenAIToken { get; set; }
		public string OpenAIEndpoint_Completions { get; set; }
	}
}