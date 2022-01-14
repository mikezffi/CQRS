using System;

namespace Core.CQRS
{
    public class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }
        public Guid AgreggatedId { get; set; }
        public string MessageType { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}