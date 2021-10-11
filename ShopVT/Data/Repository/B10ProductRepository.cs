
using Common;
using Common.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Reponsitory
{
    public class B10ProductRepository : IB10ProductRepository
    {
        private IDatabaseHelper _dbHelper;
        public B10ProductRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        /// <summary>
        /// Add a new records into the table B10Product
        /// </summary>
        /// <param name="model">The record added </param>
        /// <returns></returns>
        public async Task<bool> Insert(B10ProductModel model)
        {
            string msgError = "";
            try
            {
                bool flag = true;
                await Task.Run(() =>
                {
                    var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "B10Product_create", "@code", model.code, "@Name", model.Name, "@Alias", model.Alias, "@ProductCategoryCode", model.ProductCategoryCode, "@UnitCost", model.UnitCost, "@UnitPrice", model.UnitPrice, "@Warranty", model.Warranty, "@Description", model.Description, "@Content", model.Content, "@Information", model.Information, "@user_id", 123);
                    if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                    {
                        flag = false;
                        throw new Exception(Convert.ToString(result) + msgError);
                    }
                    flag = true;
                });
                return flag;
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
        public async Task<bool> Update(B10ProductModel model)
        {
            string msgError = "";
            try
            {
                bool flag = true;
                await Task.Run(() =>
                {
                    var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "B10Product_update", "@code", model.code, "@Name", model.Name, "@Alias", model.Alias, "@ProductCategoryCode", model.ProductCategoryCode, "@UnitCost", model.UnitCost, "@UnitPrice", model.UnitPrice, "@Warranty", model.Warranty, "@Description", model.Description, "@Content", model.Content, "@Information", model.Information, "@IsActive", model.IsActive
                );
                    if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                    {
                        flag = false;
                        throw new Exception(Convert.ToString(result) + msgError);
                    }
                    flag = true;
                });
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> Delete(string code)
        {
            string msgError = "";
            try
            {
                bool flag = true;
                await Task.Run(() =>
                {
                    var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "B10Product_delete", "@code", code);
                    if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                    {
                        flag = false;
                        throw new Exception(Convert.ToString(result) + msgError);
                    }
                    flag = true;
                });
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            string msgError = "";
            try
            {
                var result = new PagedResultBase();
                await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B10Product");
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    result = dt.ConvertTo<PagedResultBase>().ToList().FirstOrDefault();
                });
                return result;
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
        public async Task<List<B10ProductModel>> GetAll()
        {
            string msgError = "";
            try
            {
                var result = new List<B10ProductModel>();
                await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "B10Product_get_all");
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    result = dt.ConvertTo<B10ProductModel>().ToList();
                });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<B10ProductModel>> Search(string Name)
        {
            string msgError = "";
            try
            {
                var result = new List<B10ProductModel>();
                await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "B10Product_search", "@Name", Name
                    );
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    result = dt.ConvertTo<B10ProductModel>().ToList();
                });
                return result;
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
        public async Task<B10ProductModel> GetById( string code)
        {
            string msgError = "";
            try
            {
                var result = new B10ProductModel();
                await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "B10Product_get_by_id", "@code", code);
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    result = dt.ConvertTo<B10ProductModel>().ToList().FirstOrDefault();
                });
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}










