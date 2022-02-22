using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public static class ConvertHelper
    {
        public static IList<T> ConvertTo<T>(this DataTable table)
        {
            List<T> data = new List<T>();
            if (table == null)
            {
                return null;
            }
            foreach (DataRow row in table.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(this DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {

                    if (pro.Name.ToUpper() == column.ColumnName.ToUpper())
                    {
                        if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                        {

                            if (column.DataType == Type.GetType("System.DateTime"))
                            {
                                pro.SetValue(obj, DateTime.MinValue, null);
                            }
                            else if (column.DataType == Type.GetType("System.String"))
                            {
                                pro.SetValue(obj, "", null);
                            }
                            else
                            {
                                pro.SetValue(obj, default, null);
                            }

                        }
                        else
                        {
                            var type = ConvertType(dr[column.ColumnName], pro.PropertyType);
                            pro.SetValue(obj, type, null);
                            //pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }

                    else
                    {

                        continue;
                    }
                }
            }
            return obj;
        }
        public static dynamic ConvertType(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }

        public static async Task<IList<T>> ConvertToAsync<T>(this DataTable table)
        {

            var taskResult = await Task.Run(() =>
            {
                List<T> data = new List<T>();
                if (table == null)
                {
                    return null;
                }
                foreach (DataRow row in table.Rows)
                {
                    T item = GetItemAsync<T>(row).Result;
                    data.Add(item);
                }
                return data;
            });
            return taskResult;
        }
        public static async Task<T> GetItemAsync<T>(this DataRow dr)
        {
            var taskResult = await Task.Run(() =>
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                  
                foreach (DataColumn column in dr.Table.Columns)
                {
                    if (temp.IsEnum)
                    {
                        obj = (T)dr[column.ToString()];
                        continue ;
                    }
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {

                        if (pro.Name.ToUpper() == column.ColumnName.ToUpper())
                        {
                            if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                            {

                                if (column.DataType == Type.GetType("System.DateTime"))
                                {
                                    pro.SetValue(obj, DateTime.MinValue, null);
                                }
                                else if (column.DataType == Type.GetType("System.String"))
                                {
                                    pro.SetValue(obj, "", null);
                                }
                                else
                                {
                                    pro.SetValue(obj, default, null);
                                }

                            }
                            else
                            {
                                var type = ConvertType(dr[column.ColumnName], pro.PropertyType);
                                pro.SetValue(obj, type, null);
                                //pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                        }

                        else
                        {

                            continue;
                        }
                    }
                }
                return obj;
            });
            return taskResult;
        }
       
    }
}