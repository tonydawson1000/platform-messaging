namespace Messaging
{
    public class DeviceMessage : IMessage
    {
        private readonly Guid deviceId;

        private readonly Guid messageId;
        private readonly DateTime createdDateTime;

        public DeviceMessage(Guid id)
        {
            deviceId = id;

            messageId = Guid.NewGuid();
            createdDateTime = DateTime.UtcNow;
        }

        public Guid DeviceId { get => deviceId; }

        public Guid MessageId { get => messageId; }
        public DateTime CreatedDateTime { get => createdDateTime; }
    }
}