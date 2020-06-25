using SimpleWarehouse.Model;

namespace SimpleWarehouse.Interfaces
{
    public interface IDbConnectionPropertiesStorageManager
    {
        void SaveSettings(DbProperties properties);

        DbProperties GetSettings();
    }
}