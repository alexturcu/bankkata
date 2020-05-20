using bankkata.domain.helpers;
using FluentAssertions;

namespace bankkata.tests.feature
{
    public class ClockTests
    {
        public void Return_Todays_Date_In_dd_MM_yyyy_Format()
        {
            Clock clock = new Clock();
            
            string date = clock.TodayAsString();

            date.Should().Be("24/04/2015");
        }        
    }
}