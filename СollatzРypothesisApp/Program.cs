using System;

namespace СollatzРypothesisApp
{
    class Program
    {
        const string CONSOLE_FORMAT_LONG="### ### ### ### ### ### ### ##0";
        static void Main(string[] args)
        {
            Console.WriteLine("Start " + new string('=', 20));

            var cc = CollatzChecker.GetInstanse();

            for (int epoch = 0; epoch < 10; epoch++)
            {
                for (ulong counter = cc.MaxCheckedNumber + 1; counter < cc.MaxCheckedNumber + 1_000_001; counter++)
                    cc.CheckNumber(counter);
                cc.DoEndEpoch();
                Console.WriteLine($"epoch=[{epoch}] maxCheckedNum=[{cc.MaxCheckedNumber.ToString(CONSOLE_FORMAT_LONG).Trim()}] array =[{cc.CheckedNumbers.Length.ToString(CONSOLE_FORMAT_LONG).Trim()}]");
            }
            Console.WriteLine("Done " + new string('=', 20));
        }
    }
}
