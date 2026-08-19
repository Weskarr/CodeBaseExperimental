
using UnityEngine;

namespace TimeSystem
{
    [System.Serializable]
    public class TimeBlackboard : IBlackboard
    {
        [Header("System")]
        [SerializeField] private Transform _systemContainer;

        [Header("Update Variables")]
        [SerializeField] private bool _isTimeStopped = false;
        [SerializeField] private float _timeGameSpeed = 1f;
        [SerializeField] private float _timeMultiplier = 1f;

        [Header("Preset Variables")]
        [SerializeField] private TimeRulesPreset _timeRulesPreset;

        [Header("Current SO Sets")]
        [SerializeField] private TimeHourSet _currentHourSet;
        [SerializeField] private TimeWeekdaySet _currentWeekDaySet;
        [SerializeField] private TimeMonthSet _currentMonthSet;

        [Header("Current Time Variables")]
        [SerializeField] private float _currentTimeStep = 0f;   // Internal time accumulator. (Rounded down per tick)
        [SerializeField] private int _currentSeconds;
        [SerializeField] private int _currentMinutes;
        [SerializeField] private int _currentDays;
        [SerializeField] private int _currentWeek;
        [SerializeField] private int _currentYear;
        [SerializeField] private int _currentDayOfYear; // Current day of the year, nice to have.
        [SerializeField] private bool _isCurrentlyLeapYear; // Currently leap year, also nice to have.

        [Header("Index Variables")]
        [SerializeField] private int _currentQuarterIndex;  // Index of the current quarter of the hour.
        [SerializeField] private int _currentHoursIndex;    // Index of the current hour of the day.
        [SerializeField] private int _currentWeekDayIndex;  // Index of the current day of the week.
        [SerializeField] private int _currentMonthIndex;    // Index of the current month of the year.
        [SerializeField] private int _currentMonthDayIndex; // Index of the current day in the month.

        // |><>======================================================================================================<WB><|

        #region Getters

        // System
        public Transform GetSystemContainer => _systemContainer;

        // Update Variables
        public bool GetIsTimeStopped => _isTimeStopped;
        public float GetTimeGameSpeed => _timeGameSpeed;
        public float GetTimeMultiplier => _timeMultiplier;
        public float GetCurrentTimeStep => _currentTimeStep;

        // Preset Variables
        public TimeRulesPreset GetTimeRulesPreset => _timeRulesPreset;

        // Current SO Sets
        public TimeHourSet GetCurrentHourSet => _currentHourSet;
        public TimeWeekdaySet GetCurrentWeekDaySet => _currentWeekDaySet;
        public TimeMonthSet GetCurrentMonthSet => _currentMonthSet;

        // Current Time Variables
        public int GetCurrentSeconds => _currentSeconds;
        public int GetCurrentMinutes => _currentMinutes;
        public int GetCurrentDays => _currentDays;
        public int GetCurrentWeek => _currentWeek;
        public int GetCurrentYear => _currentYear;
        public int GetCurrentDayOfYear => _currentDayOfYear;
        public bool GetIsCurrentlyLeapYear => _isCurrentlyLeapYear;

        // Index Variables
        public int GetCurrentQuarterIndex => _currentQuarterIndex;
        public int GetCurrentHoursIndex => _currentHoursIndex;
        public int GetCurrentWeekDayIndex => _currentWeekDayIndex;
        public int GetCurrentMonthIndex => _currentMonthIndex;
        public int GetCurrentMonthDayIndex => _currentMonthDayIndex;

        #endregion

        #region Modifications (Only allowed from within namespace!)

        // System
        public void SetSystemContainer(Transform set) => _systemContainer = set;

        // Update Variables
        public void SetIsTimeStopped(bool value) => _isTimeStopped = value;
        public void SetTimeGameSpeed(float value) => _timeGameSpeed = value;
        public void SetTimeMultiplier(float value) => _timeMultiplier = value;
        public void SetCurrentTimeStep(float value) => _currentTimeStep = value;

        // Preset Variables
        public void SetTimeRulesPreset(TimeRulesPreset value) => _timeRulesPreset = value;

        // Current SO Sets
        public void SetCurrentHourSet(TimeHourSet value) => _currentHourSet = value;
        public void SetCurrentWeekDaySet(TimeWeekdaySet value) => _currentWeekDaySet = value;
        public void SetCurrentMonthSet(TimeMonthSet value) => _currentMonthSet = value;

        // Current Time Variables
        public void SetCurrentSeconds(int value) => _currentSeconds = value;
        public void SetCurrentMinutes(int value) => _currentMinutes = value;
        public void SetCurrentDays(int value) => _currentDays = value;
        public void SetCurrentWeek(int value) => _currentWeek = value;
        public void SetCurrentYear(int value) => _currentYear = value;
        public void SetCurrentDayOfYear(int value) => _currentDayOfYear = value;
        public void SetIsCurrentlyLeapYear(bool value) => _isCurrentlyLeapYear = value;

        // Index Variables
        public void SetCurrentQuarterIndex(int value) => _currentQuarterIndex = value;
        public void SetCurrentHoursIndex(int value) => _currentHoursIndex = value;
        public void SetCurrentWeekDayIndex(int value) => _currentWeekDayIndex = value;
        public void SetCurrentMonthIndex(int value) => _currentMonthIndex = value;
        public void SetCurrentMonthDayIndex(int value) => _currentMonthDayIndex = value;

        #endregion

        // |><>------------------------------------------------------------------------------------------------------<WB><|
    }
}