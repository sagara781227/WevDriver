using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace WevDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите название раздела: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите язык ");
            Console.WriteLine("1 - Русский");
            Console.WriteLine("2 - Английский");
            Console.WriteLine("3 - Французский");
            Console.WriteLine("4 - Немецкий");
            int lang = int.Parse(Console.ReadLine());
            if ((lang > 4) || (lang < 1))
                lang = 1;
            Console.Write("Введите ожидаемое кол-во вакансий: ");
            int count = int.Parse(Console.ReadLine());
            IWebDriver driver = new FirefoxDriver();
            IWebElement element;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");
            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.Id("sl"));
            webElements.FirstOrDefault(x => x.Text == "Все отделы").Click();
            driver.FindElement(By.LinkText(name)).Click();
            element =  webElements.FirstOrDefault(x => x.Text == "Все языки");
            element.Click();
            driver.FindElement(By.Id("lang-option-" + (lang - 1))).Click();
            element.Click();
            webElements = driver.FindElements(By.CssSelector("a[class='card card-no-hover card-sm']"));
            Console.WriteLine(webElements.Count == count);
        }
    }
}
