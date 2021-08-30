using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace СollatzРypothesisApp
{
    class CollatzChecker
    {

        public static readonly int MAX_CHECK_WRONG_STREAK = 5_000_000;
        public static readonly int CHECK_STREAK = 5_000_000;

        static BigInteger maxCheckedNumber = 2;
        public static BigInteger MaxCheckedNumber { get => maxCheckedNumber; }

        private static void ConfigSave() => Utils.SettingKeyReWrite("maxCheckedNumber", maxCheckedNumber.ToString());

        private static void ConfigRead()
        {
            string str = Utils.SettingKeyRead("maxCheckedNumber");
            if (!BigInteger.TryParse(str, out BigInteger res)) res = 2;
            maxCheckedNumber = res;
        }

        //        public CollatzChecker() { }
        static CollatzChecker() => ConfigRead();
        ~CollatzChecker() => ConfigSave();

        public void RunParallel()
        {
            int numParallel = Environment.ProcessorCount;
            if (numParallel < 1) numParallel = 1;

            Parallel.ForEach(Enumerable.Range(0, numParallel), DoWork);
            maxCheckedNumber += (BigInteger)(CHECK_STREAK * numParallel - 1);
            ConfigSave();
            Console.WriteLine();
        }

        public void DoWork(int rangeNum)
        {
            for (BigInteger counter = (BigInteger)(CHECK_STREAK * rangeNum); counter < (BigInteger)(CHECK_STREAK * (rangeNum + 1) - 1); counter++)
                CheckNumber(maxCheckedNumber + counter);
            Console.Write($"{rangeNum};");
        }


        private void CheckNumber(BigInteger checkingNum)
        {
            int counter = 0;
            BigInteger num = checkingNum;

            BigInteger BigInteger1 = (BigInteger)1;
            BigInteger BigInteger2 = (BigInteger)2;
            BigInteger BigInteger3 = (BigInteger)3;


            while (counter < MAX_CHECK_WRONG_STREAK)
            {
                if (num <= maxCheckedNumber) return;
                if (num % BigInteger2 == 0)
                    num /= BigInteger2;
                else
                    checked { num = BigInteger3 * num + BigInteger1; };
                counter++;
            }
            throw new ArgumentException($"value [{checkingNum}] does not fit Сollatz Рypothesis");
        }
    }
}
