using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class VisitorService : BaseService<Visitor>, IVisitorService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.VisitorDAL;
        }
    }
}