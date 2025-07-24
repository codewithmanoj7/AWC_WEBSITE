using AWC.Infra.Enums;

namespace AWC.Infra.Interfaces;

public interface IPermissionStylingService
{
    string GetDisplayTextForPermission(UserPermissionsEnum? permission);
    string GetBootstrapClassesForPermission(UserPermissionsEnum? permission);
}