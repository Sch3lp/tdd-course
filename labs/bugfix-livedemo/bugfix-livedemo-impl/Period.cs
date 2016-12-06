using System;

namespace bugfix_livedemo_impl
{
    public class Period
    {
        public Period(DateTime begin, DateTime end)
        {
            BeginDate = begin;
            EndDate = end;
        }

        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public bool IsInPeriod(DateTime date)
        {
            return BeginDate < date && EndDate > date;
        }
    }
}