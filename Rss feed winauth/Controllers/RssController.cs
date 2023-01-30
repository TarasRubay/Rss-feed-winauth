using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Rss_feed_winauth.DataBaseContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.ServiceModel.Syndication;
using System.Xml;
using Rss_feed_winauth.Repositories;

namespace Rss_feed_winauth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class RssController : Controller
    {
        private readonly FeedRepositories _feedRepositories;
        public RssController(TableContext context)
        {
            _feedRepositories = new(context);
        }

        [HttpPost("AddRSSfeed")]
        public async Task<IActionResult> AddRSSfeed(string UrlFeed) 
        {
            if (User.Identity.Name is not null)
            {
                var result = await _feedRepositories.ParseRSS(UrlFeed, User.Identity.Name);
                if (result.Equals("1"))
                    return Ok();
                return BadRequest(result);
            }
            else return NotFound("User Undefined");
        }
        [HttpGet("GetAllActiveRSSfeeds")]
        public async Task<IActionResult> GetAllActiveRSSfeeds()
        {
            if (User.Identity.Name is not null)
            {
                var result = await _feedRepositories.GetAll(User.Identity.Name);
                if (result is not null)
                    return Ok(result.ToArray());
                return BadRequest(result);
            }
            else return NotFound("User Undefined");
        }
        [HttpPost("GetAllUnreadNewsFromSomeDate")]
        public async Task<IActionResult> GetAllUnreadNewsFromSomeDate(DateTime? date)
        {
            if (User.Identity.Name is not null)
            {
                var result = await _feedRepositories.GetAllUnreadFromDate(User.Identity.Name, date);
                if (result is not null)
                    return Ok(result.ToArray());
                return BadRequest(result);
            }
            else return NotFound("User Undefined");
        }
        [HttpPost("SetNewsAsRead")]
        public async Task<IActionResult> SetNewsAsRead(string IdFeed)
        {
            if (User.Identity.Name is not null)
            {
                var result = await _feedRepositories.SetNewsAsRead(User.Identity.Name, IdFeed);
                if (result != 0)
                    return Ok(result);
                return BadRequest(result);
            }
            else return NotFound("User Undefined");
        }
        [HttpPost("SetNewsAsRead {Id:int}")]
        public async Task<IActionResult> SetNewsAsReadWithId(int Id)
        {
            if (User.Identity.Name is not null)
            {
                var result = await _feedRepositories.SetNewsAsRead(User.Identity.Name, Id);
                if (result != 0)
                    return Ok(result);
                return BadRequest(result);
            }
            else return NotFound("User Undefined");
        }
    }
}
