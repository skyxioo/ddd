using System.Runtime.Remoting.Messaging;
using Sample.IDAL;

namespace Sample.DAL
{
    public class DbSessionFactory : IDbSessionFactory
    {
        public IDbSession GetDbSession()
        {
            IDbSession dbSession = CallContext.GetData("dbSession") as DbSession;
            if (dbSession == null)
            {
                dbSession = new DbSession();
                CallContext.SetData("dbSession", dbSession);
            }

            return dbSession;
        }
    }
}$""