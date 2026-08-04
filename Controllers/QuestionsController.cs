using InterviewPrepApp.DTOs.Question;
using InterviewPrepApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrepApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(
            IQuestionService questionService,
            ILogger<QuestionController> logger)
        {
            _questionService = questionService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(QuestionDTO question)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _questionService.AddQuestion(question);

                _logger.LogInformation("Question created successfully.");

                return CreatedAtAction(nameof(GetQuestionById),
                    new { id = data.QuestionId }, data);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating question.");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(QuestionDTO question)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _questionService.UpdateQuestion(question);

                if (data == null)
                    return NotFound("Question not found.");

                _logger.LogInformation("Question updated successfully.");

                return Ok(data);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating question.");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            try
            {
                var data = await _questionService.GetQuestions();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving questions.");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            try
            {
                var data = await _questionService.GetQuestionById(id);

                if (data == null)
                    return NotFound("Question not found.");

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving question.");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong.");
            }
        }

        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetQuestionsByTopic(int topicId)
        {
            try
            {
                var data = await _questionService.GetQuestionsByTopic(topicId);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving topic questions.");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                var result = await _questionService.DeleteQuestion(id);

                if (!result)
                    return NotFound("Question not found.");

                _logger.LogInformation("Question deleted successfully.");

                return Ok("Question deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting question.");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong.");
            }
        }
    }
}