using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternetBankingRESTfulService.Test
{
    [TestClass]
    public class BLLUnitTest
    {
       
        [TestMethod]
        public void MD5CalculationTest()
        {
            BLL.Interfaces.IInternetBankingApi bank = new BLL.Services.InternetBankingApi();
            string md5Value = bank.CalculateMD5("africa");
            Assert.AreEqual(md5Value, "F4F52C274B8B0AF7593E8D85F45AE7F1");
        }

        [TestMethod]
        public void GetApiVersion()
        {
            string currentDay = System.DateTime.Now.Day.ToString();
            string currentMonth = System.DateTime.Now.Month.ToString();
            string currentYear = System.DateTime.Now.Year.ToString();
            string response = currentYear + "." + currentMonth.PadLeft(2, '0') + "." + currentDay.PadLeft(2, '0') + "." + "1.0.0.0";
            BLL.Interfaces.IInternetBankingApi bank = new BLL.Services.InternetBankingApi();
            string version = bank.GetApiVersion();
            Assert.AreEqual(version, response);
        }

        [TestMethod]
        public void IsPasswordStrong()
        {
            BLL.Interfaces.IInternetBankingApi bank = new BLL.Services.InternetBankingApi();
            BLL.Services.serviceresponse response = new BLL.Services.serviceresponse();
            response.result = "Password is strong";
            response.check = true ;
            BLL.Services.serviceresponse passwordCheck = bank.IsPasswordStrong("Test@123");
            Assert.AreEqual(passwordCheck, response);
          
        }

    }
}
