using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class CommentDAL : BaseDAL<Comment>, ICommentDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}