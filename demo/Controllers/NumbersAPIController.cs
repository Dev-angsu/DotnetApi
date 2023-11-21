using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class getAllRooms : Controller
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("getNumbersAPI")]
        public Task<string> GetNumbersAPI()
        {
            return GetFactAsync();
        }
        [NonAction]
        public async Task<string> GetFactAsync()
        {
            try
            {
                var response = await client.GetAsync("http://numbersapi.com/42");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return "\nException Caught!";
            }
        }
    }
}
