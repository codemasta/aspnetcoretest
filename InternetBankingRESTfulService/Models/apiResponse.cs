using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBankingRESTfulService.Models
{
    public class apiResponse
    {
        public string responseCode { get; set; }
        public string responseFriendlyMessage { get; set; }
        public string result { get; set; }
        public bool hasError { get; set; }
    }
}
