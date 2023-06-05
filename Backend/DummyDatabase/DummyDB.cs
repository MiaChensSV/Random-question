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
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
			1
		),
		new QuestionAnswerModel(
			2,
			"What is your fav car?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
			2
		),
		new QuestionAnswerModel(
			3,
			"What is your fav color?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
			0
		),
		new QuestionAnswerModel(
			4,
			"What is your daughter's name?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
			2
		),
		new QuestionAnswerModel(
			5,
			"What is your car's name?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
			1
		),
		new QuestionAnswerModel(
			6,
			"What is your street name?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
			1
		),
		new QuestionAnswerModel(
			7,
			"What is your dog's name?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
			0
		),
		new QuestionAnswerModel(
			8,
			"What is your ice scream's name?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Kevin"),
				new OptionModel(Option.X, "Yihong"),
				new OptionModel(Option.Two, "Stella")
			},
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
