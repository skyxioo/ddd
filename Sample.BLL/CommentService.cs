using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.CommentDAL;
        }
    }
}