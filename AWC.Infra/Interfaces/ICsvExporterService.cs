namespace AWC.Infra.Interfaces
{
    public interface ICsvExporterService
    {
        Task ExportListToCSV<T>(
            IEnumerable<T> dataList,
            string fileNamePrefix,
            string header,
            Func<T, string> rowFormatter);
    }
}
