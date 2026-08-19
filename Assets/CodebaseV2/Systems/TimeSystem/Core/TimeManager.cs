
using System.Collections.Generic;
using UnityEngine;

namespace TimeSystem
{
    [System.Serializable]
    public class TimeManager : ManagerBase
    {
        [Header("System Core")]
        [SerializeField] private TimeBlackboard _blackboard; // Dummy to show in inspector.

        [Header("Sub-Systems")]
        [SerializeField] private TimeClock _timeClock;

        // |><>------------------------------------------------------------------------------------------------------<WB><|

        public TimeBlackboard Blackboard { get; private set; }
        public TimeDispatcher Dispatcher { get; private set; }
        public TimeReferences References { get; private set; }

        // |><>------------------------------------------------------------------------------------------------------<WB><|

        private readonly List<SubBase> _subsystems = new();
        protected IReadOnlyList<SubBase> Subsystems => _subsystems;

        // Quick Lists.
        //private readonly List<ISub<TimeReferences>> _subsystems = new();

        // |><>======================================================================================================<WB><|

        #region Subsystems Discovery

        protected void DiscoverSubsystems()
        {
            _subsystems.Clear();

            GetComponentsInChildren(true, _subsystems);
        }

        #endregion

        #region Initialize System

        protected override void OnInitializeBlackboard()
        {
            // Use pre-set inspector blackboard.
            Blackboard ??= _blackboard;
            Blackboard ??= new TimeBlackboard();
            _blackboard = Blackboard;
        }

        protected override void OnInitializeDispatcher()
        {
            Dispatcher ??= new();
        }

        protected override void OnInitializeReferences()
        {
            References ??= new();

            References.SetupCore
            (
                this,
                Blackboard,
                Dispatcher
            );
        }

        #endregion

        #region Activate System

        protected override void OnCrossReferences()
        {
            GameMaster gameMaster = _master as GameMaster;
            References.SetupExternal(gameMaster);
        }

        protected override void OnActivateAllSubsystems()
        {
            // Additionally make a scene container:
            GameObject container = new();
            container.transform.parent = this.transform;
            container.name = "TimeSystemContainer";
            Blackboard.SetSystemContainer(container.transform);

            DiscoverSubsystems();

            foreach (SubBase subsystem in Subsystems)
                if (subsystem is SubBase<TimeReferences> typedSubsystem)
                    typedSubsystem.Activate(References);

            SubscribeUpdateTick();
        }

        protected override void OnActivateDispatcher()
        {
            Dispatcher.Activate(Blackboard);
        }

        #endregion

        #region Deactivate System

        protected override void OnDeactivateAllSubsystems()
        {
            foreach (SubBase subsystem in Subsystems)
                if (subsystem is SubBase<TimeReferences> typedSubsystem)
                    typedSubsystem.Deactivate();

            UnsubscribeUpdateTick();
        }

        protected override void OnDeactivateDispatcher()
        {
            Dispatcher.Deactivate();
        }

        #endregion

        // For per frame time calculations.
        #region Update Tick System

        private void SubscribeUpdateTick()
        {
            _master.UpdateTick += UpdateTick;
        }

        private void UnsubscribeUpdateTick()
        {
            _master.UpdateTick -= UpdateTick;
        }

        private void UpdateTick(float deltaTime)
        {
            _timeClock.Tick(deltaTime);
        }

        #endregion

        // |><>------------------------------------------------------------------------------------------------------<WB><|
    }
}