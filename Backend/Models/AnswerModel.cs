namespace DHA_Code_Test_Backend.Models
{
	public class AnswerModel
	{
		public int QuestionAnswerId{ get;set; }
		public int AnswerIndex { get;set; }
		public OptionModel[] Options { get; set; } = null!;
		public AnswerModel(int questionAnswerId, OptionModel[] options, int answerIndex)
		{
			this.QuestionAnswerId = questionAnswerId;
			this.AnswerIndex = answerIndex;
			this.Options = options;
		}
	}
}
