namespace DHA_Code_Test_Backend.Models;

public class QuestionAnswerModel
{
	public int QuestionAnswerId { get; set; }
	public string QuestionText { get; set; } = null!;
<<<<<<< HEAD
	public OptionModel[] Options { set; get; } = null!;
	public int AnswerIndex { get; set; } = 0;

	public QuestionAnswerModel(
		int questionAnswerId,
		string questionText,
		OptionModel[] options,
		int answerIndex
	) {
=======
	public string[] Options { set; get; } = null!;
	public int AnswerIndex { get; set; } = 0;

	public QuestionAnswerModel(
		int questionAnswerId, 
		string questionText,
		string[] options,
		int answerIndex
	) { 
>>>>>>> 1903e39e6e37d655d9093f3e801a5bb23ee60a55
		this.QuestionAnswerId = questionAnswerId;
		this.QuestionText = questionText;
		this.Options = options;
		this.AnswerIndex = answerIndex;
	}
<<<<<<< HEAD
=======

>>>>>>> 1903e39e6e37d655d9093f3e801a5bb23ee60a55
	public QuestionModel ToQuestionModel()
	{
		return new QuestionModel(this.QuestionAnswerId, this.QuestionText, this.Options);
	}

	public AnswerModel ToAnswerModel()
	{
		return new AnswerModel(this.QuestionAnswerId, this.Options, this.AnswerIndex);
	}
}
