using AWC.Infra.Bases;

namespace AWC.Infra.Entities
{
    public class SessionEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
