public interface IManager
{
    public void Initialize(MasterBase master);
    public void DeactivateSubsystems();
    public void DeactivateDispatcher();
}
