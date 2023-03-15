using Microsoft.AspNetCore.Mvc;
using News.Entities;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController
    {
        [HttpGet("GetSubjects")]
        public JsonResult GetAllSubjects()
        {
            return new JsonResult(MainManager.Instance.subjectManager.GetDataFromDB("subject"));
        }
    }
}
