using System;
using UnityEngine;

[System.Serializable]
public abstract class SubBase : MonoBehaviour
{
    [Header("Subsystem Status")]
    [SerializeField] private bool _isActivated;

    public bool IsActivated => _isActivated;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    public void Deactivate()
    {
        if (!_isActivated)
            return;

        OnDeactivate();

        _isActivated = false;
    }

    protected void SetActivated()
    {
        _isActivated = true;
    }

    protected abstract void OnDeactivate();
}

[System.Serializable]
public abstract class SubBase<TReferences> : SubBase
{
    [NonSerialized] protected TReferences _references;

    // |><>======================================================================================================<WB><|

    public void Activate(TReferences references)
    {
        if (IsActivated)
            return;

        if (!ReferencesSafetyCheck(references))
            return;

        _references = references;

        OnActivate();

        SetActivated();
    }

    protected abstract void OnActivate();

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    protected override void OnDeactivate()
    {
        OnDeactivateInternal();

        _references = default;
    }

    protected abstract void OnDeactivateInternal();

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    protected virtual bool ReferencesSafetyCheck(TReferences references)
    {
        if (references == null)
        {
            Debug.LogError($"{GetType().Name} requires references!");
            return false;
        }

        return true;
    }
}