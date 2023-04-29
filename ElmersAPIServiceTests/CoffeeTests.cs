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
    public class CoffeeTests
    {
        public static IEnumerable<object[]> CoffeeTestData
        {
            get
            {
                return new[]
                {
                    new object[]{"0xBBF1", new CoffeeSettings { machine_on = true,
                        grinding_beans = false,
                        empty_grounds_fault = false,
                        water_empty_fault = false,
                        number_of_cups_today = 191,
                        descale_required = false,
                        have_another_one_carl = true} },
                    new object[]{"0x33A3", new CoffeeSettings { machine_on = true, 
                        grinding_beans = true, 
                        empty_grounds_fault = false,
                        water_empty_fault = false, 
                        number_of_cups_today = 58, 
                        descale_required = false,
                        have_another_one_carl = true} },
                    new object[]{"0x99C1", new CoffeeSettings { machine_on = true,
                        grinding_beans = false,
                        empty_grounds_fault = false,
                        water_empty_fault = false,
                        number_of_cups_today = 156,
                        descale_required = false,
                        have_another_one_carl = true} }
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(CoffeeTestData))]
        public void ProcessCoffeeTest(string input, CoffeeSettings expected)
        {
            Coffee coffee = new Coffee();            
            CoffeeSettings result = coffee.ProcessCoffee(input);
           
            Assert.IsTrue(expected.machine_on == result.machine_on);
            Assert.IsTrue(expected.grinding_beans == result.grinding_beans);
            Assert.IsTrue(expected.empty_grounds_fault == result.empty_grounds_fault);
            Assert.IsTrue(expected.water_empty_fault == result.water_empty_fault);
            Assert.IsTrue(expected.number_of_cups_today == result.number_of_cups_today);
            Assert.IsTrue(expected.descale_required == result.descale_required);
            Assert.IsTrue(expected.have_another_one_carl == result.have_another_one_carl);
        }  
    }
}