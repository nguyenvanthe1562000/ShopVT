using Common;
using Data.Command;
using Model.Command;
using Service.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Command
{
    public class DataEdtitorService : IDataEdtitorService
    {
        private IDataEditorRepository _dataEditor;

        public DataEdtitorService(IDataEditorRepository dataEditor)
        {
            _dataEditor = dataEditor;
        }

       
        /// <summary>
        ///  thêm dữ liệu
        /// </summary>
        /// <typeparam name="T">  đối tượng </typeparam>
        /// <param name="obj"> đối tượng </param>
        /// <param name="table">tên bảng</param>
        /// <param name="ConditionString">tên cột,nhiều cột sẽ cách nhau bằng dấu ',' vd: id,name. check giá trị đã tồn tại, giá trị sẽ lấy từ object được truyền vào</param>
        /// <returns>
        /// trả về số lượng dòng được thêm
        /// lỗi trả về 1 thông báo
        /// </returns>
        public  Task<ResponseMessageDto> Add<T>(T obj, string table, string ConditionString,int userId)
        {
            return Task.Run(() =>
            {
                var column = ConditionString.Split(',');
                var arrayCondition = new Dictionary<string, string>();
                Type temp = typeof(T);
                DataEditorAddRequestModel dataEditorAddRequestModel = new DataEditorAddRequestModel();
                dataEditorAddRequestModel.UserId = userId;
                foreach (PropertyInfo pro in temp.GetProperties())
                {
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

                if (!string.IsNullOrEmpty(ConditionString))
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
        public Task<ResponseMessageDto> Update<T>(T obj, string table, int rowId, string ConditionString, int userId)
        {
            return Task.Run(() =>
            {
                var column = ConditionString.Split(',');
                var arrayCondition = new Dictionary<string, string>();
                Type temp = typeof(T);
                DataEditorUpdateRequestModel dataEditorUpdate = new DataEditorUpdateRequestModel();
                if(!string .IsNullOrEmpty(ConditionString))
                {
                    return null;
                }
                if (!string.IsNullOrEmpty(table))
                {
                    return null;
                }
                dataEditorUpdate.RowId = rowId;
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    var castValue = pro.GetValue(obj, null).ToString();

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

                if (!string.IsNullOrEmpty(ConditionString))
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
    }
}
