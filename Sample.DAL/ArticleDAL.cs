using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class ArticleDAL : BaseDAL<Article>, IArticleDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}