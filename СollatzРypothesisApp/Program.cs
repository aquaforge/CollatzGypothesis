using System;
using System.Threading;

namespace СollatzРypothesisApp
{
    class Program
    {

        static void Main(string[] args)
        {
            LogInfo("Start");

            var cc = new CollatzChecker();
            for (int epoch = 0; epoch < 100; epoch++)
            {
                LogInfo($"epoch={epoch}");
                cc.RunParallel();
            }

            LogInfo("Done");
        }

        private static void LogInfo(string txt)
        {
            Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")} maxCheckedNum=[{CollatzChecker.MaxCheckedNumber.ToString("N0")}]" + (txt.Length != 0 ? " " + txt : ""));
        }


    }
}
