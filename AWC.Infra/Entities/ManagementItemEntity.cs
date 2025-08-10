using AWC.Infra.Enums;

namespace AWC.Infra.Entities
{
    public class ManagementItemEntity
    {
#nullable disable
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }

        public UserPermissionsEnum RequiredPermission { get; set; }
        public string PermissionLevel { get; set; }
    }
}
