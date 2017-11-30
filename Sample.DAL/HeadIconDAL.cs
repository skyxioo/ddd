using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class HeadIconDAL : BaseDAL<HeadIcon>, IHeadIconDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}