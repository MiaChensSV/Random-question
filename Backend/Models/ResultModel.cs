namespace DHA_Code_Test_Backend.Models;
public class ResultModel
{
	public int QuestionAnwserId { get; set; }
	public bool IsAnwserCorrect { get; set; }

	public ResultModel(int questionAnwserId, bool isAnwserCorrect)
	{
		this.QuestionAnwserId = questionAnwserId;
		this.IsAnwserCorrect= isAnwserCorrect;
	}
}
