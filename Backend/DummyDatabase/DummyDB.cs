using DHA_Code_Test_Backend.Models;

namespace DHA_Code_Test_Backend;

public class QuestionAnswerNotFoundException: Exception 
{
	public QuestionAnswerNotFoundException(string? message) : base(message) { }
}
public class DuplicatedQuestionAnswerException: Exception
{
	public DuplicatedQuestionAnswerException(string? message) : base(message) { }
}
public static class DummyDB
{
	private static List<QuestionAnswerModel> questionAnswerlist = new List<QuestionAnswerModel>{
		new QuestionAnswerModel(
			1,
			"What is your name?",
			new string[] {"Kevin", "Yihong", "Hong"},
			1
		),
		new QuestionAnswerModel(
			2,
			"What is your fav car?",
			new string[] {"Volvo", "VW", "BMW"},
			2
		),
		new QuestionAnswerModel(
			3,
			"What is your fav color?",
			new string[] {"Red", "Yellow", "Blue"},
			0
		),
		new QuestionAnswerModel(
			4,
			"What is your daughter's name?",
			new string[] {"Kevin", "Yihong", "Stella"},
			2
		),
		new QuestionAnswerModel(
			5,
			"What is your car's name?",
			new string[] {"Kevin", "Passat", "Hong"},
			1
		),
		new QuestionAnswerModel(
			6,
			"What is your street name?",
			new string[] {"Kevin", "Soljlus", "Hong"},
			1
		),
		new QuestionAnswerModel(
			7,
			"What is your dog's name?",
			new string[] {"Vanisa", "Yihong", "Hong"},
			0
		),
		new QuestionAnswerModel(
			8,
			"What is your ice scream's name?",
			new string[] {"Ben & Jerry", "Yihong", "Hong"},
			0
		)
	};
	public static QuestionModel[] getRandomQuestions() 
	{
		QuestionModel[] retVal = new QuestionModel[3];
		Random random = new Random();
		for (int i = 0; i < retVal.Length; i++)
		{
			int index = (int)random.Next(0, 8);
			retVal[i] = questionAnswerlist[index].ToQuestionModel();
		}
		return retVal;
	}
	public static AnswerModel getAnswerById(int questionAnswerId)
	{
		List<QuestionAnswerModel> result = questionAnswerlist
			.FindAll(item => item.QuestionAnswerId == questionAnswerId)
			.ToList();
		if (result.Count == 0)
		{
			throw new QuestionAnswerNotFoundException("Question Answer not found by Id of {" + questionAnswerId + "}");
		} else if (result.Count > 1)
		{
			throw new DuplicatedQuestionAnswerException("More Question Answers has a same Id");
		}
		return result[0].ToAnswerModel();
			
	}
}
