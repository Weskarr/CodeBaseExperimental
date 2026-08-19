
public abstract class ReferencesBase<TManager, TBlackboard, TDispatcher> : IReferences
{
    // System Core.
    public TManager Manager { get; private set; }
    public TBlackboard Blackboard { get; private set; }
    public TDispatcher Dispatcher { get; private set; }

    // |><>======================================================================================================<WB><|

    #region Setup

    public virtual void SetupCore
    (
        TManager manager,
        TBlackboard blackboard,
        TDispatcher dispatcher
    )
    {
        Manager = manager;
        Blackboard = blackboard;
        Dispatcher = dispatcher;
    }

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}