using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class SearchRankService : BaseService<SearchRank>, ISearchRankService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.SearchRankDAL;
        }
    }
}