using System;
using jvmorgutia.Wander.Data.Configuration;

namespace jvmorgutia.Wander.Data
{
    public class BaseRepository
    {
        private const string ConnectionSettingErrorMessage =
            "Please verify that configuration settings have been provided.";

        public BaseRepository()
        {
            if (string.IsNullOrWhiteSpace(ConfigurationSetting.WanderDatabaseConnectionString))
                throw new ArgumentNullException(ConnectionSettingErrorMessage);
        }
    }
}
