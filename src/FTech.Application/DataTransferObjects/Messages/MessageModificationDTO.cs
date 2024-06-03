namespace FTech.Application.DataTransferObjects.Messages
{
    public class MessageModificationDTO
    {
        public long SenderId { get; set; }
        public long? ParentId { get; set; }
        public long ChatId { get; set; }
        public string Text { get; set; }
    }
}
