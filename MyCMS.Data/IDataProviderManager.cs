namespace MyCMS.Data.DataProviders
{
    public interface IDataProviderManager
    {
        public IDataProvider GetDataProvider(DataProviderType dataProviderType);
    }
}
