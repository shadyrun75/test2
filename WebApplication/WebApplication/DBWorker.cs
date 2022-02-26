namespace WebApp
{
    public class DBWorker 
    {
        public static DatabaseLib.Database Database { get; private set; }
        public DBWorker(IConfiguration configuration)
        {
            Database = new DatabaseLib.Database(configuration.GetConnectionString("TestDB"));
        }
    }
}
