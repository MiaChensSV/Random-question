using DHA_Code_Test_Backend.Models;

namespace DHA_Code_Test_Backend;

public static class DummyDB
{
	private static readonly List<QuestionAnswerModel> _questionAnswerlist = new()
	{
		new QuestionAnswerModel(
			1,
            "What is the capital of France?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "London"),
				new OptionModel(Option.X, "Paris"),
				new OptionModel(Option.Two, "Berlin")
			},
			Option.X,
			"/images/quiz1.jpg"
		),
		new QuestionAnswerModel(
			2,
            "Who painted the Mona Lisa?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Leonardo da Vinci"),
				new OptionModel(Option.X, "Vincent van Gogh"),
				new OptionModel(Option.Two, "Pablo Picasso")
			},
			Option.One,
			"/images/quiz2.jpg"
		),
		new QuestionAnswerModel(
			3,
            "What is the largest planet in our solar system?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Earth"),
				new OptionModel(Option.X, "Mars"),
				new OptionModel(Option.Two, "Jupiter")
			},
			Option.Two,
			"/images/quiz3.jpg"
		),
		new QuestionAnswerModel(
			4,
            "What is the chemical symbol for gold?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Au"),
				new OptionModel(Option.X, "Ag"),
				new OptionModel(Option.Two, "Fe")
			},
			Option.One,
			"/images/quiz4.jpg"
		),
		new QuestionAnswerModel(
			5,
            "Who wrote the novel \"Pride and Prejudice\"?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Emily Brontë"),
				new OptionModel(Option.X, "Jane Austen"),
				new OptionModel(Option.Two, "Virginia Woolf")
			},
			Option.X,
			"/images/quiz5.jpg"
		),
		new QuestionAnswerModel(
			6,
            "What is the world's tallest mountain?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Mount Kilimanjaro"),
				new OptionModel(Option.X, "Mount Fuji"),
				new OptionModel(Option.Two, "Mount Everest")
			},
			Option.Two,
			"/images/quiz6.jpg"
		),
		new QuestionAnswerModel(
			7,
            "What is the main ingredient in guacamole?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Tomatoes"),
				new OptionModel(Option.X, "Avocados"),
				new OptionModel(Option.Two, "Onions")
			},
			Option.X,
			"/images/quiz7.jpg"
		),
		new QuestionAnswerModel(
			8,
            "Who invented the telephone?",
			new OptionModel[]
			{
				new OptionModel(Option.One, "Thomas Edison"),
				new OptionModel(Option.X, "Isaac Newton"),
				new OptionModel(Option.Two, "Alexander Graham Bell")
			},
			Option.Two,
			"/images/quiz8.jpg"
		)
	};
	public static QuestionModel[] GetRandomQuestions(int numOfRand) 
	{
		if (numOfRand > _questionAnswerlist.Count || numOfRand < 0)
			throw new ArgumentOutOfRangeException("Number of random can not be greater than the number of questions.");
		QuestionModel[] retVal = new QuestionModel[numOfRand];
		List<int> randIndexes = GenerateNonRepeatRandom(numOfRand, _questionAnswerlist.Count);
		for (int i = 0; i < numOfRand; i++)
		{
			retVal[i] = _questionAnswerlist[randIndexes[i]].ToQuestionModel();
		}
		return retVal;
	}
	public static AnswerModel GetCorrectAnswerById(int questionAnswerId)
	{
		List<QuestionAnswerModel> result = _questionAnswerlist
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
		Random rand = new();
		List<int> retVal = new();
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
