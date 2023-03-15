using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;
using News.DataSql;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class GetArticles
    {
        [HttpGet("GetArticlesFromRSS")]
        public void GetAllSubjectsList()
        {
            RequestGet request = new RequestGet();
            List<RssSubjectsUrl> rssSubjectsUrls;
            Task.Run(async () =>
            {
                rssSubjectsUrls = (List<RssSubjectsUrl>)MainManager.Instance.GetDataFromDB("rssurl");
                foreach (RssSubjectsUrl RssUrl in rssSubjectsUrls)
                {
                    await request.XMLRequestGet(RssUrl.Link);
                }
            });
            
        }
        [HttpPost("GetArticlesFromDB")]
        public void SetUserSubjects(string[] userSubjects)
        {
            
        }

    }
}
