
//using LevelSystem;

namespace TimeSystem
{
    public class TimeReferences : ReferencesBase<TimeManager, TimeBlackboard, TimeDispatcher>
    {
        // For cross-system data! (From Systems)

        //public LevelBlackboard LevelBlackboard { get; private set; }
        //public LevelDispatcher LevelDispatcher { get; private set; }

        // |><>======================================================================================================<WB><|

        #region Setup Externals

        public void SetupExternal(GameMaster master)
        {
            //LevelManager level = master.LevelManager;
            //LevelBlackboard = level.Blackboard;
            //LevelDispatcher = level.Dispatcher;
        }

        #endregion

        // |><>------------------------------------------------------------------------------------------------------<WB><|
    }
}