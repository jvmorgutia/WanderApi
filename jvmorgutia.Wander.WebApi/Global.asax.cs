using System;
using System.Web.Configuration;
using System.Web.Http;
using jvmorgutia.Wander.Logic.Configuration;

namespace jvmorgutia.Wander.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        #region String Constants

        private const string WanderDatabaseServer = "WanderDatabaseServer";
        private const string WanderDatabaseName = "WanderDatabaseName";
        private const string WanderDatabaseUserId = "WanderDatabaseUserID";
        private const string WanderDatabasePassword = "WanderDatabasePassword";
        private const string DatabaseConnectionFormat = "Server={0};Database={1};User Id={2};Password={3}";

        private const string MissingConfigurationErrorString = "A valid configuration setting must be set for {0}.";
        #endregion

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            InitializeConfigurationSettings();
            ValidateConfigurationSettings();
        }

        private void InitializeConfigurationSettings()
        {
            ConfigurationSetting.WanderDatabaseServer = WebConfigurationManager.AppSettings[WanderDatabaseServer];
            ConfigurationSetting.WanderDatabaseName = WebConfigurationManager.AppSettings[WanderDatabaseName];
            ConfigurationSetting.WanderDatabaseUserId = WebConfigurationManager.AppSettings[WanderDatabaseUserId];
            ConfigurationSetting.WanderDatabasePassword = WebConfigurationManager.AppSettings[WanderDatabasePassword];

            ConfigurationSetting.WanderDatabaseConnectionString = string.Format(DatabaseConnectionFormat,
                ConfigurationSetting.WanderDatabaseServer, ConfigurationSetting.WanderDatabaseName,
                ConfigurationSetting.WanderDatabaseUserId, ConfigurationSetting.WanderDatabasePassword);
        }

        public static void ValidateConfigurationSettings()
        {
            var configurationSettings = typeof(ConfigurationSetting).GetProperties();
            foreach (var setting in configurationSettings)
            {
                if (string.IsNullOrWhiteSpace(setting.GetValue(null).ToString()))
                    throw new ArgumentNullException(string.Format(MissingConfigurationErrorString, setting.Name));
            }
        }
    }
}
