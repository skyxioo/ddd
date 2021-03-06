﻿using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public class VisitorDAL : BaseDAL<Visitor>, IVisitorDAL
    {
        public override void SetDbContext()
        {
            _dbContext = new BlogDbContext();
        }
    }
}