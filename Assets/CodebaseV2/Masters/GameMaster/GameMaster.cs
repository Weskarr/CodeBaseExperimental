using UnityEngine;
using TimeSystem;

public class GameMaster : MasterBase
{
    //[Header("Directories")]
    //[SerializeField] private ServicesDirectory _servicesDirectory;
    //[SerializeField] private SystemsDirectory _systemsDirectory;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    public InputService InputService => ServicesDirectory.GetService<InputService>();
    public TimeManager TimeManager => SystemsDirectory.GetSystem<TimeManager>();

    public Transform SystemParentRoot => transform;

    // |><>======================================================================================================<WB><|
}