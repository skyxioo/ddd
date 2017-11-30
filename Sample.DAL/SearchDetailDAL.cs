using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class SearchDetailDAL : BaseDAL<SearchDetail>, ISearchDetailDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}