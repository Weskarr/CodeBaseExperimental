using System;
using UnityEngine;

[System.Serializable]
public abstract class ServiceBase : MonoBehaviour, IService
{
    [Header("Service Status")]
    [SerializeField] private bool _isInitialized = false;
    [SerializeField] private bool _isActivated = false;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    // Master connection.
    [NonSerialized] protected GameMaster _managerMaster; // IMaster instead? Idk this is easier for now..

    // |><>======================================================================================================<WB><|

    #region Initialize Service

    public void Initialize(IMaster master)
    {
        // Safety Check.
        if (!CanInitialize())
            return;

        // Check Master & Assign it.
        if (!MasterSafetyCheck(master))
            return;

        // Initialize the service.
        OnInitializeService();

        // Change status..
        _isInitialized = true;
    }

    protected abstract void OnInitializeService();

    #endregion

    #region Activate Service

    public void Activate()
    {
        // Safety Check.
        if (!CanActivate())
            return;

        // Activate the service.
        OnActivateService();

        // Change status..
        _isActivated = true;
    }

    protected abstract void OnActivateService();

    #endregion

    #region Deactivate Service

    public void Deactivate()
    {
        // Safety Check.
        if (!CanDeactivate())
            return;

        // Deactivate the service.
        OnDeactivateService();

        // Change status..
        _isActivated = false;
    }

    protected abstract void OnDeactivateService();

    #endregion

    #region Safety Checks

    protected virtual bool CanInitialize()
    {
        if (_isInitialized)
        {
            Debug.LogError($"ServiceBase is already initialized!");
            return false;
        }

        return true;
    }

    protected virtual bool CanActivate()
    {
        if (!_isInitialized)
        {
            Debug.LogError($"ServiceBase cannot be activated before initialization!");
            return false;
        }

        if (_isActivated)
        {
            Debug.LogError($"ServiceBase is already activated!");
            return false;
        }

        return true;
    }

    protected virtual bool CanDeactivate()
    {
        if (!_isActivated)
        {
            Debug.LogError($"ServiceBase is already deactivated!");
            return false;
        }

        return true;
    }

    protected virtual bool MasterSafetyCheck(IMaster master)
    {
        if (master == null)
        {
            Debug.LogError($"ServiceBase requires master!");
            return false;
        }

        _managerMaster = master as GameMaster;

        return true;
    }

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}