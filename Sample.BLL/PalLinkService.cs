using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class PalLinkService : BaseService<PalLink>, IPalLinkService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.PalLinkDAL;
        }
    }
}