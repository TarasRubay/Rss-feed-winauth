using Rss_feed_winauth.DataBaseContext;
using Rss_feed_winauth.Models;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Rss_feed_winauth.Repositories
{
    public class FeedRepositories
    { 
            private readonly TableContext _context;
        public FeedRepositories(TableContext context)
        {
            _context = context;
        }
        public async Task<string> ParseRSS(string url,string userName)
        {
            var res = await Task.Run(() =>
            {
                SyndicationFeed feed;
                try
                {
                    using (var reader = XmlReader.Create(url))
                    {
                        feed = SyndicationFeed.Load(reader);
                    }
                    if (feed is not null)
                    {
                        foreach (var element in feed.Items)
                        {
                            _context.AddAsync(RssFeedModel.Create(element,userName));
                        }
                        return _context.SaveChangesAsync().ToString();
                    }
                }
                catch (Exception e){
                    return e.Message;
                } 
                return null;
            }
            );
            if(res is not null) return res;
            return "failed";
        }
        public async Task<IEnumerable<RssFeedModel>> GetAll(string userName)
        {
            var res = await Task.Run(() =>
            {
                    return _context.RssFeedModels.Select(a => a).Where(x => x.NameUser.Equals(userName));   
            });
            return res;
            
        }
        public async Task<IEnumerable<RssFeedModel>> GetAllUnreadFromDate(string userName, DateTime? date)
        {
            var res = await Task.Run(() =>
            {
                    return _context.RssFeedModels
                .Select(a => a)
                .Where(x => x.NameUser.Equals(userName) && x.Publish_Date > date && !x.IsRead).ToArray();   
            });
            return res;
            
        }
        public async Task<int> SetNewsAsRead(string userName, string idFeed)
        {
            var res = await Task.Run(() =>
            {
                    var Feed = _context.RssFeedModels
                .Select(a => a)
                .Where(x => x.IdFeed.Equals(idFeed)).FirstOrDefault();
                if (Feed is not null)
                {
                    Feed.IsRead = true;
                    _context.RssFeedModels.Update(Feed);
                }
                    return _context.SaveChangesAsync();
            });
            return res;
            
        }
        public async Task<int> SetNewsAsRead(string userName, int id)
        {
            var res = await Task.Run(() =>
            {
                    var Feed = _context.RssFeedModels
                .Select(a => a)
                .Where(x => x.Id.Equals(id)).FirstOrDefault();
                if(Feed is not null)
                {
                    Feed.IsRead = true;
                    _context.RssFeedModels.Update(Feed);
                }
                    return _context.SaveChangesAsync();
            });
            return res;
            
        }

    }
}
