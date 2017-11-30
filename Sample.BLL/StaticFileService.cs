using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class StaticFileService : BaseService<StaticFile>, IStaticFileService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.StaticFileDAL;
        }
    }
}