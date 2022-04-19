using Messaging;

namespace Device
{
    public class Device
    {
        private readonly Guid id;
        private readonly Queue<IMessage> messages;

        public Device()
        {
            id = Guid.NewGuid();

            messages = new Queue<IMessage>();
        }

        public Device(BootstrapSettings bootstrapSettings)
        {
            id = bootstrapSettings.NewId;

            messages = bootstrapSettings.NewMessages;
        }

        public Guid Id { get => id; }
        public Queue<IMessage> Messages { get => messages; }
    }
}