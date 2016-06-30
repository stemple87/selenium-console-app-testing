using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class EntryPoint
{
    static void Main()
    {
        string url = "http://testing.todvachev.com/selectors/css-path/";
        string cssPath = "#post-108 > div > figure > img";
        string xPath = "//*[@id=\"poost-108\"]/div/figure/img";

        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(url);

        IWebElement cssElement;
        IWebElement xPathElement;

        try
        {
            cssElement = driver.FindElement(By.CssSelector(cssPath));
            if (cssElement.Displayed)
            {

                GreenMessage("Yes, I can see the CSS element");
            }
        }
        catch (NoSuchElementException)
        {
                RedMessage("Something went wrong");
        }
        try
        {
            xPathElement = driver.FindElement(By.XPath(xPath));
            if (xPathElement.Displayed)
            {

                GreenMessage("Yes, I can see the xPath element");
            }
        }
        catch (NoSuchElementException)
        {
            RedMessage("Something went wrong");

        }
        driver.Quit();
    }
    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;

    }
    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
