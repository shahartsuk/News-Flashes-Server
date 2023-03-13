using Microsoft.AspNetCore.Mvc;
using News.Entities;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/Walla")]
    public class GetWallaRss
    {
        [HttpGet("GetRss")]
        public JsonResult GetAllSubjectsList()
        {
            return new JsonResult(MainManager.Instance.requestGet.XMLRequestGet());
        }
    }
}
