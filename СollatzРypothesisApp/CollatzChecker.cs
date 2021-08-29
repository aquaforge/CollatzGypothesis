using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СollatzРypothesisApp
{
    class CollatzChecker
    {

        public static readonly int MAX_CHECK_WRONG_STREAK = 5_000_000;
        public static readonly int CHECK_STREAK = 5_000_000;

        static ulong maxCheckedNumber = 2;
        public static ulong MaxCheckedNumber { get => maxCheckedNumber; }

        private static void ConfigSave() => Utils.SettingKeyReWrite("maxCheckedNumber", maxCheckedNumber.ToString());

        private static void ConfigRead()
        {
            string str = Utils.SettingKeyRead("maxCheckedNumber");
            if (!ulong.TryParse(str, out ulong res)) res = 2;
            maxCheckedNumber = res;
        }

        //        public CollatzChecker() { }
        static CollatzChecker() => ConfigRead();
        ~CollatzChecker() => ConfigSave();

        public void RunParallel()
        {
            var nums = new ulong[10];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = maxCheckedNumber + (ulong)(CHECK_STREAK * i + 1);

            Parallel.ForEach(nums, DoWork);
            maxCheckedNumber += (ulong)(CHECK_STREAK * 10 - 1);

            //DoWork(maxCheckedNumber + 1);
            ConfigSave();
        }

        public void DoWork(ulong startNumber)
        {
            for (ulong counter = startNumber; counter < startNumber + (ulong)(CHECK_STREAK - 1); counter++)
                CheckNumber(counter);
        }


        private void CheckNumber(ulong checkingNum)
        {
            int counter = 0;
            ulong num = checkingNum;

            while (counter < MAX_CHECK_WRONG_STREAK)
            {
                if (num <= maxCheckedNumber) return;
                if (num % 2 == 0)
                    num /= 2;
                else
                    checked { num = 3 * num + 1; };
                counter++;
            }
            throw new ArgumentException($"value [{checkingNum}] does not fit Сollatz Рypothesis");
        }
    }
}
