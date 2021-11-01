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
    class B10ProductCategoryRepository : IB10ProductCategoryRepository,IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public B10ProductCategoryRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(B10ProductCategoryModel model, int userId)
        {
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductCategory_create", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@code", model.code, "@Name", model.Name, "@Alias", model.Alias, "@Description", model.Description, "@DisplayOrder", model.DisplayOrder, "@IsActive", model.IsActive, "@user_id", userId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return false;
                    throw new Exception(result.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }











        public async Task<bool> Update(B10ProductCategoryModel model, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductCategory_update", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@code", model.code, "@Name", model.Name, "@Alias", model.Alias, "@Description", model.Description, "@DisplayOrder", model.DisplayOrder, "@IsActive", model.IsActive
                , "@user_id", userId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return false;
                    throw new Exception(result.message);
                }
                return true;
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
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductCategory_delete", "@code", code, "@user_id", userId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return false;
                    throw new Exception(result.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<B10ProductCategoryModel>> GetAll()
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductCategory_get_all");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductCategoryModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<B10ProductCategoryModel>> Search(string Name)
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductCategory_search", "@Name", Name);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductCategoryModel>();
                return list.ToList();
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

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B10ProductCategory");
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





        public async Task<B10ProductCategoryModel> GetById(string code)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductCategory_get_by_id", "@code", code);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductCategoryModel>();
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
        ~B10ProductCategoryRepository()
        {
            Dispose(false);

        }
    }
}















