namespace Sample.IDAL
{
    public interface IDbSession
    {
        IArticleDAL ArticleDAL { get; set; }
        ICategoryDAL CategoryDAL { get; set; }
        ICommentDAL CommentDAL { get; set; }
        IHeadIconDAL HeadIconDAL { get; set; }
        ILeaveMsgDAL LeaveMsgDAL { get; set; }
        IPalLinkDAL PalLinkDAL { get; set; }
        ISearchDetailDAL SearchDetailDAL { get; set; }
        ISearchRankDAL SearchRankDAL { get; set; }
        IStaticFileDAL StaticFileDAL { get; set; }
        IVisitorDAL VisitorDAL { get; set; }
        IWebSettingDAL WebSettingDAL { get; set; }
    }
}