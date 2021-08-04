using System;

namespace СollatzРypothesisApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start " + new string('=', 20));

            var cc = new CollatzChecker();
            for (int epoch = 0; epoch < 3; epoch++)
            {
                for (ulong counter = cc.MaxCheckedNumber + 1; counter < cc.MaxCheckedNumber + 1_000_001; counter++)
                    cc.CheckNumber(counter);
                cc.SetMaxCheckedNumber();
                Console.WriteLine($"epoch={epoch} maxNum={cc.MaxCheckedNumber} array ={cc.CheckedNumbers.Length}");
            }

            Console.WriteLine("Done " + new string('=', 20));
            //Console.ReadKey();
        }
    }
}
