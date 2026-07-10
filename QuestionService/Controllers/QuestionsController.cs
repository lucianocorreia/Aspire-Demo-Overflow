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

    [HttpGet]
    public async Task<ActionResult<List<Question>>> GetQuestions(string? tag)
    {
        var query = context.Questions.AsQueryable();

        if (!string.IsNullOrEmpty(tag))
        {
            query = query.Where(q => q.TagSlugs.Contains(tag));
        }

        var questions = await query.OrderByDescending(x => x.CreatedAt).ToListAsync();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> GetQuestion(string id)
    {
        var question = await context.Questions.FindAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        await context.Questions
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(setter => setter.SetProperty(x => x.ViewCount, x => x.ViewCount + 1));

        return Ok(question);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateQuestion(string id, CreateQuestionDto dto)
    {
        var question = await context.Questions.FindAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != question.AskerId)
        {
            return Forbid();
        }

        var validTags = await context.Tags.Where(x => dto.Tags.Contains(x.Slug)).ToListAsync();
        var missingTags = dto.Tags.Except([.. validTags.Select(x => x.Slug)]).ToList();

        if (missingTags.Count != 0)
        {
            return BadRequest($"The following tags are invalid: {string.Join(", ", missingTags)}");
        }

        question.Title = dto.Title;
        question.Content = dto.Content;
        question.TagSlugs = dto.Tags;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteQuestion(string id)
    {
        var question = await context.Questions.FindAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != question.AskerId)
        {
            return Forbid();
        }

        context.Questions.Remove(question);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
