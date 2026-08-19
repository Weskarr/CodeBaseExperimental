
using System;
using UnityEngine;

namespace TimeSystem
{
    public class TimeDispatcher : IDispatcher
    {
        public event Action OnTimeStepTicked;
        public event Action<int> OnSecondsTicked;
        public event Action<int> OnMinutesTicked;
        public event Action<int> OnQuartersTicked;
        public event Action<int> OnHoursTicked;
        public event Action<int> OnDaysTicked;
        public event Action<int> OnWeeksTicked;
        public event Action<int> OnMonthsTicked;
        public event Action<int> OnYearsTicked;

        // |><>------------------------------------------------------------------------------------------------------<WB><|

        private TimeBlackboard _blackboard;

        // |><>======================================================================================================<WB><|

        #region Starter

        public void Activate(IBlackboard blackboard)
        {
            _blackboard = blackboard as TimeBlackboard;
            if (_blackboard == null)
                Debug.LogError("Dispatcher requires their respected Blackboard!");
        }

        #endregion

        #region Stopper

        public void Deactivate()
        {
            _blackboard = null;
        }

        #endregion

        #region Safety Check

        private bool BlackboardCheck()
        {
            if (_blackboard != null)
                return true;

            Debug.LogWarning("Blackboard is null?");
            return false;
        }

        #endregion

        #region Actions

        public void InvokeTimeStepTicked()
        {
            if (!BlackboardCheck())
                return;

            OnTimeStepTicked?.Invoke();
        }

        public void InvokeSecondsTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnSecondsTicked?.Invoke(amount);
        }

        public void InvokeMinutesTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnMinutesTicked?.Invoke(amount);
        }

        public void InvokeQuartersTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnQuartersTicked?.Invoke(amount);
        }

        public void InvokeHoursTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnHoursTicked?.Invoke(amount);
        }

        public void InvokeDaysTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnDaysTicked?.Invoke(amount);
        }

        public void InvokeWeeksTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnWeeksTicked?.Invoke(amount);
        }

        public void InvokeMonthsTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnMonthsTicked?.Invoke(amount);
        }

        public void InvokeYearsTicked(int amount)
        {
            if (!BlackboardCheck())
                return;

            OnYearsTicked?.Invoke(amount);
        }

        #endregion

        // |><>------------------------------------------------------------------------------------------------------<WB><|
    }
}