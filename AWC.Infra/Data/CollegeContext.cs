using AWC.Infra.Results;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AWC.Infra.Data
{
    public class CollegeContext(string connectionString)
    {
#nullable disable
            // Executes a stored procedure that returns a single result (e.g., one record)
            public async Task<T> ExecuteQuerySingleOrDefaultAsync<T>(string storedProcedure, object parameters = null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    return await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }

            // Executes a stored procedure that returns multiple results (e.g., a list of records)
            public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string storedProcedure, object parameters = null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    //var result = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                    //return result;
                    return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }

            // Executes a stored procedure that performs an action (e.g., INSERT, UPDATE, DELETE) and returns a status code
            public async Task<int> ExecuteNonQueryAsync(string storedProcedure, object parameters = null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    try
                    {
                        // Define a parameter to capture the return value from the stored procedure
                        var returnValue = new DynamicParameters(parameters);
                        returnValue.Add("ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                        // Execute the stored procedure and capture the return value
                        await connection.ExecuteAsync(
                            storedProcedure,
                            returnValue,
                            commandType: CommandType.StoredProcedure
                        );

                        // Get the return value (status code)
                        int result = returnValue.Get<int>("ReturnValue");

                        // Return the status code from the stored procedure
                        return result;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception and return a default failure code (e.g., -1 or 0)
                        Console.WriteLine($"Error executing stored procedure {storedProcedure}: {ex.Message}");
                        return -1; // Or you can return 0 for a more generic failure code
                    }
                }
            }

            // Executes a stored procedure that returns multiple result sets
            public async Task<PaginatedQueryResult<T>> ExecutePaginatedQueryAsync<T>(string storedProcedure, object parameters = null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    try
                    {
                        var result = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                        // Read the paginated user data
                        var items = await result.ReadAsync<T>();

                        // Read the total count (optional, depending on your stored procedure)
                        var totalCount = await result.ReadSingleAsync<int>();

                        // Return the paginated result
                        return new PaginatedQueryResult<T>
                        {
                            Items = items.ToList(),
                            TotalCount = totalCount,
                            PageNumber = 1,
                            PageSize = 10
                        };
                    }
                    catch (InvalidOperationException ex)
                    {
                        // Log the exception and return null
                        Console.WriteLine($"Error executing stored procedure {storedProcedure}: {ex.Message}");
                        return null; // Return null if there's an error
                    }
                }
            }

            // Add this method to your CampusContext class
            public async Task<SqlMapper.GridReader> ExecuteQueryMultipleAsync(string storedProcedure, object parameters = null)
            {
                var connection = new SqlConnection(connectionString);
                try
                {
                    await connection.OpenAsync();
                    return await connection.QueryMultipleAsync(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                }
                catch (Exception ex)
                {
                    // Ensure connection is disposed if an error occurs
                    connection.Dispose();
                    throw new Exception($"Error executing multi-result stored procedure {storedProcedure}: {ex.Message}", ex);
                }
            }

            // Optional: Add a helper method to properly dispose the GridReader and connection
            public async Task ExecuteQueryMultipleAsync(string storedProcedure,
                Action<SqlMapper.GridReader> processResults,
                object parameters = null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var multi = await connection.QueryMultipleAsync(
                               storedProcedure,
                               parameters,
                               commandType: CommandType.StoredProcedure))
                    {
                        processResults(multi);
                    }
                }
            }
        }
}
