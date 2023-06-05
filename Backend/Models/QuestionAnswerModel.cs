namespace DHA_Code_Test_Backend.Models
{
<<<<<<< Updated upstream
	public class QuestionAnswerModel
=======
	public int QuestionAnswerId { get; set; }
	public string QuestionText { get; set; } = null!;
	public OptionModel[] Options { set; get; } = null!;
	public int AnswerIndex { get; set; } = 0;

	public QuestionAnswerModel(
		int questionAnswerId, 
		string questionText,
		OptionModel[] options,
		int answerIndex
	) { 
		this.QuestionAnswerId = questionAnswerId;
		this.QuestionText = questionText;
		this.Options = options;
		this.AnswerIndex = answerIndex;
	}

	public QuestionModel ToQuestionModel()
>>>>>>> Stashed changes
	{
		private string[] _options;
		public int QuestionAnswerId { get; set; }
		public string QuestionText { get; set; } = null!;
		public string[] Options 
		{
			get { return this._options; }
			set 
			{
				if (value.Length != 3)
				{
					throw new ArgumentException("Number of options must be 3!");
				}
				this._options = value;
			} 
		}
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
