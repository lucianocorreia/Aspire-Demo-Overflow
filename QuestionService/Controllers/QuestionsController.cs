using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionService.Data;
using QuestionService.Dtos;
using QuestionService.Models;

namespace QuestionService.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionsController(QuestionDbContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Question>> CreateQuestion(CreateQuestionDto dto)
    {
        var validTags = await context.Tags.Where(x => dto.Tags.Contains(x.Slug)).ToListAsync();
        var missingTags = dto.Tags.Except([.. validTags.Select(x => x.Slug)]).ToList();

        if (missingTags.Count != 0)
        {
            return BadRequest($"The following tags are invalid: {string.Join(", ", missingTags)}");
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var name = User.FindFirstValue("name");

        if (userId is null || name is null) return BadRequest("User information is missing.");

        var question = new Question
        {
            Title = dto.Title,
            Content = dto.Content,
            TagSlugs = dto.Tags,
            AskerId = userId,
            AskerDisplayName = name
        };

        context.Questions.Add(question);
        await context.SaveChangesAsync();

        return Created($"/questions/{question.Id}", question);

    }

}
