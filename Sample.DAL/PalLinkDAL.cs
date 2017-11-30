using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class PalLinkDAL : BaseDAL<PalLink>, IPalLinkDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}