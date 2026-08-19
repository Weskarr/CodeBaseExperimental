
using UnityEngine;

namespace TimeSystem
{
    [System.Serializable]
    public class TimeClock : SubBase<TimeReferences>
    {
        //[Header("Status")]
        //[SerializeField] private bool _isActivated = false;

        // |><>------------------------------------------------------------------------------------------------------<WB><|

        //private TimeReferences _references;

        // |><>======================================================================================================<WB><|

        #region Activate

        protected override void OnActivate()
        {
            TimeBlackboard blackboard = _references.Blackboard;

            GrabCurrentWeekDaySet(blackboard.GetCurrentWeekDayIndex);
            GrabCurrentMonthSet(blackboard.GetCurrentMonthIndex);
            GrabCurrentHourSet(blackboard.GetCurrentHoursIndex);
        }

        #endregion

        #region Deactivate

        protected override void OnDeactivateInternal()
        {
        }

        #endregion

        #region Update Tick

        // Updating clock
        public void Tick(float deltaTime)
        {
            if (!IsActivated)
                return;

            TimeBlackboard blackboard = _references.Blackboard;
            TimeDispatcher dispatcher = _references.Dispatcher;

            // Is time allowed to run?
            if (blackboard.GetIsTimeStopped)
                return;

            // Accumulate scaled deltaTime in current time step.
            float currentTimeStep = blackboard.GetCurrentTimeStep;
            currentTimeStep += deltaTime * blackboard.GetTimeMultiplier * blackboard.GetTimeGameSpeed;

            // Also event this current time step.
            dispatcher.InvokeTimeStepTicked();

            // How many full seconds have passed
            int fullSeconds = Mathf.FloorToInt(currentTimeStep);

            if (fullSeconds > 0)
            {
                // Advance the clock once, with full multiplier.
                AdvanceOneSecond(fullSeconds);

                // Subtract the full seconds from the accumulator.
                currentTimeStep -= fullSeconds;
            }

            blackboard.SetCurrentTimeStep(currentTimeStep);
        }

