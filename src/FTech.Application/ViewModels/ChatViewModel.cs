namespace FTech.Application.ViewModels
{
    public class ChatViewModel
    {
        public Guid Id { get; set; }
        public string? Link { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? OwnerId { get; set; }
        public int MembersCount { get; set; }
    }
}
