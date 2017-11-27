using System.Net.NetworkInformation;
using Sample.IDAL;

namespace Sample.DAL
{
    public class DbSession : IDbSession
    {
        private IArticleDAL _articleDAL;
        public IArticleDAL ArticleDAL
        {
            get
            {
                if(_articleDAL == null)
                    _articleDAL = new ArticleDAL();
                return _articleDAL;
            }
            set { _articleDAL = value; }
        }

        private ICategoryDAL _categoryDAL;
        public ICategoryDAL CategoryDAL
        {
            get
            {
                if(_categoryDAL == null)
                    _categoryDAL = new CategoryDAL();
                return _categoryDAL;
            }
            set { _categoryDAL = value; }
        }

        private ICommentDAL _commentDAL;

        public ICommentDAL CommentDAL
        {
            get
            {
                if(_commentDAL == null)
                    _commentDAL = new CommentDAL();
                return _commentDAL;
            }
            set { _commentDAL = value; }
        }

        private IHeadIconDAL _headIconDAL;

        public IHeadIconDAL HeadIconDAL
        {
            get
            {
                if(_headIconDAL == null)
                    _headIconDAL = new HeadIconDAL();
                return _headIconDAL;
            }
            set { _headIconDAL = value; }
        }

        private ILeaveMsgDAL _leaveMsgDAL;

        public ILeaveMsgDAL LeaveMsgDAL
        {
            get
            {
                if(_leaveMsgDAL == null)
                    _leaveMsgDAL = new LeaveMsgDAL();
                return _leaveMsgDAL;
            }
            set { _leaveMsgDAL = value; }
        }

        private IPalLinkDAL _palLinkDAL;

        public IPalLinkDAL PalLinkDAL
        {
            get
            {
                if(_palLinkDAL == null)
                    _palLinkDAL = new PalLinkDAL();
                return _palLinkDAL;
            }
            set { _palLinkDAL = value; }
        }

        private ISearchDetailDAL _searchDetailDAL;

        public ISearchDetailDAL SearchDetailDAL
        {
            get
            {
                if(_searchDetailDAL == null)
                    _searchDetailDAL = new SearchDetailDAL();
                return _searchDetailDAL;
            }
            set { _searchDetailDAL = value; }
        }

        private ISearchRankDAL _searchRankDAL;

        public ISearchRankDAL SearchRankDAL
        {
            get
            {
                if(_searchRankDAL == null)
                    _searchRankDAL = new SearchRankDAL();
                return _searchRankDAL;
            }
            set { _searchRankDAL = value; }
        }

        private IStaticFileDAL _staticFileDAL;

        public IStaticFileDAL StaticFileDAL
        {
            get
            {
                if(_staticFileDAL == null)
                    _staticFileDAL = new StaticFileDAL();
                return _staticFileDAL;
            }
            set { _staticFileDAL = value; }
        }

        private IVisitorDAL _visitorDAL;

        public IVisitorDAL VisitorDAL
        {
            get
            {
                if(_visitorDAL == null)
                    _visitorDAL = new VisitorDAL();
                return _visitorDAL;
            }
            set { _visitorDAL = value; }
        }

        private IWebSettingDAL _webSettingDAL;

        public IWebSettingDAL WebSettingDAL
        {
            get
            {
                if(_webSettingDAL == null)
                    _webSettingDAL = new WebSettingDAL();
                return _webSettingDAL;
            }
            set { _webSettingDAL = value; }
        }
    }
}