using System.ServiceModel.Syndication;

namespace Rss_feed_winauth.Models
{
    public class RssFeedModel
    {
        public int Id { get; set; }
        public string? IdFeed { get; set; }
        public string? Authors { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Link { get; set; }
        public DateTime? Publish_Date { get; set; }
        public bool IsRead { get; set; }
        public string? NameUser { get; set; }
        public static RssFeedModel Create(SyndicationItem item,string userName)
        {
            return new RssFeedModel()
            {

                IdFeed = item.Id,
                Authors = item.Authors.FirstOrDefault() is not null? item.Authors.FirstOrDefault().Name:"",
                Title = item.Title.Text,
                Summary = item.Summary.Text,
                Link = item.Links.FirstOrDefault() is not null ? item.Links.FirstOrDefault().Uri.ToString() : "",
                Publish_Date = item.PublishDate.DateTime,
                IsRead = false,
                NameUser = userName
            };
        }
    }
}
