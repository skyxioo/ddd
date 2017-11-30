using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class HeadIconService : BaseService<HeadIcon>, IHeadIconService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.HeadIconDAL;
        }
    }
}