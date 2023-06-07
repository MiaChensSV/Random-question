using DHA_Code_Test_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace DHA_Code_Test_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionAnswerController : ControllerBase
	{
		[HttpGet("getRandomQuestions/{numOfQuestions}")]
		public ActionResult<IEnumerable<QuestionModel>> GetQuestions(int numOfQuestions)
		{
			try
			{
				return DummyDB.GetRandomQuestions(numOfQuestions);
			} catch(ArgumentOutOfRangeException exc) 
			{
				return StatusCode(422, ErrorHandler.GenerateLoggedErrorJson(exc));
			} catch(Exception exc)
			{
				return StatusCode(500, ErrorHandler.GenerateLoggedErrorJson(exc));
			}
		}
		[HttpGet("getCorrectAnswerById/{questionAnswerId}")]
		public ActionResult<AnswerModel> GetAnswer(int questionAnswerId) 
		{
			try
			{
				if (questionAnswerId <= 0) {
					return StatusCode(422, "Question Answer Id out of range.");
				}
				AnswerModel retVal = DummyDB.GetCorrectAnswerById(questionAnswerId);
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
		[HttpPost("checkAnswer")]
		public ActionResult<ResultModel> CheckAnswer([FromBody] AnswerModel answer)
		{
			try
			{
				if (answer == null || answer.QuestionAnswerId < 0)
					throw new ArgumentException("Unprocessable answer object");
				AnswerModel correctAnswer = DummyDB.GetCorrectAnswerById(answer.QuestionAnswerId);
				if (correctAnswer.Answer == answer.Answer)
					return new ResultModel(answer.QuestionAnswerId, true);
				else
					return new ResultModel(answer.QuestionAnswerId, false);
			}
			catch (ArgumentException exc)
			{
				return StatusCode(422, ErrorHandler.GenerateLoggedErrorJson(exc));
			}
			catch (Exception exc)
			{
				return StatusCode(500, ErrorHandler.GenerateLoggedErrorJson(exc));
			}
		}
	}
}
