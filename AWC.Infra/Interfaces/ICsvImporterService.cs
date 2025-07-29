using Microsoft.AspNetCore.Components.Forms;

namespace AWC.Infra.Interfaces
{
    public interface ICsvImporterService
    {
        Task<IEnumerable<T>> ImportFromCSV<T>(
        IBrowserFile file,
        Func<string[], T> rowParser);
    }
}