        private void AdvanceOneSecond(int secondsMultiplier)
        {
            TimeBlackboard blackboard = _references.Blackboard;
            TimeDispatcher dispatcher = _references.Dispatcher;

            TimeRulesPreset rules = blackboard.GetTimeRulesPreset;

            int currentSeconds = blackboard.GetCurrentSeconds;
            int currentMinutes = blackboard.GetCurrentMinutes;
            int currentDays = blackboard.GetCurrentDays;
            int currentYear = blackboard.GetCurrentYear;
            int currentDayOfYear = blackboard.GetCurrentDayOfYear;
            bool isCurrentlyLeapYear = blackboard.GetIsCurrentlyLeapYear;
            int currentQuarterIndex = blackboard.GetCurrentQuarterIndex;
            int currentHoursIndex = blackboard.GetCurrentHoursIndex;
            int currentWeekDayIndex = blackboard.GetCurrentWeekDayIndex;
            int currentMonthIndex = blackboard.GetCurrentMonthIndex;
            int currentMonthDayIndex = blackboard.GetCurrentMonthDayIndex;

            int secondsAdvanced = secondsMultiplier;
            int minutesAdvanced = 0;
            int quartersAdvanced = 0;
            int hoursAdvanced = 0;
            int daysAdvanced = 0;
            int weeksAdvanced = 0;
            int monthsAdvanced = 0;
            int yearsAdvanced = 0;

            // Seconds
            currentSeconds += secondsAdvanced;

            if (currentSeconds >= rules.secondsPerMinute)
            {
                minutesAdvanced = currentSeconds / rules.secondsPerMinute;
                currentSeconds %= rules.secondsPerMinute;

                // Minutes
                currentMinutes += minutesAdvanced;

                // Quarters
                int previousQuarter = currentQuarterIndex;
                currentQuarterIndex = currentMinutes / rules.minutesPerQuarter;
                quartersAdvanced = currentQuarterIndex - previousQuarter;
                if (quartersAdvanced < 0)
                    quartersAdvanced += rules.quartersPerHour;

                if (currentMinutes >= rules.minutesPerHour)
                {
                    // Hours
                    hoursAdvanced = currentMinutes / rules.minutesPerHour;
                    currentMinutes %= rules.minutesPerHour;
                    currentHoursIndex += hoursAdvanced;

                    if (currentHoursIndex >= rules.hoursPerDay.Count)
                    {
                        // Days
                        daysAdvanced = currentHoursIndex / rules.hoursPerDay.Count;
                        currentHoursIndex %= rules.hoursPerDay.Count;
                        currentDays += daysAdvanced;
                        currentDayOfYear += daysAdvanced;

                        // Weeks
                        int totalWeekDays = currentWeekDayIndex + daysAdvanced;
                        currentWeekDayIndex = totalWeekDays % rules.daysPerWeek.Count;
                        weeksAdvanced = totalWeekDays / rules.daysPerWeek.Count;

                        if (daysAdvanced > 0)
                            GrabCurrentWeekDaySet(currentWeekDayIndex);

                        // Months
                        int remainingDays = currentMonthDayIndex + daysAdvanced;
                        int monthIndex = currentMonthIndex;
                        int year = currentYear;
                        bool leap = isCurrentlyLeapYear;

                        // Years
                        while (true)
                        {
                            int daysInMonth = leap ? 
                                rules.monthsPerYear[monthIndex].amountOfLeapYearDays : 
                                rules.monthsPerYear[monthIndex].amountOfCommonYearDays;

                            if (remainingDays <= daysInMonth)
                                break;

                            remainingDays -= daysInMonth;
                            monthIndex++;
                            monthsAdvanced++;

                            if (monthIndex >= rules.monthsPerYear.Count)
                            {
                                monthIndex -= rules.monthsPerYear.Count;
                                year++;
                                leap = IsLeapYear(year);
                                yearsAdvanced++;
                                currentDayOfYear = 0;
                            }

                            GrabCurrentMonthSet(monthIndex);
                        }

                        currentMonthIndex = monthIndex;
                        currentMonthDayIndex = remainingDays;
                        currentYear = year;
                        isCurrentlyLeapYear = leap;
                    }

                    if (hoursAdvanced > 0)
                        GrabCurrentHourSet(currentHoursIndex);
                }
            }

            blackboard.SetCurrentSeconds(currentSeconds);
            blackboard.SetCurrentMinutes(currentMinutes);
            blackboard.SetCurrentDays(currentDays);
            blackboard.SetCurrentYear(currentYear);
            blackboard.SetCurrentDayOfYear(currentDayOfYear);
            blackboard.SetIsCurrentlyLeapYear(isCurrentlyLeapYear);
            blackboard.SetCurrentQuarterIndex(currentQuarterIndex);
            blackboard.SetCurrentHoursIndex(currentHoursIndex);
            blackboard.SetCurrentWeekDayIndex(currentWeekDayIndex);
            blackboard.SetCurrentMonthIndex(currentMonthIndex);
            blackboard.SetCurrentMonthDayIndex(currentMonthDayIndex);

            // Invoke events with amounts.
            if (secondsAdvanced > 0) dispatcher.InvokeSecondsTicked(secondsAdvanced);
            if (quartersAdvanced > 0) dispatcher.InvokeQuartersTicked(quartersAdvanced);
            if (minutesAdvanced > 0) dispatcher.InvokeMinutesTicked(minutesAdvanced);
            if (hoursAdvanced > 0) dispatcher.InvokeHoursTicked(hoursAdvanced);
            if (daysAdvanced > 0) dispatcher.InvokeDaysTicked(daysAdvanced);
            if (weeksAdvanced > 0) dispatcher.InvokeWeeksTicked(weeksAdvanced);
            if (monthsAdvanced > 0) dispatcher.InvokeMonthsTicked(monthsAdvanced);
            if (yearsAdvanced > 0) dispatcher.InvokeYearsTicked(yearsAdvanced);
        }

        private bool IsLeapYear(int year)
        {
            TimeRulesPreset rules =
                _references.Blackboard.GetTimeRulesPreset;

            if (year % rules.unskipLeapYearsDivisibleBy == 0)
                return true;

            if (year % rules.skipLeapYearsDivisibleBy == 0)
                return false;

            return year % rules.LeapYearEveryDivisible == 0;
        }

        #endregion

        #region Grabbing Time Sets

        private void GrabCurrentWeekDaySet(int weekDayIndex)
        {
            TimeBlackboard blackboard = _references.Blackboard;
            blackboard.SetCurrentWeekDaySet(blackboard.GetTimeRulesPreset.daysPerWeek[weekDayIndex]);
        }

        private void GrabCurrentMonthSet(int monthIndex)
        {
            TimeBlackboard blackboard = _references.Blackboard;
            blackboard.SetCurrentMonthSet(blackboard.GetTimeRulesPreset.monthsPerYear[monthIndex]);
        }

        private void GrabCurrentHourSet(int hourIndex)
        {
            TimeBlackboard blackboard = _references.Blackboard;
            blackboard.SetCurrentHourSet(blackboard.GetTimeRulesPreset.hoursPerDay[hourIndex]);
        }

        #endregion

        // |><>------------------------------------------------------------------------------------------------------<WB><|
    }
}
