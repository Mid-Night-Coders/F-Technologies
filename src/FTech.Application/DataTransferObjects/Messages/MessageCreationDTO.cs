namespace FTech.Application.DataTransferObjects.Messages
{
    public class MessageCreationDTO
    {
        public long SenderId { get; set; }
        public long ReciverId { get; set; }
        public Guid? ParentId { get; set; }
        public string Text { get; set; }
    }
}
