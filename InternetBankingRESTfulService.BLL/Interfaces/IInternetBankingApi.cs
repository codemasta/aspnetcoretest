using InternetBankingRESTfulService.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingRESTfulService.BLL.Interfaces
{
    public interface IInternetBankingApi
    {
        public string GetApiVersion();
        public string CalculateMD5(string param);
        public serviceresponse IsPasswordStrong(string password);
    }
}
