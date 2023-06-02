namespace DHA_Code_Test_Backend.Models
{
	public class AnswerModel
	{
		public int QuestionAnswerId{ get;set; }
		public int AnswerIndex { get;set; }
		public string[] Options { get; set; } = null!;
		public AnswerModel(int questionAnswerId, string[] options, int answerIndex)
		{
			this.QuestionAnswerId = questionAnswerId;
			this.AnswerIndex = answerIndex;
			this.Options = options;
		}
	}
}
