namespace DHA_Code_Test_Backend.Models
{
	public class QuestionAnswerNotFoundException : Exception
	{
		public QuestionAnswerNotFoundException(string? message) : base(message) { }
	}
	public class DuplicatedQuestionAnswerException : Exception
	{
		public DuplicatedQuestionAnswerException(string? message) : base(message) { }
	}
}
