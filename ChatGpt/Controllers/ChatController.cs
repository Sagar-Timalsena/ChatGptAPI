using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ChatGptService _chatGptService;

    public ChatController(ChatGptService chatGptService)
    {
        _chatGptService = chatGptService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> AskChatGpt([FromBody] string prompt)
    {
        var response = await _chatGptService.GetResponseAsync(prompt);
        return Ok(response);
    }
}
