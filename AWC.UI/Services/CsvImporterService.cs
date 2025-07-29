using AWC.Infra.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

namespace AWC.UI.Services
{
    public class CsvImporterService : ICsvImporterService
    {
        public async Task<IEnumerable<T>> ImportFromCSV<T>(
            IBrowserFile file,
            Func<string[], T> rowParser)
        {
            if (file == null || rowParser == null)
            {
                throw new ArgumentException("Invalid arguments provided.");
            }

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);

            var dataList = new List<T>();
            string? line;

            // Skip header
            await reader.ReadLineAsync();

            while ((line = await reader.ReadLineAsync()) != null)
            {
                var values = line.Split(',');
                dataList.Add(rowParser(values));
            }

            return dataList;
        }
    }

}
