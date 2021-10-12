using Common.Helper;
using Data.Repository.Interface;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Reponsitory
{
    class B00FunctionRepository : IB00FunctionRpository
    {

        private DatabaseHelper _dbHelper;
        public B00FunctionRepository(DatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        /// <summary>
        /// Add a new records into the table B00Function
        /// </summary>
        /// <param name="model">The record added </param>
        /// <returns></returns>
        public bool Insert(B00FunctionModel model, int userId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "usp_B00Function_create", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@Code", model.Code, "@CategoryFunc", model.CategoryFunc, "@Name", model.Name, "@Url", model.Url, "@DisplayOrder", model.DisplayOrder,, "@user_id", userId);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }









        /// <summary>
        /// Update information in the table Employee
        /// </summary>
        /// <param name="model">The record updated</param>
        /// <returns></returns>
        public bool Update(B00FunctionModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "usp_B00Function_update", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@Code", model.Code, "@CategoryFunc", model.CategoryFunc, "@Name", model.Name, "@Url", model.Url, "@DisplayOrder", model.DisplayOrder, "@IsActive", model.IsActive
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete(string Code)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_B00Function_delete", "@Code", Code);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Get the information by using id of the table Employee
        /// </summary>
        /// <returns></returns>
        public List<B00FunctionModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_B00Function_get_all");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<B00FunctionModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Searching information in the table Employee
        /// </summary>
        /// <param name="pageIndex">Which page?</param>
        /// <param name="pageSize">The number of records in a page</param>
        /// <param name="lang"> Language used to display data</param>
        /// <param name="total">The total number of records</param> 
        /// <returns></returns>
        public List<B00FunctionModel> Search(string Code)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_B00Function_search", "@Code", Code

                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<B00FunctionModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get the information by using id of the table Employee
        /// </summary>
        /// <param name="id">Id used to get the information</param>
        /// <returns></returns>
        public B00FunctionModel GetById(string Code)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_B00Function_get_by_id", "@Code", Code);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<B00FunctionModel>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<B00FunctionModel> GetFunctionAdminByTree()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_getfunctionadminbytree");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<B00FunctionModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}











