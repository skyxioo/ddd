using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class SearchRankDAL : BaseDAL<SearchRank>, ISearchRankDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}