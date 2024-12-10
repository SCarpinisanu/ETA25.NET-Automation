using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Sesiune5
{
    public class WebTablesTest
    {
        IWebDriver driver;

        [Test]
        public void Test1()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();

            IWebElement elementsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementsButton.Click();

            IWebElement elementsWebTablesButton = driver.FindElement(By.XPath("//span[text()='Web Tables']"));
            elementsWebTablesButton.Click();

            IWebElement elementsButtonAdd = driver.FindElement(By.Id("addNewRecordButton"));
            elementsButtonAdd.Click();

            IWebElement popupFirstName = driver.FindElement(By.Id("firstName"));
            IWebElement popupLastName = driver.FindElement(By.Id("lastName"));
            IWebElement popupAge = driver.FindElement(By.Id("age"));
            IWebElement popupUserEmail = driver.FindElement(By.Id("userEmail"));
            IWebElement popupSalary = driver.FindElement(By.Id("salary"));
            IWebElement popupDepartment = driver.FindElement(By.Id("department"));

            string firstNameVar = "Sorin";
            string lastNameVar = "Carpinisanu";
            string ageVar = "57";
            string userEmailVar = "sc1@mail.com";
            string salaryVar = "50000";
            string departmentVar = "Automation testing";
            popupFirstName.SendKeys(firstNameVar);
            popupLastName.SendKeys(lastNameVar);
            popupAge.SendKeys(ageVar);
            popupUserEmail.SendKeys(userEmailVar);
            popupSalary.SendKeys(salaryVar);
            popupDepartment.SendKeys(departmentVar);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            IWebElement popupSubmit = driver.FindElement(By.Id("submit"));
            //popupSubmit.Submit();

            jse.ExecuteScript("arguments[0].click();",popupSubmit);

            //IWebElement lastRow = driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]"));
            IWebElement firstName = driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][1]"));
            IWebElement lastName = driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][2]"));
            IWebElement age = driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][3]"));
            IWebElement userEmail = driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][4]"));
            IWebElement salary = driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][5]"));
            IWebElement department = driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][6]"));

            //Console.WriteLine(lastRow.Text);
            Console.WriteLine("First Name  :" + firstNameVar);
            Console.WriteLine("Last Name   :" + lastNameVar);
            Console.WriteLine("Age:        :" + ageVar);
            Console.WriteLine("User e-mail :" + userEmailVar);
            Console.WriteLine("Salary:     :" + salaryVar);
            Console.WriteLine("Department  :" + departmentVar);

            Assert.That(firstName.Text, Is.EqualTo(firstNameVar));
            Assert.That(lastName.Text, Is.EqualTo(lastNameVar));
            Assert.That(userEmail.Text, Is.EqualTo(userEmailVar));
            Assert.That(age.Text, Is.EqualTo(ageVar));
            Assert.That(salary.Text, Is.EqualTo(salaryVar));
            Assert.That(department.Text, Is.EqualTo(departmentVar));

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
