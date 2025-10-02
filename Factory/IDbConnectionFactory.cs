using System.Data;

namespace WorkerTest.Factory
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}