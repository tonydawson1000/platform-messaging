namespace Messaging
{
    public interface IMessage
    {
        public Guid MessageId { get; }

        public DateTime CreatedDateTime { get; }
    }
}