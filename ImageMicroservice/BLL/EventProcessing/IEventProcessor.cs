namespace ImageMicroservice.BLL.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}