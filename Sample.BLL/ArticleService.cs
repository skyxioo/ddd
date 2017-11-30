using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.ArticleDAL;
        }
    }
}