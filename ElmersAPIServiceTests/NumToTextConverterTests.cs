using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElmersAPIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmersAPIService.Tests
{
    [TestClass()]
    public class NumToTextConverterTests
    {
        [DataTestMethod]
        [DataRow("0", "Zero")]
        [DataRow("13", "Thirteen")]
        [DataRow("85", "Eighty five")]
        [DataRow("5 237", "Five thousand two hundred and thirty seven")]
        [DataRow("-10", "Negative ten")]
        [DataRow("2 147 483 648", "")]//empty string as this is over the max value of Int32
        public void ConvertNumberToWords_ConvertNumberToWordsTest(string num, string expectedNumText)
        {
            var converter = new NumToTextConverter();
            var result = converter.ConvertNumberToWords(num);
            Assert.AreEqual(expectedNumText, result);
        }        
    }
}