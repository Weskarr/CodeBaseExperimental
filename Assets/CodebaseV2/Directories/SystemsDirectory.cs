using UnityEngine;
using System.Collections.Generic;

public class SystemsDirectory : MonoBehaviour
{
    public IReadOnlyList<ManagerBase> Systems => _systems;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    [Header("Debugging")]
    [SerializeField] private List<ManagerBase> _systems = new();

    // |><>======================================================================================================<WB><|

    public void Initialize()
    {
        _systems.Clear();

        GetComponentsInChildren(true, _systems);
    }

    public T GetSystem<T>() where T : ManagerBase
    {
        foreach (ManagerBase system in _systems)
        {
            if (system is T typedSystem)
                return typedSystem;
        }

        Debug.LogError($"System of type {typeof(T).Name} was not found.");
        return null;
    }
}
