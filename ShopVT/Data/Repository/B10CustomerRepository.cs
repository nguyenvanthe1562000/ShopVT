using Common;
using Common.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Reponsitory
{
    class B10CustomerRepository : IB10CustomerRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public B10CustomerRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(B10CustomerModel model, int userId)
        {
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10Customer_create", "@Name", model.Name, "@email", model.email, "@phone", model.phone, "@gender", model.gender, "@BirthDate", model.BirthDate, "@IsActive", model.IsActive, "@user_id", userId);
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











        public async Task<bool> Update(B10CustomerModel model, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10Customer_update", "@Name", model.Name, "@email", model.email, "@phone", model.phone, "@gender", model.gender, "@BirthDate", model.BirthDate, "@IsActive", model.IsActive
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


        public async Task<bool> Delete(int ID, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10Customer_delete", "@ID", ID, "@user_id", userId);
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




        public async Task<List<B10CustomerModel>> GetAll()
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Customer_get_all");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10CustomerModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<B10CustomerModel>> Search(string Name)
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Customer_search", "@Name", Name);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10CustomerModel>();
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

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B10Customer");
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





        public async Task<B10CustomerModel> GetById(int ID)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Customer_get_by_id", "@ID", ID);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10CustomerModel>();
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
        ~B10CustomerRepository()
        {
            Dispose(false);

        }
    }
}


















