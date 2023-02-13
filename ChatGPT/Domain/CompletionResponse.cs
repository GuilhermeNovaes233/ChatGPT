namespace ChatGPT.Domain
{
	public class CompletionResponse
	{
		public string Id { get; set; }
		public List<Choice> Choices { get; set; }
	}

	public class Choice
	{
		public string Text { get; set; }
		public int Index { get; set; }
	}
}