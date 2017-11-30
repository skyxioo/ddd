using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class LeaveMsgDAL : BaseDAL<LeaveMsg>, ILeaveMsgDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}