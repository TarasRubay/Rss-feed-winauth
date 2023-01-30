using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Rss_feed_winauth.Models;

namespace Rss_feed_winauth.DataBaseContext
{
    public class TableContext : DbContext
    {
        
        public TableContext(DbContextOptions<TableContext> option) : base(option)
        { }
        public DbSet<RssFeedModel> RssFeedModels { get; set; }
    }
}
