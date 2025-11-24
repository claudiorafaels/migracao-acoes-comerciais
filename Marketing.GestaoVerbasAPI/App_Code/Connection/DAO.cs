using System;
using System.Collections.Generic;
using System.Data.Common;

public class DAO
{
    public static DbConnection getConnection(ConnectionString connString)
    {
        DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connString.ProviderName);
        DbConnection dbConn = dbFactory.CreateConnection();
        dbConn.ConnectionString = connString.ConnString;
        dbConn.Open();

        return dbConn;
    }

    public static DbCommand getCommand(ConnectionString connString)
    {
        DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connString.ProviderName);
        DbCommand dbCmd = dbFactory.CreateCommand();
        dbCmd.Connection = getConnection(connString);
        dbCmd.CommandType = System.Data.CommandType.Text;
        dbCmd.CommandTimeout = 0;
        // 1800;
        return dbCmd;
    }
    public static DbCommand getCommandTrans(ConnectionString connString)
    {
        DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connString.ProviderName);
        DbCommand dbCmd = dbFactory.CreateCommand();

        dbCmd.Connection = getConnection(connString);

        dbCmd.CommandType = System.Data.CommandType.Text;
        dbCmd.CommandTimeout = 0;
        // 1800;
        return dbCmd;
    }
    public static System.Data.DataTable getData(DbCommandGeneric dbCmd)
    {
        var dt = new System.Data.DataTable();

        String sqlExec = dbCmd.DbCommand.CommandText.TrimStart().ToString();

        dt.Load(dbCmd.DbCommand.ExecuteReader());

        dbCmd.DbCommand.Connection.Close();

        return dt;
    }

    public static int Execute(DbCommandGeneric dbCmd)
    {
        Int32 rowsAffected;
        try
        {
            String commandTextTemp = dbCmd.DbCommand.CommandText;
            var parametersTemp = new List<DbParameter>();
            foreach (DbParameter parametro in dbCmd.DbCommand.Parameters)
            {
                parametersTemp.Add(parametro);
            }

            dbCmd.DbCommand.CommandText = commandTextTemp;
            dbCmd.DbCommand.Parameters.Clear();
            foreach (DbParameter parametro in parametersTemp)
            {
                dbCmd.DbCommand.Parameters.Add(parametro);
            }
            rowsAffected = dbCmd.DbCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            rowsAffected = 0;
        }
        finally
        {
            if (Connection.DbCommand == null)
            {
                dbCmd.DbCommand.Connection.Close();
            }
        }

        return rowsAffected;
    }

    public static Object ExecuteScalar(DbCommandGeneric dbCmd)
    {
        Object obj;
        try
        {
            obj = dbCmd.DbCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            obj = ex.Message;
        }
        if (Connection.DbCommand == null)
        {
            dbCmd.DbCommand.Connection.Close();
        }

        return obj;

    }
    public static Object ExecuteScalarTran(DbCommandGeneric dbCmd)
    {
        Object obj;
        try
        {
            obj = dbCmd.DbCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;

    }
}
