using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class WebSettingDAL : BaseDAL<WebSetting>, IWebSettingDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}