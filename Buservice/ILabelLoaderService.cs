using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace LabelLoader.Buservice
{
    public interface ILabelLoaderService
    {
        bool HandleException(Task task);
        Task SendAsync(TopicClient topicClient);
        void SendMessagesAsync(string message);
    }
}