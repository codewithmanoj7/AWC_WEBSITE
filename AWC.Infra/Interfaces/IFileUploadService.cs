using AWC.Infra.Enums;
using AWC.Infra.Results;
using Microsoft.AspNetCore.Components.Forms;

namespace AWC.Infra.Interfaces
{
    public interface IFileUploadService
    {
        Task<FileUploadResult> UploadFileAsync(IBrowserFile file, UploadPath uploadPath, string[] allowedExtensions, string? fileName = null, CancellationToken token = default);
        Task<FileUploadResult[]> UploadFilesAsync(IBrowserFile[] files, UploadPath uploadPath, string[] allowedExtensions, CancellationToken token = default);
    }
}
