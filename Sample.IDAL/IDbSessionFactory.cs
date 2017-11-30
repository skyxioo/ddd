namespace Sample.IDAL
{
    public interface IDbSessionFactory
    {
        IDbSession GetDbSession();
    }
}