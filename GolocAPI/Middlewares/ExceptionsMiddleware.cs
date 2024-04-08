using GolocAPI.Models;
using Newtonsoft.Json;

namespace GolocAPI.Middlewares
{
    public class ExceptionsMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
			try
			{
				await next(context);
			}
			catch (Exception)
			{
				string payload = JsonConvert.SerializeObject(new APIResponse<Exception?>{ Status = StatusCodes.Status500InternalServerError, Message = "Something went wrong"});
			}
        }
    }
}
