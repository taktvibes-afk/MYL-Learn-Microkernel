namespace MYL.LearnContract
{
    // Die Schnittstelle, über die ein Modul den Kernel ansprechen darf.
    public interface IKernelContext
    {
        void Log(string moduleId, string message);
    }
}
