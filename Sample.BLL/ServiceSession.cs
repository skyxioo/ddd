using System.Net.NetworkInformation;
using Sample.IBLL;

namespace Sample.BLL
{
    public class ServiceSession : IServiceSession
    {
        private IArticleService _articleService;
        public IArticleService ArticleService
        {
            get
            {
                if(_articleService == null)
                    _articleService = new ArticleService();
                return _articleService;
            }
            set { _articleService = value; }
        }

        private ICategoryService _categoryService;
        public ICategoryService CategoryService
        {
            get
            {
                if(_categoryService == null)
                    _categoryService = new CategoryService();
                return _categoryService;
            }
            set { _categoryService = value; }
        }

        private ICommentService _commentService;
        public ICommentService CommentService
        {
            get
            {
                if(_commentService == null)
                    _commentService = new CommentService();
                return _commentService;
            }
            set { _commentService = value; }
        }

        private IHeadIconService _headIconService;

        public IHeadIconService HeadIconService
        {
            get
            {
                if(_headIconService == null)
                    _headIconService = new HeadIconService();
                return _headIconService;
            }
            set { _headIconService = value; }
        }

        private ILeaveMsgService _leaveMsgService;

        public ILeaveMsgService LeaveMsgService
        {
            get
            {
                if(_leaveMsgService == null)
                    _leaveMsgService = new LeaveMsgService();
                return _leaveMsgService;
            }
            set { _leaveMsgService = value; }
        }

        private IPalLinkService _palLinkService;

        public IPalLinkService PalLinkService
        {
            get
            {
                if(_palLinkService == null)
                    _palLinkService = new PalLinkService();
                return _palLinkService;
            }
            set { _palLinkService = value; }
        }

        private ISearchDetailService _searchDetailService;
        public ISearchDetailService SearchDetailService {
            get
            {
                if (_searchDetailService == null)
                    _searchDetailService = new SearchDetailService();
                return _searchDetailService;
            }
            set { _searchDetailService = value; }
        }

        private ISearchRankService _searchRankService;
        public ISearchRankService SearchRankService
        {
            get
            {
                if (_searchRankService == null)
                    _searchRankService = new SearchRankService();
                return _searchRankService;
            }
            set { _searchRankService = value; }
        }

        private IStaticFileService _staticFileService;
        public IStaticFileService StaticFileService {
            get
            {
                if (_staticFileService == null)
                    _staticFileService = new StaticFileService();
                return _staticFileService;
            }
            set { _staticFileService = value; }
        }

        private IVisitorService _visitorService;
        public IVisitorService VisitorService {
            get
            {
                if (_visitorService == null)
                    _visitorService = new VisitorService();
                return _visitorService;
            }
            set { _visitorService = value; }
        }

        private IWebSettingService _webSettingService;
        public IWebSettingService WebSettingService {
            get
            {
                if (_webSettingService == null)
                    _webSettingService = new WebSettingService();
                return _webSettingService;
            }
            set { _webSettingService = value; }
        }
    }
}