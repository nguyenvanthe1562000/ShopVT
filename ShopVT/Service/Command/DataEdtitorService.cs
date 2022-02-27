using Common;
using Data.Command;
using Model.Command;
using Newtonsoft.Json;
using Service.Command.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Command
{
    public class DataEdtitorService : IDataEdtitorService
    {
        private IDataEditorRepository _dataEditor;
        private ILogger _logger;

        public DataEdtitorService(IDataEditorRepository dataEditor, ILogger logger)
        {
            _dataEditor = dataEditor;
            _logger = logger;
        }


        /// <summary>
        ///  thêm dữ liệu
        ///  những thuộc tính của dối tượng không là null sẽ bị bỏ qua
        /// </summary>
        /// <typeparam name="T">  đối tượng </typeparam>
        /// <param name="obj"> đối tượng </param>
        /// <param name="table">tên bảng</param>
        /// <param name="ConditionString">tên cột,nhiều cột sẽ cách nhau bằng dấu ',' vd: id,name. check giá trị đã tồn tại, giá trị sẽ lấy từ object được truyền vào</param>
        /// <returns>
        /// trả về số lượng dòng được thêm
        /// lỗi trả về 1 thông báo
        /// </returns>
        public async Task<ResponseMessageDto> Add<T>(T obj, string table, string ConditionString, int userId)
        {
            try
            {
                return await Task.Run(() =>
                 {
                     var column = ConditionString.Split(',');
                     var arrayCondition = new Dictionary<string, string>();
                     Type temp = typeof(T);
                     DataEditorAddRequestModel dataEditorAddRequestModel = new DataEditorAddRequestModel();
                     dataEditorAddRequestModel.TableName = table;
                     dataEditorAddRequestModel.UserId = userId;
                     foreach (PropertyInfo pro in temp.GetProperties())
                     {
                         if (!(pro.GetValue(obj, null) is null))
                         {
                             if (pro.Name.ToLower() == "id" || pro.Name.ToLower() == "isactive" || pro.Name.ToLower() == "modifiedby" || pro.Name.ToLower() == "modifiedat" || pro.Name.ToLower() == "createdat")
                             {
                                 continue;
                             }
                             else if (pro.Name.ToLower() == "createdby")
                             {
                                 dataEditorAddRequestModel.ColumnArray += ", " + pro.Name;
                                 dataEditorAddRequestModel.ColumnValue += ", " + userId;
                                 continue;
                             }
                             else
                                 dataEditorAddRequestModel.ColumnArray += ", " + pro.Name;
                             var castValue = pro.GetValue(obj, null).ToString();
                             if (int.TryParse(castValue, out int _int) || double.TryParse(castValue, out double _double) || long.TryParse(castValue, out long _long))
                             {
                                 dataEditorAddRequestModel.ColumnValue += ", " + castValue;
                             }
                             else
                                 dataEditorAddRequestModel.ColumnValue += ", '" + castValue + "'";
                             if (!string.IsNullOrEmpty(ConditionString))
                             {
                                 foreach (var item in column)
                                 {
                                     if (item == pro.Name)
                                     {
                                         arrayCondition.Add(pro.Name, castValue);
                                     }
                                 }

                             }
                         }
                     }

                     if (arrayCondition.Count > 0)
                     {
                         dataEditorAddRequestModel.Condition = 1;
                         var _condition = new StringBuilder();
                         foreach (var item in arrayCondition)
                         {
                             if (int.TryParse(item.Value, out int _int) || double.TryParse(item.Value, out double _double) || long.TryParse(item.Value, out long _long))
                             {
                                 string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "=" + item.Value + ")) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED' RETURN; END \t";
                                 _condition.Append(condition);
                             }
                             else if (DateTime.TryParse(item.Value, out DateTime _))
                             {
                                 string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "='" + item.Value + "')) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED ' RETURN; END \t";
                                 _condition.Append(condition);
                             }
                             else
                             {
                                 string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE LOWER(" + item.Key + ") = LOWER('" + item.Value + "'))) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED ' RETURN; END \t";
                                 _condition.Append(condition);
                             }
                         }
                         dataEditorAddRequestModel.ConditionString = _condition.ToString();
                     }
                     else
                     {
                         dataEditorAddRequestModel.Condition = 0;
                         dataEditorAddRequestModel.ConditionString = "SELECT 'MESSEAGE. NO MESSEAGE'";
                     }
                     dataEditorAddRequestModel.ColumnArray = dataEditorAddRequestModel.ColumnArray.Remove(0, 1);
                     dataEditorAddRequestModel.ColumnValue = dataEditorAddRequestModel.ColumnValue.Remove(0, 1);
                     return _dataEditor.Add(dataEditorAddRequestModel);
                 });
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { obj = obj, table = table, ConditionString = ConditionString, user = userId });
                return new ResponseMessageDto(MessageType.Error, "");
            }
        }

        /// <summary>
        ///  thêm dữ liệu kiểu 1 cha và nhiều con , con có thể có nhiều loại khác nhau và sẽ lấy tên con làm tên bảng chứ không lấy tên thuộc tính vd: List<product> test =>tên bảng = product
        ///  những thuộc tính null sẽ bị bỏ qua
        ///  lấy dữ liệu tối đa 2 cấp, vd order->orderDetail. cấp 3: orderDetail->Product sẽ bị bỏ qua.
        /// </summary>
        /// <typeparam name="T">  đối tượng </typeparam>
        /// <param name="obj"> đối tượng </param>
        /// <param name="table">tên bảng</param>
        /// <param name="foreignKey">khóa tham chiếu đến bảng cha, nếu cả cha và con đều có chung 1 khóa sẽ giá trị khóa sẽ đc dùng cho cả 2, </param>
        /// <param name="foreignKeyValue">giá trị khóa ngoại nếu không có sẽ tự sinh</param>
        /// <param name="ConditionString">tên cột,nhiều cột sẽ cách nhau bằng dấu ',' vd: id,name. Chỉ dùng cho cha. check giá trị đã tồn tại, giá trị sẽ lấy từ object được truyền vào</param>
        /// <returns>
        /// trả về số lượng dòng được thêm
        /// lỗi trả về 1 thông báo
        /// </returns>
        public async Task<ResponseMessageDto> AddRangeAsync<T>(T obj, string table, string foreignKey, string foreignKeyValue, string ConditionString, int userId)
        {
            try
            {
                if (string.IsNullOrEmpty(foreignKey))
                {
                    return new ResponseMessageDto(MessageType.Error, "không có khóa ngoại");
                }
                if (string.IsNullOrEmpty(foreignKeyValue))
                    foreignKeyValue = await GenerateId.NewId(userId);
                return await Task.Run(() =>
                {
                    var column = ConditionString.Split(',');
                    var arrayCondition = new Dictionary<string, string>();
                    Type temp = typeof(T);
                    DataEditorAddRangeRequestModel dataEditorAddRequestModel = new DataEditorAddRangeRequestModel();
                    dataEditorAddRequestModel.TableName = table;
                    dataEditorAddRequestModel.UserId = userId;
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        //check property is child object 
                        if (!pro.PropertyType.Namespace.Contains("System"))
                        {
                            if (!(pro.GetValue(obj, null) is null))
                            {
                                object objChildData = pro.GetValue(obj, null);
                                Type objChildType = pro.PropertyType;
                                string columnChild = "";
                                string valueChild = "";
                                foreach (PropertyInfo proChild in objChildType.GetProperties())
                                {
                                    GetColumnAndValue(proChild, objChildData, ref columnChild, ref valueChild, foreignKey, foreignKeyValue, userId);
                                }
                                dataEditorAddRequestModel.CommandInsertTableChild += string.Format("INSERT TABLE {0} ( {1} ) \n VALUES ( {2});", objChildType.Name, columnChild.Remove(0, 1), valueChild.Remove(0, 1)) + "\n";
                            }

                        }
                        //check property is list child object 
                        else if (pro.PropertyType.IsGenericType &&
                          pro.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            if (!(pro.GetValue(obj, null) is null))
                            {
                                Type tableChild = Type.GetType(pro.PropertyType.FullName).GetGenericArguments()[0];//get tên object.
                                object objChildData = pro.GetValue(obj, null);
                                string columnChild = "";

                                StringBuilder insertQuery = new StringBuilder();
                                foreach (object objChild in (IEnumerable)objChildData)
                                {
                                    Type objChildType = objChild.GetType();
                                    if (string.IsNullOrEmpty(columnChild))
                                    {
                                        string valueChild = "";
                                        foreach (PropertyInfo proChild in objChildType.GetProperties())
                                        {

                                            GetColumnAndValue(proChild, objChild, ref columnChild, ref valueChild, foreignKey, foreignKeyValue, userId);
                                        }
                                        insertQuery.Append($"INSERT TABLE {tableChild.Name} ({columnChild.Remove(0, 1)}) \n");
                                        insertQuery.Append($"VALUES ({valueChild.Remove(0, 1)}), \n");
                                    }
                                    else
                                    {
                                        string valueChild = "";
                                        foreach (PropertyInfo proChild in objChildType.GetProperties())
                                        {
                                            GetColumnAndValue(proChild, objChild, ref columnChild, ref valueChild, foreignKey, foreignKeyValue, userId, true);
                                        }
                                        var t = insertQuery.Length - 2;

                                        insertQuery.Append($"({valueChild.Remove(0, 1)}), \n");
                                    }
                                }
                                dataEditorAddRequestModel.CommandInsertTableChild += insertQuery.ToString().Trim().TrimEnd(',') + ";\n";
                            }
                        }
                        else
                        {
                            string columnChild = "";
                            string valueChild = "";
                            GetColumnAndValue(pro, obj, ref columnChild, ref valueChild, foreignKey, foreignKeyValue, userId, false);
                            dataEditorAddRequestModel.ColumnArray += columnChild;
                            dataEditorAddRequestModel.ColumnValue += valueChild;
                            var castValue = pro.GetValue(obj, null).ToString();
                            if (!string.IsNullOrEmpty(ConditionString))
                            {
                                foreach (var item in column)
                                {
                                    if (item == pro.Name)
                                    {
                                        arrayCondition.Add(pro.Name, castValue);
                                    }
                                }
                            }
                        }

                    }
                    if (arrayCondition.Count > 0)
                    {
                        dataEditorAddRequestModel.Condition = 1;
                        var _condition = new StringBuilder();
                        foreach (var item in arrayCondition)
                        {
                            if (int.TryParse(item.Value, out int _int) || double.TryParse(item.Value, out double _double) || long.TryParse(item.Value, out long _long))
                            {
                                string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "=" + item.Value + ")) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED' RETURN; END \t";
                                _condition.Append(condition);
                            }
                            else if (DateTime.TryParse(item.Value, out DateTime _))
                            {
                                string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "='" + item.Value + "')) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED ' RETURN; END \t";
                                _condition.Append(condition);
                            }
                            else
                            {
                                string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE LOWER(" + item.Key + ") = LOWER('" + item.Value + "'))) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED ' RETURN; END \t";
                                _condition.Append(condition);
                            }
                        }
                        dataEditorAddRequestModel.ConditionString = _condition.ToString();
                    }
                    else
                    {
                        dataEditorAddRequestModel.Condition = 0;
                        dataEditorAddRequestModel.ConditionString = "SELECT 'MESSEAGE. NO MESSEAGE'";
                    }
                    dataEditorAddRequestModel.ColumnArray = dataEditorAddRequestModel.ColumnArray.Remove(0, 1);
                    dataEditorAddRequestModel.ColumnValue = dataEditorAddRequestModel.ColumnValue.Remove(0, 1);
                    return _dataEditor.AddRange(dataEditorAddRequestModel);
                });
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { obj = obj, table = table, ConditionString = ConditionString, user = userId });
                return new ResponseMessageDto(MessageType.Error, "");
            }
        }
        /// <summary>
        ///  update dữ liệu
        /// </summary>
        /// <typeparam name="T">  đối tượng </typeparam>
        /// <param name="obj"> đối tượng </param>
        /// <param name="table">tên bảng</param>  
        /// <param name="rowId">là Id dữ liệu </param> 
        /// <param name="ConditionString">tên cột,nhiều cột sẽ cách nhau bằng dấu ',' vd: id,name. check giá trị đã tồn tại, giá trị sẽ lấy từ object được truyền vào</param>
        /// <returns>
        /// trả về số lượng dòng bị ảnh hưởng
        /// lỗi trả về 1 thông báo
        /// </returns>
        public async Task<ResponseMessageDto> Update<T>(T obj, string table, int rowId, string ConditionString, int userId)
        {

            try
            {
                if (string.IsNullOrEmpty(table))
                {
                    return new ResponseMessageDto(MessageType.Error, "table is null");
                }
                return await Task.Run(() =>
                {
                    var column = ConditionString.Split(',');
                    var arrayCondition = new Dictionary<string, string>();
                    Type temp = typeof(T);
                    DataEditorUpdateRequestModel dataEditorUpdate = new DataEditorUpdateRequestModel();

                    dataEditorUpdate.TableName = table;
                    dataEditorUpdate.UserId = userId;
                    dataEditorUpdate.RowId = rowId;
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (!(pro.GetValue(obj, null) is null))
                        {
                            var castValue = pro.GetValue(obj, null).ToString();
                            if (pro.Name.ToLower() == "id" || pro.Name.ToLower() == "createdby" || pro.Name.ToLower() == "isactive" || pro.Name.ToLower() == "modifiedby" || pro.Name.ToLower() == "modifiedat" || pro.Name.ToLower() == "createdat")
                            {
                                continue;
                            }
                            if (int.TryParse(castValue, out int _int) || double.TryParse(castValue, out double _double) || long.TryParse(castValue, out long _long))
                            {

                                dataEditorUpdate.QueryUpdateData += "," + pro.Name + " = " + castValue;
                            }
                            else
                                dataEditorUpdate.QueryUpdateData += "," + pro.Name + " = '" + castValue + "'";
                            if (!string.IsNullOrEmpty(ConditionString))
                            {
                                foreach (var item in column)
                                {

                                    if (item == pro.Name)
                                    {
                                        arrayCondition.Add(pro.Name, castValue);
                                    }
                                }

                            }
                        }
                    }

                    if (arrayCondition.Count > 0)
                    {
                        dataEditorUpdate.Condition = 1;
                        var _condition = new StringBuilder();
                        foreach (var item in arrayCondition)
                        {
                            if (int.TryParse(item.Value, out int _int) || double.TryParse(item.Value, out double _double) || long.TryParse(item.Value, out long _long))
                            {
                                string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "!=" + item.Value + ")) BEGIN SELECT 'MESSEAGE." + item.Key + " IS NOT EXISTED' RETURN; END \t";
                                _condition.Append(condition);
                            }
                            else if (DateTime.TryParse(item.Value, out DateTime _))
                            {
                                string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "!='" + item.Value + "')) BEGIN SELECT 'MESSEAGE." + item.Key + " IS NOT EXISTED ' RETURN; END \t";
                                _condition.Append(condition);
                            }
                            else
                            {
                                string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE LOWER(" + item.Key + ") != LOWER('" + item.Value + "'))) BEGIN SELECT 'MESSEAGE." + item.Key + " IS NOT EXISTED ' RETURN; END \t";
                                _condition.Append(condition);
                            }
                        }
                        dataEditorUpdate.ConditionString = _condition.ToString();
                    }
                    else
                    {
                        dataEditorUpdate.Condition = 0;
                        dataEditorUpdate.ConditionString = "SELECT 'MESSEAGE. NO MESSEAGE'";
                    }
                    dataEditorUpdate.QueryUpdateData = dataEditorUpdate.QueryUpdateData.Remove(0, 1);
                    return _dataEditor.Update(dataEditorUpdate);
                });
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { obj = obj, table = table, rowid = rowId, ConditionString = ConditionString, user = userId });
                return new ResponseMessageDto(MessageType.Error, "");
            }
        }
        /// <summary>
        /// update nhiều  bảng một lúc
        /// Parameters:
        ///     setDefaultValue :
        ///      False : sẽ bỏ qua các cột có dữ liệu bị null
        ///     True: sẽ set default cho các dữ liệu bị null .
        ///     trừ các cột Id, CreatedAt, CreatedBy, ModifieldAt, ModifieldBy
        /// </summary>
        /// <typeparam name="T">Any</typeparam>
        /// <param name="obj"></param>
        /// <param name="table"></param>
        /// <param name="foreignKey"></param>
        /// <param name="foreignKeyValue"> </param>
        /// <param name="setDefaultValue">
        /// False : sẽ có nguy cơ lỗi  cột not null.
        /// True: sẽ set default cho các dữ liệu bị null .
        /// trừ các cột Id, CreatedAt, CreatedBy, ModifieldAt, ModifieldBy
        /// </param>
        /// <returns>
        /// suscess: ResponseMessageDto
        /// error: ném 1 exception
        /// </returns>
        public async Task<ResponseMessageDto> UpdateRangeAsync<T>(T obj, string table, string foreignKey, string foreignKeyValue, string ConditionString, int userId, bool setDefaultValue = true)
        {
            try
            {
                if (string.IsNullOrEmpty(foreignKey))
                {
                    return new ResponseMessageDto(MessageType.Error, "không có khóa ngoại");
                }
                if (string.IsNullOrEmpty(foreignKeyValue))
                {
                    return new ResponseMessageDto(MessageType.Error, "GIÁ TRỊ KHÓA NGOẠI KHÔNG HỢP LỆ");
                }
                return await Task.Run(async () =>
               {

                   var column = ConditionString.Split(',');
                   var arrayCondition = new Dictionary<string, string>();
                   Type temp = typeof(T);
                   DataEditorUpdateRangeRequestModel dataEditor = new DataEditorUpdateRangeRequestModel();
                   dataEditor.TableName = table;
                   dataEditor.UserId = userId;
                   Dictionary<string, object> ChildTables = new Dictionary<string, object>();
                   bool checkForeignKeyExist = true;
                   StringBuilder tempTable = new StringBuilder();
                   StringBuilder QueryDelete = new StringBuilder();
                   StringBuilder QueryUpdate = new StringBuilder();
                   StringBuilder QueryInsert = new StringBuilder();
                   StringBuilder DropTempTable = new StringBuilder();
                   foreach (PropertyInfo pro in temp.GetProperties())
                   {

                       if (!pro.PropertyType.Namespace.Contains("System"))
                       {
                           if (!(pro.GetValue(obj, null) is null))
                           {
                               object objChildData = pro.GetValue(obj, null);
                               Type objChildType = pro.PropertyType;
                               //tạo bảng temp cho bảng con
                               tempTable.AppendLine("SELECT");
                               string columnChild = "";
                               string updateQuery = "";

                               var objData = Activator.CreateInstance(objChildType);
                               for (int i = 0; i < objChildType.GetProperties().Length; i++)
                               {
                                   if (!checkForeignKeyExist)
                                   {

                                       if (!objChildType.GetProperties()[i].Name.Equals(foreignKey))
                                       {
                                           checkForeignKeyExist = false;
                                       }
                                       else checkForeignKeyExist = true;
                                   }
                                   columnChild += ", " + objChildType.GetProperties()[i].Name;
                                   tempTable.AppendLine($"\t JSON_VALUE(D.value, '$.{FirstCharToLowerCase(objChildType.Name)}.{objChildType.GetProperties()[i].Name}') AS {objChildType.GetProperties()[i].Name},");
                                   if (objChildType.GetProperties()[i].GetValue(objChildData, null) is null)
                                   {
                                       if (objChildType.GetProperties()[i].Name.ToUpper().Contains("CREATEDAT") || objChildType.GetProperties()[i].Name.ToUpper().Contains("MODIFIEDAT"))
                                       {
                                           objChildType.GetProperties()[i].SetValue(objChildData, DateTime.Now, null);
                                       }
                                       else if (objChildType.GetProperties()[i].Name.ToUpper().Contains("CREATEDBY") || objChildType.GetProperties()[i].Name.ToUpper().Contains("MODIFIEDBY"))
                                       {
                                           objChildType.GetProperties()[i].SetValue(objChildData, userId, null);
                                       }
                                       else if (objChildType.GetProperties()[i].Name.Contains(foreignKey))
                                       {
                                           objChildType.GetProperties()[i].SetValue(objChildData, foreignKeyValue, null);
                                       }
                                       else if (objChildType.GetProperties()[i].Name.ToUpper().Contains("ID"))
                                           objChildType.GetProperties()[i].SetValue(objChildData, -1, null);
                                       else
                                           DefaultValueForSystemType(objChildType.GetProperties()[i], objChildData);
                                   }
                                   else
                                       continue;
                               }
                               if (!checkForeignKeyExist)
                                   throw new Exception(objChildType.Name + " Không có thuộc tính trùng với khóa ngoại");
                               if (ChildTables.ContainsKey(objChildType.Name))
                               {
                                   throw new Exception("có 2 thuộc tính có cùng 1 đối tượng ");
                               }
                               columnChild = columnChild.Remove(0, 1);
                               tempTable = tempTable.Remove(tempTable.Length - 3, 1);
                               tempTable.AppendLine($"INTO #{objChildType.Name}");
                               tempTable.AppendLine("FROM OPENJSON(@JsonTableChild) AS D ;");
                               QueryDelete.Append($" DELETE FROM {objChildType.Name} WHERE {foreignKey} = '{foreignKeyValue}' AND Id NOT IN (SELECT Id FROM #{objChildType.Name}) ");
                               QueryUpdate.AppendLine($" UPDATE {objChildType.Name} SET {updateQuery} FROM {objChildType.Name} INNER JOIN #{objChildType.Name} ON #{objChildType.Name}.Id=#{objChildType.Name}.Id ");
                               QueryInsert.AppendLine($"INSERT INTO {objChildType.Name}( {columnChild}) SELECT {columnChild} FROM #{objChildType.Name} WHERE Id=0");
                               DropTempTable.AppendLine($"DROP TABLE #{objChildType.Name};");
                               ChildTables.Add(objChildType.Name, objChildData);
                           }
                       }
                       //check property is list child object 
                       else if (pro.PropertyType.IsGenericType && pro.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                       {
                           if (!(pro.GetValue(obj, null) is null))
                           {
                               Type tableChild = Type.GetType(pro.PropertyType.FullName).GetGenericArguments()[0];//get tên object.
                               object objChildData = pro.GetValue(obj, null);
                               tempTable.AppendLine("SELECT");
                               string columnChild = "";
                               string updateQuery = "";
                               List<object> dataChils = new List<object>();
                               if (setDefaultValue)
                               {
                                   foreach (object objChild in (IEnumerable)objChildData)
                                   {
                                       Type objChildType = objChild.GetType();
                                       var objData = Activator.CreateInstance(objChildType);
                                       for (int i = 0; i < objChildType.GetProperties().Length; i++)
                                       {
                                           if (objChildType.GetProperties()[i].GetValue(objChild, null) is null)
                                           {
                                               var testttt = objChildType.GetProperties()[i].Name;
                                               if (objChildType.GetProperties()[i].Name.ToUpper().Contains("CREATEDAT") || objChildType.GetProperties()[i].Name.ToUpper().Contains("MODIFIEDAT"))
                                               {
                                                   objChildType.GetProperties()[i].SetValue(objChild, DateTime.Now, null);
                                               }
                                               else if (objChildType.GetProperties()[i].Name.ToUpper().Contains("CREATEDBY") || objChildType.GetProperties()[i].Name.ToUpper().Contains("MODIFIEDBY"))
                                                   objChildType.GetProperties()[i].SetValue(objChild, userId, null);
                                               else if (objChildType.GetProperties()[i].Name.ToUpper().Contains("ID"))
                                                   objChildType.GetProperties()[i].SetValue(objChild, -1, null);
                                               else if (objChildType.GetProperties()[i].Name.Contains(foreignKey))
                                                   objChildType.GetProperties()[i].SetValue(objChild, foreignKeyValue, null);
                                               else
                                                   DefaultValueForSystemType(objChildType.GetProperties()[i], objChild);
                                           }

                                       }
                                       dataChils.Add(objChild);
                                   }
                                   foreach (PropertyInfo proChild in tableChild.GetProperties())
                                   {
                                       if (!checkForeignKeyExist)
                                       {

                                           if (!proChild.Name.Equals(foreignKey))
                                           {
                                               checkForeignKeyExist = false;
                                           }
                                           else checkForeignKeyExist = true;
                                       }
                                       columnChild += ", " + proChild.Name;
                                       updateQuery += $", {proChild.Name} = #{tableChild.Name}.{proChild.Name}";
                                       tempTable.AppendLine($"\t JSON_VALUE(D.value, '$.{FirstCharToLowerCase(tableChild.Name)}.{proChild.Name}') AS {proChild.Name},");
                                   }
                                   if (!checkForeignKeyExist)
                                       throw new Exception(tableChild.Name + " Không có thuộc tính trùng với khóa ngoại");
                                   if (ChildTables.ContainsKey(tableChild.Name))
                                   {
                                       throw new Exception("có 2 thuộc tính có cùng 1 đối tượng ");
                                   }
                                   columnChild = columnChild.Remove(0, 1);
                                   updateQuery = updateQuery.Remove(0, 1);
                                   tempTable = tempTable.Remove(tempTable.Length - 3, 1);
                                   tempTable.AppendLine($"");
                                   tempTable.AppendLine("FROM  OPENJSON(@JsonTableChild) AS D ");
                                   QueryDelete.AppendLine($" DELETE FROM {tableChild.Name} WHERE {foreignKey} = '{foreignKeyValue}' AND Id NOT IN (SELECT Id FROM #{tableChild.Name}) ");
                                   QueryUpdate.AppendLine($" UPDATE {tableChild.Name} SET {updateQuery} FROM {tableChild.Name} INNER JOIN {tableChild.Name} ON #{tableChild.Name}.Id=#{tableChild.Name}.Id ");
                                   QueryInsert.AppendLine($"INSERT INTO {tableChild.Name}( {columnChild}) SELECT {columnChild} FROM #{tableChild.Name} WHERE Id = 0");
                                   DropTempTable.AppendLine($"DROP TABLE #{tableChild.Name};");
                                   ChildTables.Add(tableChild.Name, dataChils);
                               }
                           }
                       }
                       else
                       {
                           var castValue = "";
                           if (pro.GetValue(obj, null) is null)
                           {
                               if (setDefaultValue)
                               {
                                   var prop = DefaultValueForSystemType(pro, obj);
                                   castValue = prop.GetValue(obj, null).ToString();
                               }
                               else
                                   castValue = "NULL";
                           }
                           else
                           {
                               castValue = pro.GetValue(obj, null).ToString();
                           }
                           if (pro.Name.ToLower() == "id" || pro.Name.ToLower() == "createdby" || pro.Name.ToLower() == "isactive" || pro.Name.ToLower() == "modifiedby" || pro.Name.ToLower() == "modifiedat" || pro.Name.ToLower() == "createdat")
                           {
                               continue;
                           }
                           if (int.TryParse(castValue, out int _int) || double.TryParse(castValue, out double _double) || long.TryParse(castValue, out long _long))
                           {

                               dataEditor.QueryUpdateData += "," + pro.Name + " = " + castValue;
                           }
                           else
                               dataEditor.QueryUpdateData += "," + pro.Name + " = '" + castValue + "'";
                           if (!string.IsNullOrEmpty(ConditionString))
                           {
                               foreach (var item in column)
                               {

                                   if (item == pro.Name)
                                   {
                                       arrayCondition.Add(pro.Name, castValue);
                                   }
                               }

                           }
                       }
                   }
                   if (arrayCondition.Count > 0)
                   {
                       dataEditor.Condition = 1;
                       var _condition = new StringBuilder();
                       foreach (var item in arrayCondition)
                       {
                           if (int.TryParse(item.Value, out int _int) || double.TryParse(item.Value, out double _double) || long.TryParse(item.Value, out long _long))
                           {
                               string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "=" + item.Value + ")) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED' RETURN; END \t";
                               _condition.Append(condition);
                           }
                           else if (DateTime.TryParse(item.Value, out DateTime _))
                           {
                               string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE " + item.Key + "='" + item.Value + "')) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED ' RETURN; END \t";
                               _condition.Append(condition);
                           }
                           else
                           {
                               string condition = "IF(EXISTS(SELECT TOP 1 * FROM " + table + " WHERE LOWER(" + item.Key + ") = LOWER('" + item.Value + "'))) BEGIN SELECT 'MESSEAGE." + item.Key + " IS EXISTED ' RETURN; END \t";
                               _condition.Append(condition);
                           }
                       }
                       dataEditor.ConditionString = _condition.ToString();
                   }
                   else
                   {
                       dataEditor.Condition = 0;
                       dataEditor.ConditionString = "SELECT 'MESSEAGE. NO MESSEAGE'";
                   }
                   dataEditor.QueryUpdateData = dataEditor.QueryUpdateData.Remove(0, 1);

                   dataEditor.JsonTableChild = JsonConvert.SerializeObject(ChildTables);
                   dataEditor.QueryDelete = QueryDelete.ToString();
                   dataEditor.QueryUpdate = QueryUpdate.ToString();
                   dataEditor.QueryInsert = QueryInsert.ToString();
                   dataEditor.QueryDropTempTable = DropTempTable.ToString();
                   dataEditor.TempTable = tempTable.ToString();
                   return await _dataEditor.UpdateRange(dataEditor);
               });
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new
                {
                    obj = obj,
                    table = table,
                    ConditionString = ConditionString,
                    user = userId
                });
                return new ResponseMessageDto(MessageType.Error, ex.Message);
            }
        }

        /// <summary>
        ///  xóa dữ liệu
        /// </summary>
        /// <param name="table">tên bảng</param>  
        /// <param name="rowId">là Id dữ liệu </param> 
        /// <returns>
        /// trả về một thông báo
        /// </returns>
        public async Task<ResponseMessageDto> Delete(string table, int rowId, int userId)
        {

            try
            {
                if (string.IsNullOrEmpty(table))
                {
                    return new ResponseMessageDto(MessageType.Error, "table is null");
                }
                return await Task.Run(() =>
                {
                    var arrayCondition = new Dictionary<string, string>();
                    DataEditorDeleteRequestModel dataEditor = new DataEditorDeleteRequestModel();
                    dataEditor.TableName = table;
                    dataEditor.UserId = userId;
                    dataEditor.RowId = rowId;
                    dataEditor.Condition = 0;
                    dataEditor.ConditionString = "SELECT 'MESSEAGE. NO MESSEAGE'";
                    return _dataEditor.Delete(dataEditor);
                });
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { table = table, rowid = rowId, user = userId });
                return new ResponseMessageDto(MessageType.Error, "");
            }
        }
        /// <summary>
        ///  khôi phục dữ liệu
        /// </summary>
        /// <param name="table">tên bảng</param>  
        /// <param name="rowId">là Id dữ liệu </param> 
        /// <returns>
        /// trả về một thông báo
        /// </returns>
        public async Task<ResponseMessageDto> Restore(string table, int rowId, int userId)
        {
            try
            {
                if (string.IsNullOrEmpty(table))
                {
                    return new ResponseMessageDto(MessageType.Error, "table is null");
                }
                return await Task.Run(() =>
                {
                    //var column = ConditionString.Split(',');
                    var arrayCondition = new Dictionary<string, string>();
                    DataEditorRestoreRequestModel dataEditor = new DataEditorRestoreRequestModel();
                    dataEditor.TableName = table;
                    dataEditor.UserId = userId;
                    dataEditor.RowId = rowId;
                    dataEditor.Condition = 0;
                    dataEditor.ConditionString = "SELECT 'MESSEAGE. NO MESSEAGE'";
                    return _dataEditor.Restore(dataEditor);
                });
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { table = table, rowid = rowId, user = userId });
                return new ResponseMessageDto(MessageType.Error, "");
            }

        }

        private void GetColumnAndValue(PropertyInfo pro, object obj, ref string column, ref string value, string foreignKey, string foreignKeyValue, int userId, bool isOnlyValue = false, bool setDefaultValue = false)
        {

            if ((pro.GetValue(obj, null) is null))
            {
                if (setDefaultValue)
                    pro = DefaultValueForSystemType(pro, obj);
            }

            if (pro.Name.ToLower() == "id" || pro.Name.ToLower() == "isactive" || pro.Name.ToLower() == "modifiedby" || pro.Name.ToLower() == "modifiedat" || pro.Name.ToLower() == "createdat")
            {
                return;
            }
            else if (pro.Name.ToLower() == "createdby")
            {
                if (!isOnlyValue)
                {
                    column += ", " + pro.Name;
                }

                value += ", " + userId;
                return;
            }
            else if (pro.Name.ToLower().Equals(foreignKey))
            {
                if (!isOnlyValue)
                {
                    column += ", " + pro.Name;
                }
                value += ", '" + foreignKeyValue + "'";
                return;
            }
            else
            {
                if (!isOnlyValue)
                {
                    column += ", " + pro.Name;
                }
            }
            var castValue = pro.GetValue(obj, null).ToString();
            if (int.TryParse(castValue, out int _int) || double.TryParse(castValue, out double _double) || long.TryParse(castValue, out long _long))
            {
                value += ", " + castValue;
            }
            else
                value += ", '" + castValue + "'";

        }
        /// <summary>
        /// tạo giá trị mặc định cho tất cả các loại thuộc tính của system.
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public PropertyInfo DefaultValueForSystemType(PropertyInfo pro, object obj)
        {
            if (pro.GetValue(obj, null) is null)
            {
                var conversionType = pro.PropertyType;
                if (!pro.PropertyType.Namespace.Contains("System"))
                {
                    throw new Exception("thuộc tính không phải loại thuộc system");
                }
                if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (obj == null)
                        return null;
                    var nullableConverter = new NullableConverter(conversionType);
                    conversionType = nullableConverter.UnderlyingType;
                }
                pro.SetValue(obj, Activator.CreateInstance(conversionType), null);
                //var test = pro.GetValue(obj, null);
            }
            return pro;
        }

        public string FirstCharToLowerCase(string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}

