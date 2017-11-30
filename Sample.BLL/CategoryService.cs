using Sample.IBLL;
using Sample.Model;

namespace Sample.BLL
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public override void SetDAL()
        {
            CurrentDAL = CurrentDbSession.CategoryDAL;
        }
    }
}