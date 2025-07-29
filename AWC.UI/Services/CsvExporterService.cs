using AWC.Infra.Interfaces;
using Microsoft.JSInterop;

namespace AWC.UI.Services
{
    public class CsvExporterService(IJSRuntime jsRuntime) : ICsvExporterService
    {
        public async Task ExportListToCSV<T>(
            IEnumerable<T> dataList,
            string fileNamePrefix,
            string header,
            Func<T, string> rowFormatter)
        {
            if (dataList == null || !dataList.Any() || string.IsNullOrEmpty(fileNamePrefix) || rowFormatter == null)
            {
                throw new ArgumentException("Invalid arguments provided.");
            }

            var csvContent = header + "\n" + string.Join("\n", dataList.Select(rowFormatter));
            var bytes = System.Text.Encoding.UTF8.GetBytes(csvContent);

            // Generate dynamic filename
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{fileNamePrefix}_{timestamp}.csv";

            await jsRuntime.InvokeVoidAsync(
                "downloadFile",
                fileName,
                "text/csv",
                bytes
            );
        }
    }

}
