using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class CategoryDAL : BaseDAL<Category>, ICategoryDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}