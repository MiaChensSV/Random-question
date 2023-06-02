using DHA_Code_Test_Backend.Models;

namespace DHA_Code_Test_Backend;

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
	public static QuestionModel[] getRandomQuestions(int numOfRand) 
	{
		if (numOfRand > questionAnswerlist.Count)
			throw new ArgumentOutOfRangeException("Number of random can not be greater than the number of questions.");
		QuestionModel[] retVal = new QuestionModel[numOfRand];
		List<int> randIndexes = GenerateNonRepeatRandom(numOfRand, questionAnswerlist.Count());
		for (int i = 0; i < numOfRand; i++)
		{
			retVal[i] = questionAnswerlist[randIndexes[i]].ToQuestionModel();
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
			throw new QuestionAnswerNotFoundException("Question Answer not found by Id of '" + questionAnswerId + "'");
		} else if (result.Count > 1)
		{
			throw new DuplicatedQuestionAnswerException("More Question Answers has a same Id");
		}
		return result[0].ToAnswerModel();
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
