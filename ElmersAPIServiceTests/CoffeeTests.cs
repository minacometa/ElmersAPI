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
        [TestMethod()]
        public void ProcessCoffeeValidInput()
        {
            Coffee coffee = new Coffee();
            string settings = "0xBBF1";
            CoffeeSettings result = coffee.ProcessCoffee(settings);
            CoffeeSettings expected = new CoffeeSettings
            {
                machine_on = true,
                grinding_beans = false,
                empty_grounds_fault = false,
                water_empty_fault = false,
                number_of_cups_today = 191,
                descale_required = false,
                have_another_one_carl = true
            };
            Assert.IsTrue(expected.machine_on == result.machine_on);
            Assert.IsTrue(expected.grinding_beans == result.grinding_beans);
            Assert.IsTrue(expected.empty_grounds_fault == result.empty_grounds_fault);
            Assert.IsTrue(expected.water_empty_fault == result.water_empty_fault);
            Assert.IsTrue(expected.number_of_cups_today == result.number_of_cups_today);
            Assert.IsTrue(expected.descale_required == result.descale_required);
            Assert.IsTrue(expected.have_another_one_carl == result.have_another_one_carl);
        }

        [TestMethod()]
        public void ProcessCoffeeInvalidInput()
        {
            Coffee coffee = new Coffee();
            string settings = "test123";
            Assert.ThrowsException<System.FormatException>(() => coffee.ProcessCoffee(settings));
        }        
    }
}