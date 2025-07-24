using Dapper;
using System.Data;
using System.Reflection;

namespace AWC.Infra.Helpers
{
    public class DbUtils
    {
        public static string GetDynamicParametersAsString(DynamicParameters parameters)
        {
            var keyValuePairs = parameters.ParameterNames
                .Select(name => $"{name}: {parameters.Get<dynamic>(name)}")
                .ToList();

            return string.Join(", ", keyValuePairs);
        }

        public static DataTable ConvertListToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            // Get all the properties of T
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns in the DataTable
            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            if (items != null)
            {
                // Populate the DataTable with the items
                foreach (var item in items)
                {
                    var row = dataTable.NewRow();
                    foreach (var prop in properties)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }
    }

}
