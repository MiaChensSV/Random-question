using DHA_Code_Test_Backend.Models;

namespace DHA_Code_Test_Backend;

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
			Option.X
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
			Option.One
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
			Option.Two
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
			Option.One
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
			Option.X
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
			Option.Two
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
			Option.X
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
			Option.Two
		)
	};
	public static QuestionModel[] getRandomQuestions(int numOfRand) 
	{
		if (numOfRand > questionAnswerlist.Count || numOfRand < 0)
			throw new ArgumentOutOfRangeException("Number of random can not be greater than the number of questions.");
		QuestionModel[] retVal = new QuestionModel[numOfRand];
		List<int> randIndexes = GenerateNonRepeatRandom(numOfRand, questionAnswerlist.Count());
		for (int i = 0; i < numOfRand; i++)
		{
			retVal[i] = questionAnswerlist[randIndexes[i]].ToQuestionModel();
		}
		return retVal;
	}
	public static AnswerModel getCorrectAnswerById(int questionAnswerId)
	{
		List<QuestionAnswerModel> result = questionAnswerlist
			.FindAll(item => item.QuestionAnswerId == questionAnswerId)
			.ToList();
		if (result.Count == 0)
		{
			throw new QuestionAnswerNotFoundException("Question Answer not found by Id of '" + questionAnswerId + "'");
		} else if (result.Count > 1)
		{
			throw new DuplicatedQuestionAnswerException("More Question Answers has a same Id");
		}
		return result[0].GetCorrectAnswerModel();
	}
	private static List<int> GenerateNonRepeatRandom(int numOfRand, int sampleSize)
	{
		Random rand = new Random();
		List<int> retVal = new List<int>();
		while(retVal.Count < numOfRand)
		{
			int newRandInt = rand.Next(0, sampleSize);
			if (!retVal.Contains(newRandInt))
			{
				retVal.Add(newRandInt);
			}
		}
		return retVal;
	}
}
