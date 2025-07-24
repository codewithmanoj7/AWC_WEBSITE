using AWC.Infra.Enums;
using AWC.Infra.Interfaces;

namespace AWC.UI.Services;

public class PermissionStylingService : IPermissionStylingService
{
    public string? GetDisplayTextForPermission(UserPermissionsEnum? permission)
    {
        if (permission == null)
        {
            return null;
        }

        return permission switch
        {
            UserPermissionsEnum.WaitingApproval => "Waiting Approval",
            UserPermissionsEnum.DirectingStaff => "Directing Staff",
            _ => permission.ToString()
        };
    }

    public string? GetBootstrapClassesForPermission(UserPermissionsEnum? permission)
    {
        if (permission == null)
        {
            return null;
        }

        return permission switch
        {
            UserPermissionsEnum.Administrator => "bg-danger bg-opacity-75 text-white",
            UserPermissionsEnum.DirectingStaff => "bg-primary bg-opacity-50 text-white",
            UserPermissionsEnum.Student => "bg-info text-white",
            UserPermissionsEnum.ContentManager => "bg-primary bg-opacity-75 text-white",
            UserPermissionsEnum.WaitingApproval => "bg-secondary bg-opacity-50 text-white",
            _ => "bg-light text-dark"
        };
    }
}