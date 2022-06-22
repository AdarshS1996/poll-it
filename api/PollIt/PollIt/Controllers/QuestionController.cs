using Microsoft.AspNetCore.Mvc;
using PollIt.Service.QuestionService;

namespace PollIt.Controllers
{
    [Route("api/1.0/Questions")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok(_questionService.GetQuestions());
        }

        [HttpGet("{guid}")]
        public IActionResult GetQuestion([FromRoute]string guid)
        {
            return Ok(_questionService.GetQuestion(guid));
        }

        [HttpPost]
        public IActionResult PostQuestion([FromBody]QuestionDto questionDto)
        {
            return Ok(_questionService.PostQuestion(questionDto));
        }

        [HttpDelete("{guid}")]
        public IActionResult DeleteQuestion([FromRoute] string guid)
        {
            return Ok(_questionService.DeleteQuestion(guid));
        }
    }
}
