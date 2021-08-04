using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace СollatzРypothesisApp
{
    class CollatzChecker
    {
        const int MAX_CHECK_STREAK = 5_000_000;
        ulong maxCheckedNumber = 1;
        SortedSet<ulong> checkedNumbers = new SortedSet<ulong>();
        public ulong MaxCheckedNumber { get { return maxCheckedNumber; } }

        public ulong[] CheckedNumbers { get { return checkedNumbers.ToArray(); } }



        public CollatzChecker()
        {
            checkedNumbers.Add(1);
        }

        public void SetMaxCheckedNumber()
        {
            ulong counter = maxCheckedNumber + 1;
            while (checkedNumbers.Contains(counter))
                counter++;
            maxCheckedNumber = counter - 1;
            checkedNumbers.RemoveWhere(i => i <= maxCheckedNumber);
        }

        public void CheckNumber(ulong num)
        {
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
            throw new ArgumentException("Not a 1");
        }
    }
}
