using InterviewPrepApp.DTOs.Topics;
using InterviewPrepApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrepApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly ILogger<TopicController> _logger;

        public TopicController(
            ITopicService topicService,
            ILogger<TopicController> logger)
        {
            _topicService = topicService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddTopic(TopicDTO topic)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _topicService.AddTopic(topic);

                return CreatedAtAction(nameof(GetTopicById),
                    new { id = data.TopicId }, data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating topic");
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopic(TopicDTO topic)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _topicService.UpdateTopic(topic);

                if (data == null)
                    return NotFound("Topic not found.");

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating topic");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTopics()
        {
            return Ok(await _topicService.GetTopics());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            var data = await _topicService.GetTopicById(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var result = await _topicService.DeleteTopic(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}