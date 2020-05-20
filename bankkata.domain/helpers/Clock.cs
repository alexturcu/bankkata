using System;
using bankkata.domain.helpers.contracts;

namespace bankkata.domain.helpers
{
    public class Clock : IClock
    {
        public const string DD_MM_YYYY = "dd/MM/yyyy";

        public string TodayAsString()
        {
            return Today().ToString(DD_MM_YYYY);
        }

        protected virtual DateTime Today()
        {
            return DateTime.Now;
        }
    }
}