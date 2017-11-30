using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class LeaveMsgService : BaseService<LeaveMsg>, ILeaveMsgService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.LeaveMsgDAL;
        }
    }
}