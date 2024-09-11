using System.Data;
using System.Data.SqlClient;

namespace SqlDataLayer
{
    public class SqlDataLayer
    {
        private readonly string connectionString;

        private const string SQL_EXCEPTION = "Data Layer Exception!";

        public SqlDataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> RunScalarSP(string storedProcedureName, List<SqlParameter> lstSqlParams)
        {
            SqlParameter[] sqlParams = lstSqlParams.ToArray<SqlParameter>();
            int intResult = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddRange(sqlParams);

                        await conn.OpenAsync();

                        CancellationTokenSource cts = new CancellationTokenSource();
                        cts.CancelAfter(1000);
                        object objResult = await cmd.ExecuteScalarAsync(cts.Token);

                        await conn.CloseAsync();

                        intResult = Convert.ToInt32(objResult);
                    }
                }
            }
            catch (SqlException ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }

            return intResult;
        }

        public async Task<DataTable> SelectDataTable(string storedProcedureName, List<SqlParameter> lstSqlParams)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = lstSqlParams.ToArray<SqlParameter>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddRange(sqlParams);

                            await conn.OpenAsync();
                            da.Fill(dt);
                            await conn.CloseAsync();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }

            return dt;
        }

        public async Task<DataTableCollection> SelectDataTables(string storedProcedureName, List<SqlParameter> lstSqlParams)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParams = lstSqlParams.ToArray<SqlParameter>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddRange(sqlParams);

                            await conn.OpenAsync();
                            da.Fill(ds);
                            await conn.CloseAsync();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }

            return ds.Tables;
        }

        public async Task<DataTable> SelectDataTable(string cmdText)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;

                            await conn.OpenAsync();
                            da.Fill(dt);
                            await conn.CloseAsync();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }

            return dt;
        }

        public async Task<DataTableCollection> SelectDataTableCollection(string storedProcedureName, List<SqlParameter> lstSqlParams)
        {
            DataTableCollection dtc;
            SqlParameter[] sqlParams = lstSqlParams.ToArray<SqlParameter>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddRange(sqlParams);

                            DataSet ds = new DataSet();
                            await conn.OpenAsync();
                            da.Fill(ds);
                            await conn.CloseAsync();

                            dtc = ds.Tables;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw new Exception(SQL_EXCEPTION);
            }

            return dtc;
        }

        public async Task<DataRowCollection> SelectTableRows(string cmdText)
        {
            return SelectDataTable(cmdText).Result.Rows;
        }

        public static string IntArrayToCommaString(int?[] intArray)
        {
            int?[] arrIntArray = DictionaryNulling(intArray);
            return arrIntArray != null ? string.Join(",", arrIntArray) : null;
        }

        public static int?[] ExtractIDsArray(DataTable dataTable)
        {
            int arrayLength = dataTable.Rows.Count;
            int?[] array = new int?[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = Convert.ToInt32(dataTable.Rows[i]["ID"]);
            }

            return array;
        }

        private static int?[] DictionaryNulling(int?[] array)
        {
            if ((array == null) || (array.Length == 0)) return null;
            if ((array.Length == 1) && (array[0] == 0)) return null;

            return array;
        }

        private static decimal? DecimalNulling(decimal? dVal)
        {
            if ((dVal == null) || (dVal == 0.0m))
            {
                return null;
            }
            else
            {
                return dVal;
            }

        }
    }
}
