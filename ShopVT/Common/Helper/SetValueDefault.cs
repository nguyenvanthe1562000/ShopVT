using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class SetObjectValueDefault
    {
        public static async Task<T> SetValueDefault<T>(object setObjValue)
        {
            var taskResult = Task.Run(() =>
            {
                Type temp = typeof(T);
                T _obj = Activator.CreateInstance<T>();
                foreach (var item in setObjValue.GetType().GetProperties())
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name.ToUpper() == item.Name.ToUpper())
                        {
                            
                            if ( item.GetValue(setObjValue) == null)
                            {
                                //var type = 
                               

                                //if (item.PropertyType == Type.GetType("System.DateTime"))
                                //{
                                //    pro.SetValue(_obj, DateTime.MinValue, null);
                                //}
                                //else if (item.PropertyType == Type.GetType("System.String"))
                                //{
                                //    pro.SetValue(_obj, "", null);
                                //}
                                //else
                                //{
                                    pro.SetValue(_obj, Activator.CreateInstance(item.PropertyType), null);
                                //}
                            }
                           
                            else
                            {
                                var objvalue = item.GetValue(setObjValue).ToString();
                                var type = ConvertType(objvalue, pro.PropertyType);
                                pro.SetValue(_obj, type, null);
                            }
                        }
                    }
                }
                return _obj;
            });

          
            return await taskResult;
        }
        public static dynamic ConvertType(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }
    }
}
