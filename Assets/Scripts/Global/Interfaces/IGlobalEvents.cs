public interface IGlobalEvents
{
    // This methods should be passed through the eventhandler, which should exist in a gameobject
    // that uses this interface
    public void Ready();
    public void Active();
    public void Cooldown();

    public EventHandler EHandler { get; }
}
