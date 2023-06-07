namespace DHA_Code_Test_Backend.Models;

public class AnswerModel
{
	public int QuestionAnswerId { get; set; } = -1;
	public string Answer { get; set; } = "";
	public AnswerModel(){}		
	public AnswerModel(int questionAnswerId, string anwser)
	{
		this.QuestionAnswerId = questionAnswerId;
		this.Answer = anwser;
	}
}