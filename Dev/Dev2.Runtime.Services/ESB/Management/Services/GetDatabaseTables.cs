#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Infrastructure.SharedModels;
using Dev2.Communication;
using Dev2.DynamicServices;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Workspaces;
using MySql.Data.MySqlClient;
using Warewolf.Resource.Errors;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class GetDatabaseTables : DefaultEsbManagementEndpoint
    {
        #region Implementation of DefaultEsbManagementEndpoint
        
        public override StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            var serializer = new Dev2JsonSerializer();

            if (values == null)
            {
                throw new InvalidDataContractException(ErrorResource.NoParameter);
            }
            string database = null;
            values.TryGetValue("Database", out StringBuilder tmp);
            if (tmp != null)
            {
                database = tmp.ToString();
            }

            if (string.IsNullOrEmpty(database))
            {
                var res = new DbTableList("No database set.");
                Dev2Logger.Debug("No database set.", GlobalConstants.WarewolfDebug);
                return serializer.SerializeToBuilder(res);
            }

            DbSource dbSource;
            DbSource runtimeDbSource = null;
            try
            {
                dbSource = serializer.Deserialize<DbSource>(database);

                if (dbSource.ResourceID != Guid.Empty)
                {
                    runtimeDbSource = ResourceCatalog.Instance.GetResource<DbSource>(theWorkspace.ID, dbSource.ResourceID);
                }
            }
            catch (Exception e)
            {
                Dev2Logger.Error(e, GlobalConstants.WarewolfError);
                var res = new DbTableList("Invalid JSON data for Database parameter. Exception: {0}", e.Message);
                return serializer.SerializeToBuilder(res);
            }
            if (runtimeDbSource == null)
            {
                var res = new DbTableList("Invalid Database source");
                Dev2Logger.Debug("Invalid Database source", GlobalConstants.WarewolfDebug);
                return serializer.SerializeToBuilder(res);
            }
            if (string.IsNullOrEmpty(runtimeDbSource.DatabaseName) || string.IsNullOrEmpty(runtimeDbSource.Server))
            {
                var res = new DbTableList("Invalid database sent {0}.", database);
                Dev2Logger.Debug($"Invalid database sent {database}.", GlobalConstants.WarewolfDebug);
                return serializer.SerializeToBuilder(res);
            }

            try
            {
                return serializer.SerializeToBuilder(TryExecute(dbSource));
            }
            catch (Exception ex)
            {
                var tables = new DbTableList(ex);
                return serializer.SerializeToBuilder(tables);
            }
        }

        static DbTableList TryExecute(DbSource dbSource)
        {
            Dev2Logger.Info("Get Database Tables. " + dbSource.DatabaseName, GlobalConstants.WarewolfInfo);
            var tables = new DbTableList();
            Common.Utilities.PerformActionInsideImpersonatedContext(Common.Utilities.OrginalExecutingUser, () =>
            {
                DataTable columnInfo = null;
                switch (dbSource.ServerType)
                {
                    case enSourceType.SqlDatabase:
                        {
                            using (var connection = new SqlConnection(dbSource.ConnectionString))
                            {
                                connection.Open();
                                columnInfo = connection.GetSchema("Tables");
                            }
                            break;
                        }
                    default:
                        {
                            using (var connection = new MySqlConnection(dbSource.ConnectionString))
                            {
                                connection.Open();
                                columnInfo = connection.GetSchema("Tables");
                            }
                            break;
                        }
                }

                if (columnInfo != null)
                {
                    foreach (DataRow row in columnInfo.Rows)
                    {
                        var tableName = row["TABLE_NAME"] as string;
                        var schema = row["TABLE_SCHEMA"] as string;
                        tableName = '[' + tableName + ']';
                        var dbTable = tables.Items.Find(table => table.TableName == tableName && table.Schema == schema);
                        if (dbTable == null)
                        {
                            dbTable = new DbTable { Schema = schema, TableName = tableName, Columns = new List<IDbColumn>() };
                            tables.Items.Add(dbTable);
                        }
                    }
                }
                if (tables.Items.Count == 0)
                {
                    tables.HasErrors = true;
                    const string ErrorFormat = "The login provided in the database source uses {0} and most probably does not have permissions to perform the following query: "
                                          + "\r\n\r\n{1}SELECT * FROM INFORMATION_SCHEMA.TABLES;{2}";

                    if (dbSource.AuthenticationType == AuthenticationType.User)
                    {
                        tables.Errors = string.Format(ErrorFormat,
                            "SQL Authentication (User: '" + dbSource.UserID + "')",
                            "EXECUTE AS USER = '" + dbSource.UserID + "';\r\n",
                            "\r\nREVERT;");
                    }
                    else
                    {
                        tables.Errors = string.Format(ErrorFormat, "Windows Authentication", "", "");
                    }
                }
            });
            return tables;
        }

        #endregion

        public override DynamicService CreateServiceEntry() => EsbManagementServiceEntry.CreateESBManagementServiceEntry(HandlesType(), "<DataList><Database ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>");

        public override string HandlesType() => "GetDatabaseTablesService";
    }
}
