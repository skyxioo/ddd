using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class WebSettingService : BaseService<WebSetting>, IWebSettingService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.WebSettingDAL;
        }
    }
}