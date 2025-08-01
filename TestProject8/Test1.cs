using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace projetoteste
{
     public class Test1 // <- tem que ser public
    {
        [Test]
        public void Test()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.facebook.com/");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.Name("q")));

                IWebElement searchBox = driver.FindElement(By.Name("q"));
                searchBox.SendKeys("Python");
                searchBox.SendKeys(Keys.Enter);

                wait.Until(d => d.FindElements(By.CssSelector(".course-card--container--1QM7R")).Count > 0);

                var courses = driver.FindElements(By.CssSelector(".course-card--container--1QM7R"));
                if (courses.Count > 0)
                {
                    Console.WriteLine($"Teste passou! {courses.Count} cursos encontrados.");
                }
                else
                {
                    Console.WriteLine("Teste falhou! Nenhum curso encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro durante o teste: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}