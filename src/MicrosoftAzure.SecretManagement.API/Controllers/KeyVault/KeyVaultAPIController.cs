


namespace MicrosoftAzure.API.Controllers.KeyVault
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyVaultAPIController : ControllerBase
    {
        private IKeyVaultCore _keyVaultCore;
        private readonly IConfigurationSettings _configuration;

        public KeyVaultAPIController(IKeyVaultCore keyVaultCore, IConfigurationSettings configuration)
        {
            _keyVaultCore = keyVaultCore;
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _keyVaultCore.GetAllSecret();
        }

        [HttpGet("{key}")]
        public Task<string> Get(string key)
        {
            return _keyVaultCore.GetSecret(key);
        }

        [HttpPost]
        public void Post(string key, string value)
        {
            var val= _keyVaultCore.SetSecret(key,value);
        }

       

        [HttpDelete("{key}")]
        public void Delete(string key)
        {
            var val = _keyVaultCore.SoftDeleteSecret(key);
        }
    }
}
