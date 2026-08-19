using UnityEngine;
using System.Collections.Generic;

public class ServicesDirectory : MonoBehaviour
{
    public IReadOnlyList<ServiceBase> Services => _services;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    [Header("Debugging")]
    [SerializeField] private List<ServiceBase> _services = new();

    // |><>======================================================================================================<WB><|

    public void Initialize()
    {
        _services.Clear();

        GetComponentsInChildren(true, _services);
    }

    public T GetService<T>() where T : ServiceBase
    {
        foreach (ServiceBase service in _services)
        {
            if (service is T typedService)
                return typedService;
        }

        Debug.LogError($"Service of type {typeof(T).Name} was not found.");
        return null;
    }
}
