using Messaging;

namespace Device
{
    public class BootstrapSettings
    {
        public Guid NewId { get; set; }
        public Queue<IMessage> NewMessages { get; set; }

        public BootstrapSettings()
        {
            NewMessages = new Queue<IMessage>();
        }
    }
}