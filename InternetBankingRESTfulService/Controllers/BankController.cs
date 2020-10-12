using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBankingRESTfulService.BLL.Interfaces;
using InternetBankingRESTfulService.BLL.Services;
using InternetBankingRESTfulService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetBankingRESTfulService.Controllers
{
    [Route("[controller]")]
   
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IInternetBankingApi banking;

        public BankController(IInternetBankingApi banking)
        {
            this.banking = banking;
        }


        [HttpGet]
        [Route("api-version")]
        [Route("api/version")]
        public IActionResult getVersion()
        {

            apiResponse response = new apiResponse();
            response.responseCode = "00";
            response.responseFriendlyMessage = "Current API Version";
            response.result = banking.GetApiVersion();
            return Ok(response);
        }

        [HttpGet]
        [Route("api/calc/MD5/{value}")]
        [Route("api/calc/{value}/MD5")]
        public IActionResult CalculateMD5(string value)
        {

            apiResponse response = new apiResponse();
            response.responseCode = "00";
            response.responseFriendlyMessage = "MD5 Encryption";
            response.result = banking.CalculateMD5(value);
            return Ok(response);

        }

        [HttpGet]
        [Route("api/password/strong/{password}")]
        [Route("api/is-password-strong/{password}")]
        public IActionResult IsPasswordStrong(string password)
        {
            apiResponse response = new apiResponse();
           
            serviceresponse isPasswordStrong = banking.IsPasswordStrong(password);
            response.responseCode = "00";
            response.responseFriendlyMessage = isPasswordStrong.result;
            response.result = isPasswordStrong.result;
            response.hasError = isPasswordStrong.check;
            return Ok(response);
            //ge
        }

       
    }
}
