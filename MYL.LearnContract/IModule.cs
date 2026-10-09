namespace MYL.LearnContract
{
    // LEKTION 3: Ein Vertrag (Interface) legt fest, was jedes Modul koennen muss.
    // Id, DisplayName, Version, Start, Stop und Receive sind vorgeschrieben.
    public interface IModule
    {
        string Id { get; }
        string DisplayName { get; }
        string Version { get; }
        void Start(IKernelContext context);
        void Stop();
        string Receive(string senderId, string message);
    }
}
