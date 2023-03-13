using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using News.Entities;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/Subjects")]
    public class CheckingClientSide
    {
        [HttpGet("GetSubjects")]
        public JsonResult GetAllSubjectsList()
        {
            return new JsonResult(MainManager.Instance.dataLayer.Subjects.ToList());
        }
    }
}
