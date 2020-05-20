using System;
using bankkata.domain.helpers;

namespace bankkata.tests.feature
{
    internal class TestableClock : Clock
    {
        protected override DateTime Today()
        {
            return new DateTime(2015, 4, 24);
        }
    }
}