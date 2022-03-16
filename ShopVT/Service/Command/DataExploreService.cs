using Common;
using Common.CustomConvert;
using Data.Command;
using Model.Command;
using Service.Command.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Command
{

    public class DataExploreService : IDataExploreService
    {
        private IDataExploreRepository _dataExplore;
        private ILogger _logger;

        public DataExploreService(IDataExploreRepository dataExplore, ILogger logger)
        {
            _dataExplore = dataExplore;
            _logger = logger;
        }
        /// <summary>
        /// chỉ lọc các thuôc theo các thuộc tính đơn các kiểu list,object sẽ bị loại bỏ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="DataIsActive"></param>
        /// <param name="filterColumn"></param>
        /// <param name="filterValue"></param>
        /// <param name="OrderBy"></param>
        /// <param name="OrderDesc"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<T>> GetData<T,O>(string table, int PageSize, int PageIndex, bool DataIsActive, string filterColumn, FilterType filterType, string filterValue, string OrderBy, bool OrderDesc, int userId)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    DataExploreGetDataRequestModel dataExplore = new DataExploreGetDataRequestModel();
                    StringBuilder filter = new StringBuilder();
                    if (PageIndex < 1)
                    {
                        PageIndex = 1;
                    }
                    if (PageIndex > 200)
                    {
                        PageIndex = 200;
                    }
                    if (PageSize < 10)
                    {
                        PageSize = 10;
                    }

                    if (filterColumn != null && !(string.IsNullOrEmpty(filterColumn)))
                    {
                        var filters = filterColumn.Split(",");
                        if (filters.Length > 1)
                        {
                            Type temp = typeof(O);
                            foreach (var column in filters)
                            {
                                var pro = temp.GetProperty(column);
                                if(pro != null)
                                {
                                    if (filterType == FilterType.NotEmpty)
                                    {
                                        filter.AppendLine($"OR IIF([{column}] <> '',0,1) = 1 ");
                                    }
                                    else if (filterType == FilterType.Empty)
                                    {
                                        filter.AppendLine($"OR IIF([{column}] = '',0,1) = 1 ");
                                    }
                                    else if (filterType == FilterType.Contains)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.StartsWith)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) LIKE '{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.EndsWith)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}'  ");
                                    }
                                    else if (filterType == FilterType.Equals)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) = '{filterValue.ToLower()}'  ");
                                    }
                                }   
                            }
                            if(!(string.IsNullOrEmpty(filter.ToString())))
                            {
                                filter = filter.Remove(0, 2);
                            }    
                        }
                        else
                        {
                            Type temp = typeof(O);
                            foreach (PropertyInfo pro in temp.GetProperties())
                            {

                                if (filterColumn.Equals("*"))
                                {
                                    if (filterType == FilterType.Contains)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}%'\t"); }
                                    else if (filterType == FilterType.StartsWith)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '{filterValue.ToLower()}%'\t"); }
                                    else if (filterType == FilterType.EndsWith)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}'\t"); }
                                    else if (filterType == FilterType.Equals)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) = '{filterValue.ToLower()}'\t"); }
                                }
                                else if (filterColumn.ToLower().Equals(pro.Name.ToLower()))
                                {
                                    if (filterType == FilterType.NotEmpty)
                                    {
                                        filter.AppendLine($"IIF([{filterColumn}] <> '',0,1) = 1;");
                                    }
                                    else if (filterType == FilterType.Empty)
                                    {
                                        filter.AppendLine($"IIF([{filterColumn}] = '',0,1) = 1;");
                                    }
                                    else if (filterType == FilterType.Contains)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.StartsWith)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.EndsWith)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}'  ");
                                    }
                                    else if (filterType == FilterType.Equals)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) = '{filterValue.ToLower()}'  ");
                                    }
                                }
                                else
                                    continue;
                            }
                        }
                        if (filterColumn.Equals("*"))
                        {
                            if (!string.IsNullOrEmpty(filter.ToString()))
                                filter = filter.Remove(0, 2);
                        }

                    }
                    if (!string.IsNullOrEmpty(OrderBy))
                    {
                        if (typeof(T).GetProperty(OrderBy) != null)
                        {
                            dataExplore.OrderBy = OrderBy;
                            dataExplore.OrderDesc = OrderDesc;
                        }
                        else
                        { dataExplore.OrderBy = "ID"; dataExplore.OrderDesc = OrderDesc; }
                    }
                    dataExplore.TableName = table;
                    dataExplore.UserId = userId;
                    dataExplore.DataIsActive = DataIsActive;
                    dataExplore.PageSize = PageSize;
                    dataExplore.PageIndex = PageIndex;
                    dataExplore.Filter = (!string.IsNullOrEmpty(filter.ToString()) ? filter.ToString() : " 1 = 1");
                    var data = await _dataExplore.GetData(dataExplore);
                    var result = CollectionHelper.ConvertTo<T>(data);
                    return result;
                });
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { table = table, user = userId });
                return null;
            }
        }

        public async Task<IList<T>> GetDataByGroup<T, O>(string table, int idGroup, int PageSize, int PageIndex, string filterColumn, FilterType filterType, string filterValue, string OrderBy, bool OrderDesc, int userId)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    DataExploreGetDataByGroupRequestModel dataExplore = new DataExploreGetDataByGroupRequestModel();
                    StringBuilder filter = new StringBuilder();
                    if (PageIndex < 1)
                    {
                        PageIndex = 1;
                    }
                    if (PageIndex > 200)
                    {
                        PageIndex = 200;
                    }
                    if (PageSize < 10)
                    {
                        PageSize = 10;
                    }
                    if (idGroup <= 0)
                    {
                        idGroup = 1;
                    }
                    if (filterColumn != null && !(string.IsNullOrEmpty(filterColumn)))
                    {
                        var filters = filterColumn.Split(",");
                        if (filters.Length > 1)
                        {
                            Type temp = typeof(O);
                            foreach (var column in filters)
                            {
                                var pro = temp.GetProperty(column);
                                if (pro != null)
                                {
                                    if (filterType == FilterType.NotEmpty)
                                    {
                                        filter.AppendLine($"OR IIF([{column}] <> '',0,1) = 1 ");
                                    }
                                    else if (filterType == FilterType.Empty)
                                    {
                                        filter.AppendLine($"OR IIF([{column}] = '',0,1) = 1 ");
                                    }
                                    else if (filterType == FilterType.Contains)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.StartsWith)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) LIKE '{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.EndsWith)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}'  ");
                                    }
                                    else if (filterType == FilterType.Equals)
                                    {
                                        filter.AppendLine($"OR LOWER(CAST([{column}] AS NVARCHAR)) = '{filterValue.ToLower()}'  ");
                                    }
                                }
                            }
                            if (!(string.IsNullOrEmpty(filter.ToString())))
                            {
                                filter = filter.Remove(0, 2);
                            }
                        }
                        else
                        {
                            Type temp = typeof(O);
                            foreach (PropertyInfo pro in temp.GetProperties())
                            {

                                if (filterColumn.Equals("*"))
                                {
                                    if (filterType == FilterType.Contains)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}%'\t"); }
                                    else if (filterType == FilterType.StartsWith)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '{filterValue.ToLower()}%'\t"); }
                                    else if (filterType == FilterType.EndsWith)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}'\t"); }
                                    else if (filterType == FilterType.Equals)
                                    { filter.AppendLine($"OR LOWER(CAST([{filterColumn}] AS NVARCHAR)) = '{filterValue.ToLower()}'\t"); }
                                }
                                else if (filterColumn.ToLower().Equals(pro.Name.ToLower()))
                                {
                                    if (filterType == FilterType.NotEmpty)
                                    {
                                        filter.AppendLine($"IIF([{filterColumn}] <> '',0,1) = 1;");
                                    }
                                    else if (filterType == FilterType.Empty)
                                    {
                                        filter.AppendLine($"IIF([{filterColumn}] = '',0,1) = 1;");
                                    }
                                    else if (filterType == FilterType.Contains)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.StartsWith)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '{filterValue.ToLower()}%'  ");
                                    }
                                    else if (filterType == FilterType.EndsWith)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) LIKE '%{filterValue.ToLower()}'  ");
                                    }
                                    else if (filterType == FilterType.Equals)
                                    {
                                        filter.AppendLine($" LOWER(CAST([{filterColumn}] AS NVARCHAR)) = '{filterValue.ToLower()}'  ");
                                    }
                                }
                                else
                                    continue;
                            }
                        }
                        if (filterColumn.Equals("*"))
                        {
                            if (!string.IsNullOrEmpty(filter.ToString()))
                                filter = filter.Remove(0, 2);
                        }

                    }
                    if (!string.IsNullOrEmpty(OrderBy))
                    {
                        if (typeof(T).GetProperty(OrderBy) != null)
                        {
                            dataExplore.OrderBy = "ORDER BY " + OrderBy;
                            dataExplore.OrderDesc = OrderDesc ? "DESC" : "ASC";
                        }
                        else
                            dataExplore.OrderBy = "ORDER BY ID";
                    }
                    dataExplore.TableName = table;
                    dataExplore.UserId = userId;
                    dataExplore.PageIndex = PageIndex;
                    dataExplore.PageSize = PageSize;
                    dataExplore.IdGroup = idGroup;
                    dataExplore.Filter = "WHERE " + (!string.IsNullOrEmpty(filter.ToString()) ? filter.ToString() : " 1 = 1");
                    var data = await _dataExplore.GetDataByGroup(dataExplore);
                    var result = CollectionHelper.ConvertTo<T>(data);
                    return result;

                });
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { table = table, user = userId });
                return null;
            }
        }

        public async Task<T> GetDataByIdMultipleTable<T>(string table, int RowId, string keyParent, string foreignKey, string OrderBy, bool OrderDesc, int userId)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    DataExploreGetMultipleDataByIdRequestModel dataExplore = new DataExploreGetMultipleDataByIdRequestModel();
                    StringBuilder subTable = new StringBuilder();
                    var temp = typeof(T);
                    var _OrderDesc = "";

                    foreach (var pro in temp.GetProperties())
                    {

                        if (!pro.PropertyType.Namespace.Contains("System"))
                        {

                            if (!string.IsNullOrEmpty(OrderBy))
                            {
                                Type objChildType = pro.PropertyType;
                                if (objChildType.GetProperty(OrderBy) != null)
                                {
                                    OrderBy = "ORDER BY " + OrderBy;
                                    _OrderDesc = OrderDesc ? "DESC" : "ASC";
                                }
                                else
                                    OrderBy = "ORDER BY ID";
                            }
                            string subTableName = pro.Name.EndsWith("Model") == true ? pro.Name.Remove(pro.Name.Length - 5, 5) : pro.Name;
                            subTable.Append($", (SELECT TOP 1 * FROM {pro.Name} WHERE {subTableName}.{foreignKey} = {table}.{keyParent}  FOR JSON AUTO ) AS {subTableName}_Json");
                        }
                        else if (pro.PropertyType.IsGenericType &&
                          pro.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            Type objChildType = Type.GetType(pro.PropertyType.FullName).GetGenericArguments()[0];
                            string subTableName = objChildType.Name.EndsWith("Model") == true ? objChildType.Name.Remove(objChildType.Name.Length - 5, 5) : pro.Name;
                            if (!string.IsNullOrEmpty(OrderBy))
                            {
                                if (objChildType.GetProperty(OrderBy) != null)
                                {
                                    OrderBy = "ORDER BY " + OrderBy;
                                    _OrderDesc = OrderDesc ? "DESC" : "ASC";
                                }
                                else
                                    OrderBy = "ORDER BY ID";
                            }
                            subTable.Append($", (SELECT * FROM {subTableName} WHERE {subTableName}.{foreignKey} = {table}.{keyParent}  {OrderBy}  FOR JSON AUTO ) AS {subTableName}_Json");
                        }
                    }
                    dataExplore.TableName = table;
                    dataExplore.UserId = userId;
                    dataExplore.SubTable = subTable.ToString();
                    dataExplore.RowId = RowId;
                    var data = await _dataExplore.GetDataByIdMultipleTable(dataExplore);
                    var result = CollectionHelper.ConvertTo<T>(data);
                    return result;
                });
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { table = table, user = userId });
                return default(T);
            }
        }

        public async Task<T> GetDataByIdOneTable<T>(string table, int rowId, int userId)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    DataExploreGetDataByIdRequestModel dataExplore = new DataExploreGetDataByIdRequestModel();
                    var temp = typeof(T);
                    dataExplore.TableName = table;
                    dataExplore.UserId = userId;
                    dataExplore.RowId = rowId;

                    var data = await _dataExplore.GetDataByIdOneTable(dataExplore);
                    var result = CollectionHelper.ConvertTo<T>(data);
                    return result;
                });
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { table = table, user = userId });
                return default(T);
            }
        }
        public async Task<IList<T>> GetGroup<T>(string table, string ColumnCaption, string OrderBy, bool OrderDesc, int userId)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    DataExploreGetGroupRequestModel dataExplore = new DataExploreGetGroupRequestModel();
                    var temp = typeof(T);
                    if (!string.IsNullOrEmpty(OrderBy))
                    {
                        if (typeof(T).GetProperty(OrderBy) != null)
                        {
                            dataExplore.OrderBy = OrderBy;
                            dataExplore.OrderDesc = OrderDesc;
                        }
                        else
                            dataExplore.OrderBy = "ID";
                    }
                    dataExplore.TableName = table;
                    dataExplore.UserId = userId;
                    dataExplore.ColumnCaption = ColumnCaption;
                    var data = await _dataExplore.GetGroup(dataExplore);
                    var result = CollectionHelper.ConvertTo<T>(data);
                    return result;
                });
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { table = table, user = userId });
                return null;
            }
        }
        public bool IsNumericType(object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
