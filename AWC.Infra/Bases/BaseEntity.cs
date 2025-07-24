namespace AWC.Infra.Bases
{
    public abstract class BaseEntity
    {
#nullable disable
        public Guid Id { get; set; }
        public string ICnumber { get; set; } = string.Empty;
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public bool IsSelected { get; set; } // For checkbox selection

        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
    }

}
