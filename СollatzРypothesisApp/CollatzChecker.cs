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
            if (_instanse == null) _instanse = new CollatzChecker();
            return _instanse;
        }

        private CollatzChecker() { ConfigRead(); }
        ~CollatzChecker() { ConfigSave(); }

        private void ConfigRead()
        {
            string str = Utils.SettingKeyRead("maxCheckedNumber");
            if (!ulong.TryParse(str, out ulong res))
                res = 2;
            maxCheckedNumber = res;
        }

        private void ConfigSave()
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
            ConfigSave();
        }


        public void CheckNumber(ulong init_number)
        {
            ulong num = init_number;
            int counter = 0;

            while (counter < MAX_CHECK_STREAK)
            {
                if (num <= maxCheckedNumber)
                {
                    if (!checkedNumbers.Contains(init_number))
                        checkedNumbers.Add(init_number);
                    return;
                }

                if (num % 2 == 0)
                    num /= 2;
                else
                    checked { num = 3 * num + 1; };
                counter++;
            }
            throw new ArgumentException($"value [{init_number}] does not fit Сollatz Рypothesis");
        }
    }
}
