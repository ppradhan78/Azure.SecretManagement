namespace MicrosoftAzure.SecretManagement.Data.BusinessObject
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        #region Global Variable(s)
        private readonly IConfiguration _configuration;
        #endregion

        public ConfigurationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Public Prop(s)
        public string KeyVaultUrl => _configuration["KeyVault:KeyVaultUrl"];

        #endregion

    }
}
