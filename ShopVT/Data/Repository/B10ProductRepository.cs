
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
    public class B10ProductRepository : IB10ProductRepository, IDisposable
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
        public async Task<bool> Insert(B10ProductModel model, int userId)
        {

            try
            {
                model=await SetObjectValueDefault.SetValueDefault<B10ProductModel>(model);


                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10Product_create", "@code", model.code, "@Name", model.Name, "@Alias", model.Alias, "@ProductCategoryCode", model.ProductCategoryCode, "@UnitCost", model.UnitCost, "@UnitPrice", model.UnitPrice, "@Warranty", model.Warranty, "@Description", model.Description, "@Content", model.Content, "@Information", model.Information, "@user_id", userId);
                if (string.IsNullOrEmpty( result.message))
                {
                    return false;
                    throw new Exception(Convert.ToString(result));
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
        public async Task<bool> Update(B10ProductModel model, int userId)
        {
            string msgError = "";
            try
            {

                var taskResult = await Task.Run(() =>
                {
                    var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "B10Product_update", "@code", model.code, "@Name", model.Name, "@Alias", model.Alias, "@ProductCategoryCode", model.ProductCategoryCode, "@UnitCost", model.UnitCost, "@UnitPrice", model.UnitPrice, "@Warranty", model.Warranty, "@Description", model.Description, "@Content", model.Content, "@Information", model.Information, "@IsActive", model.IsActive
              , "@user_id", userId);
                    if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                    {
                        return false;
                        throw new Exception(Convert.ToString(result) + msgError);
                    }
                    return true;
                });
                return taskResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> Delete(string code, int userId)
        {
            try
            {

                var result = await _dbHelper.ExecuteSProcedureAsync("B10Product_delete", "@code", code, "@user_id", userId);
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    return false;
                    throw new Exception(result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            try
            {

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B10Product");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<PagedResultBase>();
                return list.ToList().FirstOrDefault();

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
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Product_get_all");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(msgError);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<B10ProductModel>> Search(string Name)
        {

            try
            {

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Product_search", "@Name", Name
                );
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductModel>();
                return list.ToList();

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
        public async Task<B10ProductModel> GetById(string code)
        {

            try
            {

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Product_get_by_id", "@code", code);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductModel>();
                return list.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {

                if (_dbHelper != null)
                {
                    _dbHelper = null;

                    //GC.Collect();
                }
                disposed = true;
            }

        }
        ~B10ProductRepository()
        {
            Dispose(false);

        }

    }
}










