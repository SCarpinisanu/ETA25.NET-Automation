using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Session7
{
    public class PracticeForm
    {
        IWebDriver driver;

        [Test]
        public void PracticeFormMethod()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();

            IWebElement formsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
            formsButton.Click();

            IWebElement practiceFormsButton = driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            practiceFormsButton.Click();

            IWebElement genderMale = driver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
            IWebElement genderFemale = driver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
            IWebElement genderOther = driver.FindElement(By.XPath("//label[@for='gender-radio-3']"));

            string genderChosen = "Male";

            //if (genderChosen.Equals("Male"))
            //{
            //    genderMale.Click();
            //}
            //else if (genderChosen.Equals("Female"))
            //{
            //    genderFemale.Click();
            //}
            //else
            //{
            //    genderOther.Click();
            //}

            switch (genderChosen)
            {
                case "Male":
                    genderMale.Click();
                    break;
                case "Female":
                    genderFemale.Click();
                    break;
                case "Other":
                    genderOther.Click();
                    break;

            }

            IWebElement elementSubjects = driver.FindElement(By.Id("subjectsInput"));
            elementSubjects.SendKeys("English");
            elementSubjects.SendKeys(Keys.Enter);
            elementSubjects.SendKeys("c");
            elementSubjects.SendKeys(Keys.ArrowDown);
            elementSubjects.SendKeys(Keys.ArrowDown);
            elementSubjects.SendKeys(Keys.ArrowDown);
            elementSubjects.SendKeys(Keys.Enter);


        }

        [TearDown]
        public void TearDown()
        {
            System.Threading.Thread.Sleep(5000);
            driver.Dispose();
            driver.Quit();
        }
    }
}
