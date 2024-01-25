using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGpt.Controllers
{
    [ApiController]
    public class GPTController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatgpt")]
        public async Task<IActionResult> UseChatgpt(string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);
            foreach (var completion in completions.Result.Completions)
            {
                OutPutResult += completion.Text;
            }
            return Ok(OutPutResult);

        }
    }
}
