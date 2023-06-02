namespace DHA_Code_Test_Backend.Models
{
	public class QuestionAnswerModel
	{
		public int QuestionAnswerId { get; set; }
		public string QuestionText { get; set; } = null!;
		public string[] Options { get; set; } = null!;
		public int AnswerIndex { get; set; } = 0;

		public QuestionAnswerModel(
			int questionAnswerId, 
			string questionText,
			string[] options,
			int answerIndex
		) { 
			this.QuestionAnswerId = questionAnswerId;
			this.QuestionText = questionText;
			this.Options = options;
			this.AnswerIndex = answerIndex;
		}

		public QuestionModel ToQuestionModel()
		{
			return new QuestionModel(this.QuestionAnswerId, this.QuestionText, this.Options);
		}

		public AnswerModel ToAnswerModel()
		{
			return new AnswerModel(this.QuestionAnswerId, this.Options, this.AnswerIndex);
		}
	}
}
