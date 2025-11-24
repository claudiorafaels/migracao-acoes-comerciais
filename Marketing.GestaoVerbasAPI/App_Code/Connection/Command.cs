using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

public class Command
{
    private DbParameter[] dbParams;
    private Int32 pos;
    public String CommandText;
    public ConnectionString ConnectionString;
    public CommandType CommandType;

    public Command()
    {
        dbParams = new DbParameter[49];
        pos = 0;
        ConnectionString = new ConnectionString();
    }
    public DbCommandGeneric GetCommand()
    {
        DbCommandGeneric dbCmd = new DbCommandGeneric();

        dbCmd.DbCommand = DAO.getCommand(ConnectionString);
        dbCmd.DbCommand.CommandText = CommandText;

        for (var i = 0; i < pos; i++)
        {
            dbCmd.DbCommand.Parameters.Add(dbParams[i]);
        }

        if (CommandType > 0)
        {
            dbCmd.DbCommand.CommandType = CommandType;
        }

        return dbCmd;
    }
    public DbCommandGeneric GetCommandUseTransaction(DbCommand dbComm)
    {
        DbCommandGeneric dbCmd = new DbCommandGeneric();

        dbCmd.DbCommand = dbComm;
        dbCmd.DbCommand.CommandText = CommandText;

        for (var i = 0; i < pos - 1; i++)
        {
            dbCmd.DbCommand.Parameters.Add(dbParams[i]);
        }
        if (CommandType > 0)
        {
            dbCmd.DbCommand.CommandType = CommandType;
        }

        return dbCmd;
    }
    public DataTable GetData()
    {
        return DAO.getData(GetCommand());
    }
    public Object ExecuteScalar()
    {
        return DAO.ExecuteScalar(GetCommand());
    }
    public Object ExecuteScalarTran(DbCommand dbComm)
    {
        return DAO.ExecuteScalarTran(GetCommandUseTransaction(dbComm));
    }
    public void AddParam(String paramName, Object paramValue)
    {
        DbProviderFactory dbFactory = DbProviderFactories.GetFactory(ConnectionString.ProviderName);
        DbParameter dbParam = dbFactory.CreateParameter();

        dbParam.ParameterName = paramName;
        //'If (typeParam = 0) Then
        dbParam.Direction = ParameterDirection.Input;
        //'Else
        //'dbParam.Direction = ParameterDirection.Output
        //'End If
        if (paramValue != null)
        {
            if (paramValue.GetType() == typeof(Int32) || paramValue.GetType() == typeof(System.Nullable<Int32>))
            {
                dbParam.DbType = DbType.Int32;
                dbParam.Value = paramValue;
            }
            else if (paramValue.GetType() == typeof(String))
            {
                dbParam.DbType = DbType.String;
                dbParam.Value = paramValue;
            }
            else if (paramValue.GetType() == typeof(Boolean) || paramValue.GetType() == typeof(System.Nullable<Boolean>))
            {
                dbParam.DbType = DbType.Boolean;
                dbParam.Value = paramValue;
            }
            else if (paramValue.GetType() == typeof(DateTime) || paramValue.GetType() == typeof(System.Nullable<DateTime>))
            {
                dbParam.DbType = DbType.DateTime;
                dbParam.Value = paramValue;
            }
            else if (paramValue.GetType() == typeof(Decimal) || paramValue.GetType() == typeof(System.Nullable<Decimal>))
            {
                dbParam.DbType = DbType.Decimal;
                dbParam.Value = paramValue;
            }
            else if (paramValue.GetType() == typeof(Byte[]))
            {
                dbParam.DbType = DbType.Binary;
                dbParam.Value = paramValue;
            }
            else
            {
                dbParam.DbType = DbType.String;
                dbParam.Value = DBNull.Value;
            }
        }
        else
        {
            dbParam.DbType = DbType.String;
            dbParam.Value = DBNull.Value;
        }
        dbParams[pos] = dbParam;

        pos += 1;
    }
}
