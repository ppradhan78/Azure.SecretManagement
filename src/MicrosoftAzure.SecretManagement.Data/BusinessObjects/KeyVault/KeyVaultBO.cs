using Azure.Identity;
using MicrosoftAzure.SecretManagement.Data.BusinessObject;

namespace MicrosoftAzure.SecretManagement.Data.BusinessObjects.KeyVault
{
    public class KeyVaultBO : IKeyVaultBO
    {
        private readonly IConfigurationSettings _configuration;

        public KeyVaultBO(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GetSecret(string secretName)
        {
            try
            {
                var client = GetSecretClient();
                var secret = await client.GetSecretAsync(secretName);
                return secret.Value.Value;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<string> SetSecret(string Key, string Value)
        {
            try
            {
                var client = GetSecretClient();
                var secret = await client.SetSecretAsync(Key, Value);
                return secret.Value.Value;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> SoftDeleteSecret(string secretName)
        {
            var client = GetSecretClient();
            var secret = await client.StartDeleteSecretAsync(secretName);
            return secret.Value.Value;
        }
        public async Task<string> DeleteSecret(string secretName)
        {
            var client = GetSecretClient();
            var secret = await client.PurgeDeletedSecretAsync(secretName);
            return secret.ReasonPhrase;
        }
        private SecretClient GetSecretClient()
        {
            var client = new SecretClient(new Uri(_configuration.KeyVaultUrl), new DefaultAzureCredential());
            return client;
        }

        public List<string> GetAllSecret()
        {
            List<string> secrets = new List<string>();
            var secretClient = GetSecretClient();
            var output = secretClient.GetPropertiesOfSecrets().AsPages().ToList();
            foreach (var item in output)
            {
                foreach (var item1 in item.Values)
                {
                    secrets.Add(item1.Name);
                }
            }
            return secrets;
        }
    }
}
