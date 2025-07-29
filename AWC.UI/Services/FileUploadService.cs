using AWC.Infra.Enums;
using AWC.Infra.Interfaces;
using AWC.Infra.Results;
using Microsoft.AspNetCore.Components.Forms;

namespace AWC.UI.Services;

public class FileUploadService : IFileUploadService
{
    private static readonly string BaseUploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
    private static readonly long MaxFileSize = 1024 * 1000 * 2; // 2MB

    public async Task<FileUploadResult> UploadFileAsync(
        IBrowserFile file, 
        UploadPath uploadPath, 
        string[] allowedExtensions,
        string? fileName = null, 
        CancellationToken token = default)
    {
        // Validate file extension
        var fileExtension = Path.GetExtension(file.Name).ToLowerInvariant();
        
        if (!allowedExtensions.Contains(fileExtension))
        {
            return new FileUploadResult 
            { 
                Success = false, 
                Message = $"Invalid file type. Allowed types: {string.Join(", ", allowedExtensions)}" 
            };
        }

        if (file.Size > MaxFileSize)
        {
            return new FileUploadResult 
            { 
                Success = false, 
                Message = "File size exceeds the 2MB limit." 
            };
        }

        string uploadFolder = Path.Combine(BaseUploadDirectory, uploadPath.ToString());
        Directory.CreateDirectory(uploadFolder);

        string uploadingFileName = string.IsNullOrEmpty(fileName)
            ? $"{Guid.NewGuid()}{fileExtension}"
            : $"{Path.GetFileNameWithoutExtension(fileName)}{fileExtension}";

        string filePath = Path.Combine(uploadFolder, uploadingFileName);
        string relativePath = $"/uploads/{uploadPath}/{uploadingFileName}";

        try
        {
            await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await using var inputStream = file.OpenReadStream(MaxFileSize, token);
            await inputStream.CopyToAsync(fileStream, token);

            return new FileUploadResult 
            { 
                Success = true, 
                Message = "File uploaded successfully.", 
                FilePath = relativePath 
            };
        }
        catch (Exception ex)
        {
            return new FileUploadResult 
            { 
                Success = false, 
                Message = $"Error: {ex.Message}" 
            };
        }
    }

    public async Task<FileUploadResult[]> UploadFilesAsync(
        IBrowserFile[] files, 
        UploadPath uploadPath, 
        string[] allowedExtensions,
        CancellationToken token = default)
    {
        var uploadTasks = files.Select(file => 
            UploadFileAsync(file, uploadPath, allowedExtensions, null, token));
        
        return await Task.WhenAll(uploadTasks);
    }
}
