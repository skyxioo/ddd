using System;
using System.Linq;
using Quartz;
using Sample.IBLL;
using Sample.Model;
using Sample.WebHelper;

namespace Sample.SiteSearch
{
    public class QuartzJob : IJob
    {
        private ISearchDetailService _searchDetailService = OperateHelper.Current._serviceSession.SearchDetailService;
        private ISearchRankService _searchRankService = OperateHelper.Current._serviceSession.SearchRankService;

        public virtual void Execute(IJobExecutionContext context)
        {
            //清空热搜榜排名
            _searchRankService.DeleteBy(p => true);

            var details = _searchDetailService.GetListBy(p => true);
            var list = from p in details
                group p by p.KeyWord
                into g
                select new SearchRank
                {
                    Id = Guid.NewGuid(),
                    KeyWord = g.Key,
                    SearchTimes = g.Count()
                };
            //统计后插入热搜排行榜
            _searchRankService.AddRange(list);
        }
    }
}