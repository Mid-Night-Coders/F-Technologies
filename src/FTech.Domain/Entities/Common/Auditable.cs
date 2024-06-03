using System.Security.Cryptography;

namespace FTech.Domain.Entities.Common
{
    public class Auditable<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
