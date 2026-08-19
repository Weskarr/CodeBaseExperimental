using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MasterBase : MonoBehaviour, IMaster
{
    [Header("Directories")]
    [SerializeField] private ServicesDirectory _servicesDirectory;
    [SerializeField] private SystemsDirectory _systemsDirectory;

    [Header("Services Status")]
    [SerializeField] private bool _servicesInitialized;
    [SerializeField] private bool _servicesActivated;

    [Header("Systems Status")]
    [SerializeField] private bool _systemsInitialized;
    [SerializeField] private bool _systemsSubsActivated;
    [SerializeField] private bool _systemsDispatchersActivated;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    public ServicesDirectory ServicesDirectory => _servicesDirectory;
    public SystemsDirectory SystemsDirectory => _systemsDirectory;

    protected IReadOnlyList<ServiceBase> Services => _servicesDirectory.Services;
    protected IReadOnlyList<ManagerBase> Systems => _systemsDirectory.Systems;

    public event Action<float> UpdateTick;

    // |><>======================================================================================================<WB><|

    #region Unity

    protected virtual void OnEnable()
    {
        InitializeServices();
        InitializeSystems();

        ActivateServices();
        ActivateSystems();
    }

    protected virtual void OnDisable()
    {
        DeactivateSystems();
    }

    protected virtual void Update()
    {
        UpdateTick?.Invoke(Time.deltaTime);
    }

    #endregion

    #region Initialization

    private void InitializeServices()
    {
        if (_servicesInitialized)
            return;

        _servicesDirectory.Initialize();

        foreach (ServiceBase service in Services)
            service.Initialize(this);

        _servicesInitialized = true;
    }

    private void InitializeSystems()
    {
        if (_systemsInitialized)
            return;

        _systemsDirectory.Initialize();

        foreach (ManagerBase system in Systems)
            system.Initialize(this);

        _systemsInitialized = true;
    }

    #endregion

    #region Activation

    private void ActivateServices()
    {
        if (!_servicesInitialized || _servicesActivated)
            return;

        foreach (ServiceBase service in Services)
            service.Activate();

        _servicesActivated = true;
    }

    private void ActivateSystems()
    {
        if (!_systemsInitialized)
            return;

        if (!_systemsDispatchersActivated)
        {
            foreach (ManagerBase system in Systems)
                system.ActivateDispatcher();

            _systemsDispatchersActivated = true;
        }

        if (!_systemsSubsActivated)
        {
            foreach (ManagerBase system in Systems)
                system.Activate();

            _systemsSubsActivated = true;
        }
    }

    #endregion

    #region Deactivation

    private void DeactivateSystems()
    {
        DeactivateSubsystems();
        DeactivateDispatchers();
        DeactivateServices();
    }

    private void DeactivateSubsystems()
    {
        if (!_systemsSubsActivated)
            return;

        foreach (ManagerBase system in Systems)
            system.DeactivateSubsystems();

        _systemsSubsActivated = false;
    }

    private void DeactivateDispatchers()
    {
        if (!_systemsDispatchersActivated)
            return;

        foreach (ManagerBase system in Systems)
            system.DeactivateDispatcher();

        _systemsDispatchersActivated = false;
    }

    private void DeactivateServices()
    {
        if (!_servicesActivated)
            return;

        foreach (ServiceBase service in Services)
            service.Deactivate();

        _servicesActivated = false;
    }

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}