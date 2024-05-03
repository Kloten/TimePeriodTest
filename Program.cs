using Itenso.TimePeriod;
using System.Security;

namespace TimePeriodExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime testDate = new DateTime(2024, 03, 13);
            DateTime testDate2 = new DateTime(2024, 03, 18);

            DateTime start = new DateTime(2016, 5, 7, 9, 50, 54);
            DateTime end = new DateTime(2019, 5, 7, 9, 50, 54);

            //DaySeekerSample();

            //DateAddSample();

            //TimePeriodSubtractorSample();

            //TimeGapCalculatorSample();

            //DateDiffSample();

            //CalendarWeekSample();

            //Console.WriteLine(IsInCurrentWeek(testDate2));

            //GetDaysOfCurrentQuarter(testDate2, out DateTime firstDay, out DateTime lastDay);
            //Console.WriteLine(firstDay.ToString() + "\n" + lastDay.ToString());

            //GetDaysOfPastQuarter(testDate2, out DateTime firstDay, out DateTime lastDay);
            //Console.WriteLine(firstDay.ToString() + " " + lastDay.ToString());

            //Console.WriteLine(IntersectsYear(testDate, testDate2, 2023));

            //Console.WriteLine(GetFirstDayOfWeek(testDate2));

            //Console.WriteLine(IsInCurrentWeek(testDate));
            //Console.WriteLine(IsInCurrentWeek(testDate2));

            //YearStartSample();
        }

        // ----------------------------------------------------------------------
        public static bool IntersectsYear(DateTime start, DateTime end, int year)
        {
            return new Year(year).IntersectsWith(new TimeRange(start, end));
        } // IntersectsYear

        // ----------------------------------------------------------------------

        public static void GetDaysOfCurrentQuarter(DateTime moment, out DateTime firstDay, out DateTime lastDay)
        {
            TimeCalendar calendar = new TimeCalendar(
                new TimeCalendarConfig { YearBaseMonth = YearMonth.October });
            Quarter currentQuarter = new Quarter(calendar);

            firstDay = currentQuarter.FirstDayStart;
            lastDay = currentQuarter.LastDayStart;
        }

        // ----------------------------------------------------------------------
        public static void GetDaysOfPastQuarter(DateTime moment,
               out DateTime firstDay, out DateTime lastDay)
        {
            TimeCalendar calendar = new TimeCalendar(
              new TimeCalendarConfig { YearBaseMonth = YearMonth.October });
            Quarter quarter = new Quarter(moment, calendar);
            Quarter pastQuarter = quarter.GetPreviousQuarter();

            firstDay = pastQuarter.FirstDayStart;
            lastDay = pastQuarter.LastDayStart;
        } // GetDaysOfPastQuarter

        // ----------------------------------------------------------------------
        public static DateTime GetFirstDayOfWeek(DateTime moment)
        {
            return new Week(moment).FirstDayStart;
        } // GetFirstDayOfWeek

        // ----------------------------------------------------------------------
        public static bool IsInCurrentWeek(DateTime test)
        {
            return new Week().HasInside(test);
        } // IsInCurrentWeek


        //Years
        // ----------------------------------------------------------------------
        public static void YearStartSample()
        {
            TimeCalendar calendar = new TimeCalendar(
              new TimeCalendarConfig { YearBaseMonth = YearMonth.February });

            Years years = new Years(2024, 2, calendar); // 2012-2013
            Console.WriteLine("Quarters of Years (February): {0}", years);

            foreach (Year year in years.GetYears())
            {
                foreach (Quarter quarter in year.GetQuarters())
                {
                    Console.WriteLine("Quarter: {0}", quarter);
                }
            }
        } // YearStartSample


        // Weeks
        // ----------------------------------------------------------------------
        // see also http://blogs.msdn.com/b/shawnste/archive/2006/01/24/517178.aspx
        public static void CalendarWeekSample()
        {
            DateTime testDate = new DateTime(2007, 12, 31);

            // .NET calendar week
            TimeCalendar calendar = new TimeCalendar();
            Console.WriteLine("Calendar Week of {0}: {1}", testDate.ToShortDateString(),
                               new Week(testDate, calendar).WeekOfYear);
            // > Calendar Week of 31.12.2007: 53

            // ISO 8601 calendar week
            TimeCalendar calendarIso8601 = new TimeCalendar(
              new TimeCalendarConfig { YearWeekType = YearWeekType.Iso8601 });
            Console.WriteLine("ISO 8601 Week of {0}: {1}", testDate.ToShortDateString(),
                               new Week(testDate, calendarIso8601).WeekOfYear);
            // > ISO 8601 Week of 31.12.2007: 1
        } // CalendarWeekSample


        //DateDiff
        // ----------------------------------------------------------------------
        public static void DateDiffSample()
        {
            DateTime date1 = new DateTime(2009, 11, 8, 7, 13, 59);
            Console.WriteLine("Date1: {0}", date1);
            // > Date1: 08.11.2009 07:13:59
            DateTime date2 = new DateTime(2011, 3, 20, 19, 55, 28);
            Console.WriteLine("Date2: {0}", date2);
            // > Date2: 20.03.2011 19:55:28

            DateDiff dateDiff = new DateDiff(date1, date2);

            // differences
            Console.WriteLine("DateDiff.Years: {0}", dateDiff.Years);
            // > DateDiff.Years: 1
            Console.WriteLine("DateDiff.Quarters: {0}", dateDiff.Quarters);
            // > DateDiff.Quarters: 5
            Console.WriteLine("DateDiff.Months: {0}", dateDiff.Months);
            // > DateDiff.Months: 16
            Console.WriteLine("DateDiff.Weeks: {0}", dateDiff.Weeks);
            // > DateDiff.Weeks: 70
            Console.WriteLine("DateDiff.Days: {0}", dateDiff.Days);
            // > DateDiff.Days: 497
            Console.WriteLine("DateDiff.Weekdays: {0}", dateDiff.Weekdays);
            // > DateDiff.Weekdays: 71
            Console.WriteLine("DateDiff.Hours: {0}", dateDiff.Hours);
            // > DateDiff.Hours: 11940
            Console.WriteLine("DateDiff.Minutes: {0}", dateDiff.Minutes);
            // > DateDiff.Minutes: 716441
            Console.WriteLine("DateDiff.Seconds: {0}", dateDiff.Seconds);
            // > DateDiff.Seconds: 42986489

            // elapsed
            Console.WriteLine("DateDiff.ElapsedYears: {0}", dateDiff.ElapsedYears);
            // > DateDiff.ElapsedYears: 1
            Console.WriteLine("DateDiff.ElapsedMonths: {0}", dateDiff.ElapsedMonths);
            // > DateDiff.ElapsedMonths: 4
            Console.WriteLine("DateDiff.ElapsedDays: {0}", dateDiff.ElapsedDays);
            // > DateDiff.ElapsedDays: 12
            Console.WriteLine("DateDiff.ElapsedHours: {0}", dateDiff.ElapsedHours);
            // > DateDiff.ElapsedHours: 12
            Console.WriteLine("DateDiff.ElapsedMinutes: {0}", dateDiff.ElapsedMinutes);
            // > DateDiff.ElapsedMinutes: 41
            Console.WriteLine("DateDiff.ElapsedSeconds: {0}", dateDiff.ElapsedSeconds);
            // > DateDiff.ElapsedSeconds: 29

            // description
            Console.WriteLine("DateDiff.GetDescription(1): {0}", dateDiff.GetDescription(1));
            // > DateDiff.GetDescription(1): 1 Year
            Console.WriteLine("DateDiff.GetDescription(2): {0}", dateDiff.GetDescription(2));
            // > DateDiff.GetDescription(2): 1 Year 4 Months
            Console.WriteLine("DateDiff.GetDescription(3): {0}", dateDiff.GetDescription(3));
            // > DateDiff.GetDescription(3): 1 Year 4 Months 12 Days
            Console.WriteLine("DateDiff.GetDescription(4): {0}", dateDiff.GetDescription(4));
            // > DateDiff.GetDescription(4): 1 Year 4 Months 12 Days 12 Hours
            Console.WriteLine("DateDiff.GetDescription(5): {0}", dateDiff.GetDescription(5));
            // > DateDiff.GetDescription(5): 1 Year 4 Months 12 Days 12 Hours 41 Mins
            Console.WriteLine("DateDiff.GetDescription(6): {0}", dateDiff.GetDescription(6));
            // > DateDiff.GetDescription(6): 1 Year 4 Months 12 Days 12 Hours 41 Mins 29 Secs
        } // DateDiffSample


        // TimeGapCalculator
        // ----------------------------------------------------------------------
        public static void TimeGapCalculatorSample()
        {
            // simulation of some reservations
            TimePeriodCollection reservations = new TimePeriodCollection();
            reservations.Add(new Days(2011, 3, 7, 2));
            reservations.Add(new Days(2011, 3, 16, 2));

            // the overall search range
            CalendarTimeRange searchLimits = new CalendarTimeRange(
                new DateTime(2011, 3, 4), new DateTime(2011, 3, 21));

            // search the largest free time block
            ICalendarTimeRange largestFreeTimeBlock =
                FindLargestFreeTimeBlock(reservations, searchLimits);
            Console.WriteLine("Largest free time: " + largestFreeTimeBlock);
            // > Largest free time: 09.03.2011 00:00:00 - 11.03.2011 23:59:59 | 2.23:59
        } // TimeGapCalculatorSample

        // ----------------------------------------------------------------------
        public static ICalendarTimeRange FindLargestFreeTimeBlock(
               IEnumerable<ITimePeriod> reservations,
               ITimePeriod searchLimits = null, bool excludeWeekends = true)
        {
            TimePeriodCollection bookedPeriods = new TimePeriodCollection(reservations);

            if (searchLimits == null)
            {
                searchLimits = bookedPeriods; // use boundary of reservations
            }

            if (excludeWeekends)
            {
                Week currentWeek = new Week(searchLimits.Start);
                Week lastWeek = new Week(searchLimits.End);
                do
                {
                    ITimePeriodCollection days = currentWeek.GetDays();
                    foreach (Day day in days)
                    {
                        if (!searchLimits.HasInside(day))
                        {
                            continue; // outside of the search scope
                        }
                        if (day.DayOfWeek == DayOfWeek.Saturday ||
                             day.DayOfWeek == DayOfWeek.Sunday)
                        {
                            bookedPeriods.Add(day); // // exclude weekend day
                        }
                    }
                    currentWeek = currentWeek.GetNextWeek();
                } while (currentWeek.Start < lastWeek.Start);
            }

            // calculate the gaps using the time calendar as period mapper
            TimeGapCalculator<TimeRange> gapCalculator =
              new TimeGapCalculator<TimeRange>(new TimeCalendar());
            ITimePeriodCollection freeTimes =
              gapCalculator.GetGaps(bookedPeriods, searchLimits);
            if (freeTimes.Count == 0)
            {
                return null;
            }

            freeTimes.SortByDuration(); // move the largest gap to the start
            return new CalendarTimeRange(freeTimes[0]);
        } // FindLargestFreeTimeBlock


        // Subtractor
        // ----------------------------------------------------------------------
        public static void TimePeriodSubtractorSample()
        {
            DateTime moment = new DateTime(2012, 1, 29);
            TimePeriodCollection sourcePeriods = new TimePeriodCollection
            {
                new TimeRange( moment.AddHours( 2 ), moment.AddDays( 1 ) )
            };

            TimePeriodCollection subtractingPeriods = new TimePeriodCollection
            {
                new TimeRange( moment.AddHours( 6 ), moment.AddHours( 10 ) ),
                new TimeRange( moment.AddHours( 12 ), moment.AddHours( 16 ) )
            };

            TimePeriodSubtractor<TimeRange> subtractor = new TimePeriodSubtractor<TimeRange>();
            ITimePeriodCollection subtractedPeriods =
              subtractor.SubtractPeriods(sourcePeriods, subtractingPeriods);
            foreach (TimeRange subtractedPeriod in subtractedPeriods)
            {
                Console.WriteLine("Subtracted Period: {0}", subtractedPeriod); // The result contains the differences between the two time period collections
            }
            // > Subtracted Period : 29.01.2012 02:00:00 - 06:00:00 | 0.04:00
            // > Subtracted Period : 29.01.2012 10:00:00 - 12:00:00 | 0.02:00
            // > Subtracted Period : 29.01.2012 16:00:00 - 30.01.2012 00:00:00 | 0.08:00
        } // TimePeriodSubtractorSample


        // DateAdd
        // ----------------------------------------------------------------------
        public static void DateAddSample()
        {
            DateAdd dateAdd = new DateAdd();

            dateAdd.IncludePeriods.Add(new TimeRange(new DateTime(2011, 3, 17),
                                        new DateTime(2011, 4, 20)));

            // setup some periods to exclude
            dateAdd.ExcludePeriods.Add(new TimeRange(
              new DateTime(2011, 3, 22), new DateTime(2011, 3, 25)));
            dateAdd.ExcludePeriods.Add(new TimeRange(
              new DateTime(2011, 4, 1), new DateTime(2011, 4, 7)));
            dateAdd.ExcludePeriods.Add(new TimeRange(
              new DateTime(2011, 4, 15), new DateTime(2011, 4, 16)));

            // positive
            DateTime dateDiffPositive = new DateTime(2011, 3, 19);
            DateTime? positive1 = dateAdd.Add(dateDiffPositive, Duration.Hours(1));
            Console.WriteLine("DateAdd Positive1: {0}", positive1);
            // > DateAdd Positive1: 19.03.2011 01:00:00
            DateTime? positive2 = dateAdd.Add(dateDiffPositive, Duration.Days(4));
            Console.WriteLine("DateAdd Positive2: {0}", positive2);
            // > DateAdd Positive2: 26.03.2011 00:00:00
            DateTime? positive3 = dateAdd.Add(dateDiffPositive, Duration.Days(17));
            Console.WriteLine("DateAdd Positive3: {0}", positive3);
            // > DateAdd Positive3: 14.04.2011 00:00:00
            DateTime? positive4 = dateAdd.Add(dateDiffPositive, Duration.Days(20));
            Console.WriteLine("DateAdd Positive4: {0}", positive4);
            // > DateAdd Positive4: 18.04.2011 00:00:00

            // negative
            DateTime dateDiffNegative = new DateTime(2011, 4, 18);
            DateTime? negative1 = dateAdd.Add(dateDiffNegative, Duration.Hours(-1));
            Console.WriteLine("DateAdd Negative1: {0}", negative1);
            // > DateAdd Negative1: 17.04.2011 23:00:00
            DateTime? negative2 = dateAdd.Add(dateDiffNegative, Duration.Days(-4));
            Console.WriteLine("DateAdd Negative2: {0}", negative2);
            // > DateAdd Negative2: 13.04.2011 00:00:00
            DateTime? negative3 = dateAdd.Add(dateDiffNegative, Duration.Days(-17));
            Console.WriteLine("DateAdd Negative3: {0}", negative3);
            // > DateAdd Negative3: 22.03.2011 00:00:00
            DateTime? negative4 = dateAdd.Add(dateDiffNegative, Duration.Days(-20));
            Console.WriteLine("DateAdd Negative4: {0}", negative4);
            // > DateAdd Negative4: 19.03.2011 00:00:00
        } // DateAddSample

        // CalendarDateAdd
        // ----------------------------------------------------------------------
        public static void CalendarDateAddSample()
        {
            CalendarDateAdd calendarDateAdd = new CalendarDateAdd();
            // weekdays
            calendarDateAdd.AddWorkingWeekDays();
            // holidays
            calendarDateAdd.ExcludePeriods.Add(new Day(2011, 4, 5, calendarDateAdd.Calendar));
            // working hours
            calendarDateAdd.WorkingHours.Add(new HourRange(new Time(08, 30), new Time(12)));
            calendarDateAdd.WorkingHours.Add(new HourRange(new Time(13, 30), new Time(18)));

            DateTime start = new DateTime(2011, 4, 1, 9, 0, 0);
            TimeSpan offset = new TimeSpan(22, 0, 0); // 22 hours

            DateTime? end = calendarDateAdd.Add(start, offset);

            Console.WriteLine("start: {0}", start);
            // > start: 01.04.2011 09:00:00
            Console.WriteLine("offset: {0}", offset);
            // > offset: 22:00:00
            Console.WriteLine("end: {0}", end);
            // > end: 06.04.2011 16:30:00
        } // CalendarDateAddSample


        // CalendarPeriods
        // ----------------------------------------------------------------------
        public static void CalendarPeriodCollectorSample()
        {
            CalendarPeriodCollectorFilter filter = new CalendarPeriodCollectorFilter();
            filter.Months.Add(YearMonth.January); // only Januaries
            filter.WeekDays.Add(DayOfWeek.Friday); // only Fridays
            filter.CollectingHours.Add(new HourRange(8, 18)); // working hours

            CalendarTimeRange testPeriod =
              new CalendarTimeRange(new DateTime(2010, 1, 1), new DateTime(2011, 12, 31));
            Console.WriteLine("Calendar period collector of period: " + testPeriod);
            // > Calendar period collector of period:
            //            01.01.2010 00:00:00 - 30.12.2011 23:59:59 | 728.23:59

            CalendarPeriodCollector collector =
                    new CalendarPeriodCollector(filter, testPeriod);
            collector.CollectHours();
            foreach (ITimePeriod period in collector.Periods)
            {
                Console.WriteLine("Period: " + period);
            }
            // > Period: 01.01.2010; 08:00 - 17:59 | 0.09:59
            // > Period: 08.01.2010; 08:00 - 17:59 | 0.09:59
            // > Period: 15.01.2010; 08:00 - 17:59 | 0.09:59
            // > Period: 22.01.2010; 08:00 - 17:59 | 0.09:59
            // > Period: 29.01.2010; 08:00 - 17:59 | 0.09:59
            // > Period: 07.01.2011; 08:00 - 17:59 | 0.09:59
            // > Period: 14.01.2011; 08:00 - 17:59 | 0.09:59
            // > Period: 21.01.2011; 08:00 - 17:59 | 0.09:59
            // > Period: 28.01.2011; 08:00 - 17:59 | 0.09:59
        } // CalendarPeriodCollectorSample

        // DaySeeker
        // ----------------------------------------------------------------------
        public static void DaySeekerSample()
        {
            Day start = new Day(new DateTime(2011, 2, 15));
            Console.WriteLine("DaySeeker Start: " + start);
            // > DaySeeker Start: Dienstag; 15.02.2011 | 0.23:59

            CalendarVisitorFilter filter = new CalendarVisitorFilter();
            filter.AddWorkingWeekDays(); // only working days
            filter.ExcludePeriods.Add(new Week(2011, 9));  // week #9
            Console.WriteLine("DaySeeker Holidays: " + filter.ExcludePeriods[0]);
            // > DaySeeker Holidays: w/c 9 2011; 28.02.2011 - 06.03.2011 | 6.23:59

            DaySeeker daySeeker = new DaySeeker(filter);
            Day day1 = daySeeker.FindDay(start, 3); // same working week
            Console.WriteLine("DaySeeker(3): " + day1);
            // > DaySeeker(3): Freitag; 18.02.2011 | 0.23:59

            Day day2 = daySeeker.FindDay(start, 4); // Saturday -> next Monday
            Console.WriteLine("DaySeeker(4): " + day2);
            // > DaySeeker(4): Montag; 21.02.2011 | 0.23:59

            Day day3 = daySeeker.FindDay(start, 9); // holidays -> next Monday
            Console.WriteLine("DaySeeker(9): " + day3);
            // > DaySeeker(9): Montag; 07.03.2011 | 0.23:59
        } // DaySeekerSample


        public void minutes
    }
}
