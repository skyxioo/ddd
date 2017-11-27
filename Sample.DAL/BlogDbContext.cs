using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Sample.Model;

namespace Sample.DAL
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("name=BlogDb4ZynEntities")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HeadIcon> HeadIcons { get; set; }
        public DbSet<LeaveMsg> LeaveMsgs { get; set; }
        public DbSet<PalLink> PalLinks { get; set; }
        public DbSet<SearchDetail> SearchDetails { get; set; }
        public DbSet<SearchRank> SearchRanks { get; set; }
        public DbSet<StaticFile> StaticFiles { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<WebSetting> WebSettings { get; set; }
    }
}
