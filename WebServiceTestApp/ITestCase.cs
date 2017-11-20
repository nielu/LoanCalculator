namespace WebServiceTestApp
{
    public interface ITestCase
    {
        void Prepare();
        void Execute();
        void Cleanup();
    }
}
