using FormApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FormApi.Controllers
{
    [ApiController]
    [Route("api/form")]
    public class FormController : ControllerBase
    {
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitForm([FromBody] FormData formData)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(formData);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "file.json");
                // Write the JSON data to the file
                await System.IO.File.WriteAllTextAsync(filePath, jsonData);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
