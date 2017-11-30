using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class SearchDetailService : BaseService<SearchDetail>, ISearchDetailService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.SearchDetailDAL;
        }
    }
}