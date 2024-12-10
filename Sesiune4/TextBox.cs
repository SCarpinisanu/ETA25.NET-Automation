using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Sesiune4
{
    public class TextBox
    {
        IWebDriver driver;

        [Test]
        public void TextBoxTest()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com");
            driver.Manage().Window.Maximize();

            IWebElement elementsButton = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementsButton.Click();

            IWebElement elementsButtonTextBox = driver.FindElement(By.XPath("//*[text()='Text Box']"));
            elementsButtonTextBox.Click();

            IWebElement elementsUserName = driver.FindElement(By.Id("userName"));
            elementsUserName.SendKeys("Sorin Carpinisanu");

            IWebElement elementsEmail = driver.FindElement(By.Id("userEmail"));
            elementsEmail.SendKeys("sc1@mail.com");

            IWebElement elementsCurrentAddress = driver.FindElement(By.Id("currentAddress"));
            elementsCurrentAddress.SendKeys("Str.Aleea Papucesti 8 \n" +
                "bl. 55B, sc. C, et. 2, ap. 10 \n" +
                "Pitesti, Arges, cod 110374");

            IWebElement elementsPermanentAddress = driver.FindElement(By.Id("permanentAddress"));
            elementsPermanentAddress.SendKeys("Str.Aleea Papucesti 8 \n" +
                "bl. 55B, sc. C, et. 2, ap. 10 \n" +
                "Pitesti, Arges, cod 110374");

            IWebElement elementsButtonSubmit = driver.FindElement(By.XPath("//*[text()='Submit']"));
            // the Submit button is not visible on the page, so this command doesn't work:
            // elementsButtonSubmit.Click();

            //Using the Submit function
            elementsButtonSubmit.Submit();
        }

        [TearDown]
        public void TearDown()
        {
            //Using a time wait before closing the browser
            Thread.Sleep(5000);
            driver.Dispose();
        }
    }
}
