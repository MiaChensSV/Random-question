namespace DHA_Code_Test_Backend.Models;

public class QuestionAnswerModel
{
	public int QuestionAnswerId { get; set; }
	public string QuestionText { get; set; } = null!;
	public OptionModel[] Options { set; get; } = null!;
	public Option CorrectAnswer { get; set; }

	public QuestionAnswerModel(
		int questionAnswerId,
		string questionText,
		OptionModel[] options,
		Option correctAnswer
	) {
		this.QuestionAnswerId = questionAnswerId;
		this.QuestionText = questionText;
		this.Options = options;
		this.CorrectAnswer = correctAnswer;
	}
	public QuestionModel ToQuestionModel()
	{
		return new QuestionModel(this.QuestionAnswerId, this.QuestionText, this.Options);
	}

	public AnswerModel GetCorrectAnswerModel()
	{
		string correctAnswerText = this.Options.FirstOrDefault(option => option.OptionValue == this.CorrectAnswer)!.OptionText;
		return new AnswerModel(this.QuestionAnswerId, correctAnswerText);
	}
}
