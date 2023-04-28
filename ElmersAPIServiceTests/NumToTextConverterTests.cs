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
        [TestMethod()]
        public void ConvertNumberToWords_ValidInput()
        {
            var converter = new NumToTextConverter();
            var result = converter.ConvertNumberToWords("5237");
            Assert.AreEqual("Five thousand two hundred and thirty seven", result);
        }

        [TestMethod()]
        public void ConvertNumberToWords_InvalidInputNonNumeric()
        {
            var converter = new NumToTextConverter();
            var result = converter.ConvertNumberToWords("abc");
            Assert.AreEqual(String.Empty, result);
        }

        [TestMethod()]
        public void ConvertNumberToWords_InvalidInputExceedMaxValue()
        {
            var converter = new NumToTextConverter();
            var result = converter.ConvertNumberToWords("2147483648");
            Assert.AreEqual(String.Empty, result);          
        }

        [TestMethod()]
        public void ConvertNumberToWords_InvalidInputLessThanMinValue()
        {
            var converter = new NumToTextConverter();
            var result = converter.ConvertNumberToWords("-2147483649");
            Assert.AreEqual(String.Empty, result);
        }
    }
}