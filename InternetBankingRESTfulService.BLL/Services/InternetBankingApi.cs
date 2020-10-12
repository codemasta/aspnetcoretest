using InternetBankingRESTfulService.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace InternetBankingRESTfulService.BLL.Services
{
    public class InternetBankingApi : IInternetBankingApi
    {
        public string CalculateMD5(string param)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(param);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public string GetApiVersion()
        {
            var thisApp = Assembly.GetExecutingAssembly();
            AssemblyName name = new AssemblyName(thisApp.FullName);
            string VersionNumber = name.Version.ToString();
            string currentDay = DateTime.Now.Day.ToString();
            string currentMonth = DateTime.Now.Month.ToString();
            string currentYear = DateTime.Now.Year.ToString();
            string response = currentYear + "." + currentMonth.PadLeft(2, '0') + "." + currentDay.PadLeft(2, '0') + "." + VersionNumber;
            return response;
        }

        public serviceresponse IsPasswordStrong(string password)
        {
            serviceresponse rs = new serviceresponse();
            if (string.IsNullOrWhiteSpace(password))
            {
                rs.result = "Password cannot be empty";
                rs.check = false;
            }
            if (password.Contains(" "))
            {
                rs.result = "Password contains white spaces and its not acceptable";
                rs.check = false;
            }
            else
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
                rs.check = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasLowerChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password) && hasSymbols.IsMatch(password);
                rs.result = rs.check ? "Password is strong" : "Password is not strong";
            }

            return rs;

        }
    }

    public class serviceresponse
    {
        public bool check { get; set; }
        public string result { get; set; }
    }

}
