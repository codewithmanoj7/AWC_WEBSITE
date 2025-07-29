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
            return "label label-default";
        }

        return permission switch
        {
            UserPermissionsEnum.Administrator => "label label-danger",
            UserPermissionsEnum.DirectingStaff => "label label-primary",
            UserPermissionsEnum.Student => "label label-info",
            UserPermissionsEnum.ContentManager => "label label-warning",
            UserPermissionsEnum.WaitingApproval => "label label-default",
            _ => "label label-default"
        };
    }
}