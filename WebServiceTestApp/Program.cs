using System;
using System.Linq;
using System.Reflection;
using static WebServiceTestApp.Helpers;

namespace WebServiceTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LogMessage("LoanApp WebService mini test framework started");
            var testCase = LoadTestCase(args[0]);
            if (testCase == null)
                return;

            try
            {
                testCase.Prepare();
                testCase.Execute();
                testCase.Cleanup();
                Environment.Exit((int)TestResult- 1); //will return 0 for PASS
            }
            catch (Exception e)
            {
                LogMessage($"Exception occured during test execution! {e.ToString()}", LogLevel.EXCEPTION);
                Environment.Exit(1);
            }

        }

        private static ITestCase LoadTestCase(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            try
            {
                LogMessage($"Trying to load {name} testcase");

                var type = assembly.GetTypes().First(t => t.Name == name);

                var test = (ITestCase)Activator.CreateInstance(type);
                LogMessage($"Test case loaded");
                return test;
            }
            catch (Exception e)
            {
                LogMessage($"Failed to load test {name}! {e.ToString()}", LogLevel.EXCEPTION);
                return null;
            }
        }
    }
}
