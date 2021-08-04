using System;

namespace СollatzРypothesisApp
{
    class Program
    {
        const string CONSOLE_FORMAT_LONG = "### ### ### ### ### ### ### ##0";

        static private string FormatNumberWithGroup(ulong num) => num.ToString(CONSOLE_FORMAT_LONG).Trim();


        static void Main(string[] args)
        {
            Console.WriteLine("Start " + new string('=', 20));

            var cc = CollatzChecker.GetInstanse();

            for (int epoch = 0; epoch < 10; epoch++)
            {
                for (ulong counter = cc.MaxCheckedNumber + 1; counter < cc.MaxCheckedNumber + 1_000_001; counter++)
                    cc.CheckNumber(counter);
                cc.DoEndEpoch();
                Console.WriteLine($"epoch=[{epoch}] maxCheckedNum=[{FormatNumberWithGroup(cc.MaxCheckedNumber)}] array =[{FormatNumberWithGroup((ulong)cc.CheckedNumbers.Length)}]");
            }
            Console.WriteLine("Done " + new string('=', 20));
        }


    }
}
