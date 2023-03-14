using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class GetArticles
    {
        [HttpGet("GetArticles")]
        public void GetAllSubjectsList()
        {
            Task GetXML;
            RequestGet request = new RequestGet();
            List<RssSubjectsUrl> rssSubjectsUrls= DataLayer.Data.RssUrls.ToList();
            GetXML = Task.Run(async () =>
            {
                foreach (RssSubjectsUrl RssUrl in rssSubjectsUrls)
                {
                    await request.XMLRequestGet(RssUrl.Link);
                }
            });
            
        }

    }
}
