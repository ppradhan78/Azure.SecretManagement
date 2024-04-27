﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftAzure.SecretManagement.Data.Core.KeyVault
{
    public interface IKeyVaultCore
    {
        public List<string> GetAllSecret();
        public Task<string> GetSecret(string secretName);
        public Task<string> SetSecret(string Key, string Value);
        public Task<string> SoftDeleteSecret(string secretName);
        public Task<string> DeleteSecret(string secretName);
    }
}
