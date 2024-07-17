using Microsoft.AspNetCore.Mvc;

namespace OnlineList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnlineListControllers : ControllerBase
    {
        private static readonly string[] Name_List = new[]
        {
            "Test"
        };

        private readonly ILogger<OnlineListControllers> _logger;

        public OnlineListControllers(ILogger<OnlineListControllers> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOnlineList")]
        public IEnumerable<OnlineList> Get()
        {
            return Enumerable.Range(0, 10).Select(index => new OnlineList
            {
                Name_List = Name_List[index]
            })
            .ToArray();
        }
    }
}
