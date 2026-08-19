using System;
using UnityEngine;

[System.Serializable]
public abstract class ManagerBase : MonoBehaviour, IManager
{
    [Header("System Status")]
    [SerializeField] private bool _isInitialized = false;
    [SerializeField] private bool _isSubsActivated = false;
    [SerializeField] private bool _isDispatcherActivated = false;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    // Master connection.
    //[NonSerialized] protected GameMaster _managerMaster; // IMaster instead? Idk this is easier for now..
    [NonSerialized] protected MasterBase _master;

    // |><>======================================================================================================<WB><|

    #region Initialize System

    public void Initialize(MasterBase master)
    {
        if (!CanInitialize())
            return;

        // Check Master & Assign it.
        if (!MasterSafetyCheck(master))
            return;

        // At first just initialize the core.
        OnInitializeBlackboard();
        OnInitializeDispatcher();
        OnInitializeReferences();

        // Change status..
        _isInitialized = true;
    }
    protected abstract void OnInitializeBlackboard();
    protected abstract void OnInitializeDispatcher();
    protected abstract void OnInitializeReferences();

    #endregion

    #region Activate System

    public void Activate()
    {
        if (!CanActivate() || _isSubsActivated)
            return;

        // Now start Cross-Referencing & Sub-Systems.
        OnCrossReferences();
        OnActivateAllSubsystems();

        // Change status..
        _isSubsActivated = true;
    }

    public void ActivateDispatcher()
    {
        if (!CanActivate() || _isDispatcherActivated)
            return;

        OnActivateDispatcher();

        _isDispatcherActivated = true;
    }


    protected abstract void OnCrossReferences();
    protected abstract void OnActivateAllSubsystems();
    protected abstract void OnActivateDispatcher();

    #endregion

    #region Deactivate System

    public void DeactivateSubsystems()
    {
        if (!_isSubsActivated)
            return;

        OnDeactivateAllSubsystems();

        // Change status..
        _isSubsActivated = false;
    }

    public void DeactivateDispatcher()
    {
        if (!_isDispatcherActivated)
            return;

        OnDeactivateDispatcher();

        _isDispatcherActivated = false;
    }

    protected abstract void OnDeactivateAllSubsystems();
    protected abstract void OnDeactivateDispatcher();

    #endregion

    #region Safety Checks

    protected virtual bool CanInitialize()
    {
        if (_isInitialized)
        {
            Debug.LogError($"ManagerBase is already initialized!");
            return false;
        }

        return true;
    }

    protected virtual bool CanActivate()
    {
        if (!_isInitialized)
        {
            Debug.LogError($"ManagerBase cannot be activated before initialization!");
            return false;
        }

        /*
        if (_isSubsActivated && _isDispatcherActivated)
        {
            Debug.LogError($"ManagerBase is already activated!");
            return false;
        }
        */

        return true;
    }

    protected virtual bool CanDeactivate()
    {
        if (!_isSubsActivated && !_isDispatcherActivated)
        {
            Debug.LogError($"ManagerBase is already deactivated!");
            return false;
        }

        return true;
    }

    protected virtual bool MasterSafetyCheck(MasterBase master)
    {
        if (master == null)
        {
            Debug.LogError($"{GetType().Name} requires master!");
            return false;
        }

        _master = master;

        return true;
    }

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}