using OpenQA.Selenium.Support.Extensions;
using System;
using TestFramework.Core.Driver;

namespace TestFramework.Core.Abstractions
{
    public class PageTestBase
    {
        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                //TODO: clean and add here more logic
                var screenshot = DriverInstance.GetInstance().TakeScreenshot();
                var filePath = AppDomain.CurrentDomain.BaseDirectory;
                screenshot.SaveAsFile($"{filePath}Name.png");
                // This would be a good place to log the exception message and
                // save together with the screenshot
            }
        }
    }
}