using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class StaticFileDAL : BaseDAL<StaticFile>, IStaticFileDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}