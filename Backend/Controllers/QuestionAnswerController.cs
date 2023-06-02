using DHA_Code_Test_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHA_Code_Test_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionAnswerController : ControllerBase
	{
		[HttpGet]
		[Route("/getRandomQuestions")]
		public IEnumerable<QuestionModel> getQuestions() 
		{
			return DummyDB.getRandomQuestions();
		}
		[HttpGet]
		[Route("/getAnswerById/{questionAnswerId}")]
		public AnswerModel getAnswer(int questionAnswerId) 
		{
			return DummyDB.getAnswerById(questionAnswerId);
		}
	}
}
