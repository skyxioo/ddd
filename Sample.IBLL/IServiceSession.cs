namespace Sample.IBLL
{
    public interface IServiceSession
    {
        IArticleService ArticleService { get; set; }
        ICategoryService CategoryService { get; set; }
        ICommentService CommentService { get; set; }
        IHeadIconService HeadIconService { get; set; }
        ILeaveMsgService LeaveMsgService { get; set; }
        IPalLinkService PalLinkService { get; set; }
        ISearchDetailService SearchDetailService { get; set; }
        IStaticFileService StaticFileService { get; set; }
        IVisitorService VisitorService { get; set; }
        IWebSettingService WebSettingService { get; set; }
    }
}