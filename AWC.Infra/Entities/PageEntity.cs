using AWC.Infra.Bases;

namespace AWC.Infra.Entities
{
    public class PageEntity : BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Pdf { get; set; } = string.Empty;
    }
}
