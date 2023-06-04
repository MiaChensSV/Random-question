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
		public IEnumerable<QuestionModel> GetQuestions() 
		{
			return DummyDB.getRandomQuestions();
		}
		[HttpGet]
		[Route("/getAnswerById/{questionAnswerId}")]
		public ActionResult<AnswerModel> GetAnswer(int questionAnswerId) 
		{
			try
			{
				if (questionAnswerId <= 0) {
					return StatusCode(422, "Question Answer Id out of range.");
				}
				AnswerModel retVal = DummyDB.getAnswerById(questionAnswerId);
				return retVal;
			} catch (QuestionAnswerNotFoundException exc)
			{
				return StatusCode(404, ErrorHandler.GenerateLoggedErrorJson(exc));
			} catch (DuplicatedQuestionAnswerException exc)
			{
				return StatusCode(500, ErrorHandler.GenerateLoggedErrorJson(exc));
			} catch (Exception exc)
			{
				return StatusCode(500, ErrorHandler.GenerateLoggedErrorJson(exc));
			}
			
		}
	}
}
