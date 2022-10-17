namespace MyCMS.Data.Interfaces
{
    public interface IDataProviderManager
    {
        public IDataProvider GetDataProvider(DataProviderType dataProviderType);
    }
}
