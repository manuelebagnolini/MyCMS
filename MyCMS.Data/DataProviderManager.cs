namespace MyCMS.Data.DataProviders
{
    public class DataProviderManager : IDataProviderManager
    {
        public IDataProvider GetDataProvider(DataProviderType dataProviderType)
        {
            var dataProvider = dataProviderType switch
            {
                DataProviderType.SQLite => new SQLiteDataProvider(),
                _ => throw new Exception(string.Format("Provider {0} not supported yet!", dataProviderType))
            };

            return dataProvider;
        }
    }
}
