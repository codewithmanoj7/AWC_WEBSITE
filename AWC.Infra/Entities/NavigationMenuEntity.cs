using AWC.Infra.Bases;

namespace AWC.Infra.Entities
{
    public class NavigationMenuEntity : BaseEntity
    {
        public Guid? ParentId { get; set; } = null;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public byte Level { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public bool IsExternal { get; set; } = false;
        public string Icon { get; set; } = string.Empty;
        public string CssClass { get; set; } = string.Empty;

        // Additional properties for UI display
        public string ParentName { get; set; } = string.Empty;
        public int ChildCount { get; set; } = 0;
        public string HierarchyPath { get; set; } = string.Empty;
        public string SortPath { get; set; } = string.Empty;
    }

    public class PageContentEntity : BaseEntity
    {
        public Guid NavigationMenuId { get; set; }
        public string Header { get; set; } = string.Empty;
        public string SubHeader { get; set; } = string.Empty;
        public string MetaDescription { get; set; } = string.Empty;
        public string MetaKeywords { get; set; } = string.Empty;
        public string HeroBanner { get; set; } = string.Empty;
        public string Paragraph { get; set; } = string.Empty;
        public string SecondaryContent { get; set; } = string.Empty;
        public string Pdf { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Gallery { get; set; } = string.Empty; // JSON array of image paths
        public string VideoUrl { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty; // JSON format
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool ShowInBreadcrumb { get; set; } = true;

        // Additional properties for UI display
        public string NavigationMenuName { get; set; } = string.Empty;
        public string NavigationMenuUrl { get; set; } = string.Empty;
        public byte NavigationMenuLevel { get; set; } = 1;
        public Guid? NavigationParentId { get; set; }
        public string ParentMenuName { get; set; } = string.Empty;
    }
    public class NavigationSettingEntity : BaseEntity
    {
        public string SettingKey { get; set; } = string.Empty;
        public string SettingValue { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
