namespace MyCMS.Data.Intefaces
{
    public interface IDataProviderManager
    {
        public IDataProvider GetDataProvider(DataProviderType dataProviderType);
    }
}
