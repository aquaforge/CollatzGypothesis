using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace СollatzРypothesisApp
{
    class CollatzChecker
    {
        private static CollatzChecker _instanse;

        const int MAX_CHECK_STREAK = 5_000_000;

        ulong maxCheckedNumber = 2;
        public ulong MaxCheckedNumber { get { return maxCheckedNumber; } }

        SortedSet<ulong> checkedNumbers = new SortedSet<ulong>();
        public ulong[] CheckedNumbers { get { return checkedNumbers.ToArray(); } }


        public static CollatzChecker GetInstanse()
        {
            return _instanse ?? new CollatzChecker();
        }



        private CollatzChecker() { ConfigRead(); }
        ~CollatzChecker() { ConfigWrite(); }

        private void ConfigRead()
        {
            string str = Utils.SettingKeyRead("maxCheckedNumber");
            if (!ulong.TryParse(str, out ulong res))
                res = 2;
            maxCheckedNumber = res;
        }

        private void ConfigWrite()
        {
            Utils.SettingKeyReWrite("maxCheckedNumber", maxCheckedNumber.ToString());
        }


        private void SetMaxCheckedNumber()
        {
            ulong counter = maxCheckedNumber + 1;
            while (checkedNumbers.Contains(counter))
                counter++;
            maxCheckedNumber = counter - 1;
            checkedNumbers.RemoveWhere(i => i <= maxCheckedNumber);
        }

        public void DoEndEpoch()
        {
            SetMaxCheckedNumber();
            ConfigWrite();
        }


        public void CheckNumber(ulong init_number)
        {
            ulong num = init_number;
            int counter = 0;

            var nums = new SortedSet<ulong>();
            while (counter < MAX_CHECK_STREAK)
            {
                if (checkedNumbers.Contains(num) || num <= maxCheckedNumber)
                {
                    if (nums.Count > 0)
                        checkedNumbers.UnionWith(nums);
                    return;
                }
                nums.Add(num);
                checked
                {
                    if (num % 2 == 0)
                        num /= 2;
                    else
                        num = 3 * num + 1;
                }
                counter++;
            }
            throw new ArgumentException($"value [{init_number}] does not fit Сollatz Рypothesis");
        }
    }
}
