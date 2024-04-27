

using MicrosoftAzure.SecretManagement.Data.BusinessObject;

namespace MicrosoftAzure.SecretManagement.Data.Core.KeyVault
{
    public class KeyVaultCore : IKeyVaultCore
    {
        private IKeyVaultBO _keyVaultBO;
        private readonly IConfigurationSettings _configuration;
        public KeyVaultCore(IKeyVaultBO keyVaultBO, IConfigurationSettings configuration)
        {
            _keyVaultBO = keyVaultBO;
            _configuration = configuration;
        }

        public Task<string> DeleteSecret(string secretName)
        {
            return _keyVaultBO.DeleteSecret(secretName);
        }

        public List<string> GetAllSecret()
        {
             return  _keyVaultBO.GetAllSecret();

        }

        public Task<string> GetSecret(string secretName)
        {
            return _keyVaultBO.GetSecret(secretName);

        }

        public Task<string> SetSecret(string Key, string Value)
        {
            return _keyVaultBO.SetSecret(Key, Value);
        }

        public Task<string> SoftDeleteSecret(string Key)
        {
            return _keyVaultBO.SoftDeleteSecret(Key);
        }
    }
}
