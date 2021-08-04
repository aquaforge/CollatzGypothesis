using System;

namespace СollatzРypothesisApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Start " + new string('=', 20));

            var cc = CollatzChecker.GetInstanse();

            for (int epoch = 0; epoch < 50; epoch++)
            {
                for (ulong counter = cc.MaxCheckedNumber + 1; counter < cc.MaxCheckedNumber + 1_000_001; counter++)
                    cc.CheckNumber(counter);
                cc.DoEndEpoch();

                Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")} epoch=[{epoch}] maxCheckedNum=[{cc.MaxCheckedNumber.ToString("N0")}]");
            }
            Console.WriteLine("Done " + new string('=', 20));
        }


    }
}
