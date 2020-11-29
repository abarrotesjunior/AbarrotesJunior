using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de db_SQLDatabase
/// </summary>
public class db_SQLDatabase
{
    public db_SQLDatabase()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
	static string connectionString = ConfigurationManager.ConnectionStrings["SQL_Database"].ConnectionString;
	public static DataSet ExecuteReaderSP(string storedProcedure)
	{
		using (DataSet dataSet = new DataSet())
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(storedProcedure, connection)
					{ CommandType = CommandType.StoredProcedure }
					)
					{
						using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
						{
							dataAdapter.Fill(dataSet);
							return dataSet;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

	}
	public static string[] ExecuteSPWithParameters(string storedProcedure,
			string[] parameterNames, object[] parameterValues, string[] outputParameters)
	{
		List<string> result = new List<string>();
		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				for (int index = 0; index < parameterNames.Length; index++)
				{
					cmd.Parameters.AddWithValue(parameterNames[index],
						 parameterValues[index] == string.Empty ? DBNull.Value : parameterValues[index]
						);
				}

				for (int index = 0; index < outputParameters.Length; index++)
				{
					cmd.Parameters.Add(
						new SqlParameter()
						{
							ParameterName = outputParameters[index],
							Direction = ParameterDirection.Output,
							Size = -1,
							SqlDbType = SqlDbType.NVarChar
						}
						);
				}

				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					result.Add(ex.Message);
				}
				finally
				{
					conn.Close();
				}

				foreach (SqlParameter parameter in cmd.Parameters)
				{
					if (parameter.Direction == ParameterDirection.Output)
					{
						result.Add(Convert.ToString(parameter.Value));
					}
				}

				return result.ToArray();
			}
		}
	}
}
